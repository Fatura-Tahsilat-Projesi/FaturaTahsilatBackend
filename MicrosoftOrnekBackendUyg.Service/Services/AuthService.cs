using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MicrosoftOrnekBackendUyg.Common.DTOs;
using MicrosoftOrnekBackendUyg.Core.Configuration;
using MicrosoftOrnekBackendUyg.Core.DTOs;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Repositories;
using MicrosoftOrnekBackendUyg.Core.Services;
using MicrosoftOrnekBackendUyg.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MicrosoftOrnekBackendUyg.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly RoleManager<AppRole> _roleManager1;
       // private readonly IdentityUserRole<string> _userRoleManager;
        //private readonly RoleManager<IdentityUserRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IRepository<UserRefreshToken> _userRefreshTokenService;
        private readonly List<Client> _clients;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, ITokenService tokenService, IMapper mapper, UserManager<UserApp> userManager, IRepository<UserRefreshToken> userRefreshTokenService,IOptions<List<Client>> optionsClient, RoleManager<IdentityRole> roleManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
            //_roleManager1 = roleManager1;
            //_userRoleManager = userRoleManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenService = userRefreshTokenService;
            _clients = optionsClient.Value;
            _mapper = mapper;

        }

        public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if(loginDto == null) throw new ArgumentNullException(nameof(loginDto));

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if(user == null) return Response<TokenDto>.Fail("Email or Password is wrong", 400, true);

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return Response<TokenDto>.Fail("Email or Password is wrong", 400, true);
            }
            var token = _tokenService.CreateToken(user);

            var userRefreshToken = await _userRefreshTokenService.WhereAuth(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if (userRefreshToken == null)
            {
                await _userRefreshTokenService.AddAsync(new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
                Serilog.Log.Information("Token oluşturuldu. Bilgiler => | " + user.Id + " | "+ token.RefreshToken + " | " + token.RefreshTokenExpiration + " |");
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
                token.UserIdValue = user.Id;
                userRefreshToken.UserId = token.UserIdValue;
                Serilog.Log.Information("Token kontrol edildi ve veritabanında bulundu. Bigiler => | "+token.RefreshToken + " | "+token.RefreshTokenExpiration + " | ");
            }

            await _unitOfWork.CommitAsync();

            return Response<TokenDto>.Success(token, 200);

        }

        public async Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenService.WhereAuth(x => x.Code == refreshToken).SingleOrDefaultAsync();

            if (existRefreshToken == null)
            {
                return Response<TokenDto>.Fail("Refresh token not found", 404, true);
            }

            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);

            if (user == null)
            {
                return Response<TokenDto>.Fail("User Id not found", 404, true);
            }

            var tokenDto = _tokenService.CreateToken(user);

            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

            await _unitOfWork.CommitAsync();

            return Response<TokenDto>.Success(tokenDto, 200);
        }

        public async Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenService.WhereAuth(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null)
            {
                return Response<NoDataDto>.Fail("Refresh token not found", 404, true);
            }

            _userRefreshTokenService.Remove(existRefreshToken);

            await _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(200);
        }

        public Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var client = _clients.SingleOrDefault(x => x.Id == clientLoginDto.ClientId && x.Secret == clientLoginDto.ClientSecret);

            if (client == null)
            {
                return Response<ClientTokenDto>.Fail("ClientId or ClientSecret not found", 404, true);
            }

            var token = _tokenService.CreateTokenByClient(client);

            return Response<ClientTokenDto>.Success(token, 200);
        }

        public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            //if (!await _roleManager.RoleExistsAsync("Employee"))
            //{
            //    var role = new Microsoft.AspNetCore.Identity.IdentityRole();
            //    role.Name = "Employee";
            //    await _roleManager.CreateAsync(role);
            //}

            var user = new UserApp { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);



            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<UserAppDto>.Fail(new ErrorDto(errors, true), 400);
            }
            await _userManager.AddToRoleAsync(user, "Employee");
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
            
        }

        public async Task<Response<UserAppDto>> CreateAdminUserAsync(CreateUserDto createUserDto)
        {
            //if (!await _roleManager.RoleExistsAsync("Employee"))
            //{
                var role = new Microsoft.AspNetCore.Identity.IdentityRole();
                role.Name = "Admin";
                await _roleManager.CreateAsync(role);
            //}

            var user = new UserApp { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);



            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<UserAppDto>.Fail(new ErrorDto(errors, true), 400);
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);

        }


        public async Task<Response<List<string>>> GetAllUserAsync()
        {

            //var result = await _userManager.GetUserAsync(null);
            var result = await _userManager.Users.Select(u => u.UserName).ToListAsync();
            //var result = _userManager.Users.Include(u => u.Id).ThenInclude(ur => ur.).ToList();
            //var result = await _userManager.GetUsersInRoleAsync("Employee");
            /*Claim claim = new Claim("","");
            var result = await _userManager.GetUsersForClaimAsync(claim);*/
            //return Response<AspUserDto>.Success(_mapper.Map<AspUserDto>(result), 200);

            //return Response<AspUserDto>.Success(ObjectMapper.Mapper.Map<AspUserDto>(result), 200);
            return  Response<List<string>>.Success(result, 200);
            //return Response<AspUserDto>.Success(ObjectMapper.Mapper.Map<AspUserDto>(result), 200);
        }

        public async Task<Response<UserAppDto>> GetByIdUserAsync(UserAppDto UserAppDto)
        {
            var user = new UserApp { Id = UserAppDto.Id };

            //var result = await _userManager.GetUserIdAsync(user);
            //var roleResult = await _userManager.GetRolesAsync(user);
            var result = await _userManager.FindByIdAsync(user.Id);
             

            //var result = await _userManager.Users.Select(u => u.Id == id.ToString()).ToListAsync();
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(result), 200);
            //return Response<AspUserDto>.Success(ObjectMapper.Mapper.Map<AspUserDto>(result), 200);
        }

        public async Task<Response<UserAppDto>> GetByIdUserRoleAsync(UserAppDto UserAppDto)
        {
            var user = new UserApp { Id = UserAppDto.Id };

            var roleResult = await _userManager.GetRolesAsync(user);
            UserAppDto.RolName = roleResult[0];

            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(UserAppDto), 200);
        }

        //public async Task<Response<UserAppDto>> RoleAssign(string id)
        //{
        //    /*//TempData["userId"] = id;
        //    UserApp user =  _userManager.FindByIdAsync(id).Result;
        //    List<AppRole> allRoles = _roleManager1.Roles.ToList();
        //    List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
        //    IQueryable<AppRole> roles = _roleManager1.Roles;

        //    List<string> userroles = _userManager.GetRolesAsync(user).Result as List<string>;

        //    foreach (var role in roles)
        //    {
        //        IdentityUserRole<string> rolTmp = new IdentityUserRole<string>();
        //        rolTmp.RoleId = role.Id.ToString();

        //        if (userroles.Contains(role.Name))
        //        {
        //            rolTmp.Exist = true;
        //        }
        //        else
        //        {
        //            r.Exist = false;
        //        }
        //    }*/

        //    return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(""), 200);

        //}

        //public Task<Response<UserAppDto>> RoleAssing(string id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
