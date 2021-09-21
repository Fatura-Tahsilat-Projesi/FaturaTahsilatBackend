using MicrosoftOrnekBackendUyg.Common.DTOs;
using MicrosoftOrnekBackendUyg.Core.DTOs;
using MicrosoftOrnekBackendUyg.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Services
{
    public interface IAuthService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);

        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);

        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);

        Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);

        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<UserAppDto>> GetAllUserAsync();
        Task<Response<UserAppDto>> GetByIdUserAsync(UserAppDto userAppDto);
        Task<Response<UserAppDto>> GetByIdUserRoleAsync(UserAppDto userAppDto);
    }
}
