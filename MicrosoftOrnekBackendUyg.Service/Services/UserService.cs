using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Repositories;
using MicrosoftOrnekBackendUyg.Core.Services;
using MicrosoftOrnekBackendUyg.Core.UnitOfWorks;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Service.Services
{
    public class UserService : Service<CustomUser>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IRepository<CustomUser> repository, ILogger<CustomUser> logger) : base(unitOfWork, repository, logger)
        {

        }

        public async Task<CustomUser> Authenticate(int id)
        {
            return await _unitOfWork.UserRepository.Authenticate(id);
        }

        public  string CreateTokenAsync(TokenDescriptor descriptor)
        {
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(descriptor.Claims),
            //    Expires = descriptor.ExpiresValue,
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(descriptor.Secret)), SecurityAlgorithms.HmacSha256)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //string a = tokenHandler.WriteToken(token);
            return  _unitOfWork.UserRepository.CreateTokenAsync(descriptor);
        }

        //public async Task<User> ValidateUserAsync(User request)
        //{

        //    if (String.IsNullOrEmpty(request.UserName) || String.IsNullOrEmpty(request.Password) || request.RequestInfo.ApplicationId <= 0)
        //    {
        //        //throw new BusinessException(ResponseCode.UserNameOrUserPasswordNotNull);
        //        throw new NotImplementedException();
        //    }

        //    var user = await uow.User.ValidateUser(request.UserName, password: request.Password, appId: request.RequestInfo.ApplicationId);

        //    var accessToken = await this.CreateAccessToken(user);

        //    //var result = Imapper.Map<ValidateUserResponseDTO>(user);
        //    var result = user;

        //    result.Token = accessToken.Token;
        //    result.RefreshToken = accessToken.RefreshToken;
        //    result.TokenExpireDate = accessToken.Expiration;

        //    return result;
        //}


        //private async Task<User> CreateAccessToken(User user)
        //{
        //    //var accessToken = tokenHandler.CreateAccessToken(user);

        //    //var usertkn = uow.UserToken.GetUserTokenByUserId(user.Id);

        //    //if (usertkn != null)
        //    //{
        //    //    uow.UserToken.DeleteUserToken(usertkn);
        //    //}

        //    //UserToken userToken = new UserToken(user.Id, accessToken.RefreshToken, accessToken.Expiration.AddMinutes(tokenOpt.RefreshTokenExpiration));
        //    //await uow.UserToken.InsertAsync(userToken);
        //    //uow.Complete();

        //    //return accessToken;
        //    throw new NotImplementedException();
        //}

    }
}
