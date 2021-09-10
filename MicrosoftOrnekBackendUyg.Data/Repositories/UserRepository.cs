using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Data.Repositories
{
    class UserRepository: Repository<User>, IUserRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public  Task<User> Authenticate(int id)
        {
            //int id = 1;
            //return await _appDbContext.Users
            //return await appDbContext.Invoices.Include(x => x.InvoiceActivities).SingleOrDefaultAsync(x => x.InvoiceId == InvoiceId);
            ////return _appDbContext.Users.Include(a => a.Id).SingleOrDefaultAsync(a => a.Id == id);
            //throw new NotImplementedException();
            //var user = base.GetInclude((x =>
            //        x.UserName == username
            //        ), "UserApplications");

            //if (user == null)
            //{
            //    //throw new BusinessException(ResponseCode.UserNotFound);
            //    throw new NotImplementedException();
            //}

            //var _userApplications = _appDbContext.Users.Where(x => x.Id == appId);

            //if (!_userApplications.Any())
            //{
            //    //throw new BusinessException(ResponseCode.UserNotFound);
            //    throw new NotImplementedException();
            //}

            //if (HashHelper.GetDecryptedString(user.Password, user.PasswordSalt) != password)
            //    throw new NotImplementedException();
            //throw new BusinessException(ResponseCode.UserIsNotActive);

            throw new NotImplementedException();
        }

        public Task<User> GetWithInvoiceByIdAsync(int UserId)
        {
            throw new NotImplementedException();
        }

        public string CreateTokenAsync(TokenDescriptor descriptor)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(descriptor.Claims),
                Expires = descriptor.ExpiresValue,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(descriptor.Secret)), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //string a = tokenHandler.WriteToken(token);
            return tokenHandler.WriteToken(token);
        }
    }
}
