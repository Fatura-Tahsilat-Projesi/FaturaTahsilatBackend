using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MicrosoftOrnekBackendUyg.Core.DTOs;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        //private readonly ILogger _logService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            //_logService = logService;
        }

        //api/auth/
        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            var result = await _authService.CreateTokenAsync(loginDto);
            //Serilog.Log.Error("Token oluşturuldu. Bilgiler => " + loginDto);
            //_logService.LogError("Token oluşturuldu. Bilgiler => "+loginDto);
            return Created(string.Empty, result);
            //!TODO geriye dönme düzeltilecek!
        }

        [HttpPost]
        public IActionResult CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var result = _authService.CreateTokenByClient(clientLoginDto);

            return Created(string.Empty, result);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _authService.RevokeRefreshToken(refreshTokenDto.Token);

            return Created(string.Empty, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)

        {
            var result = await _authService.CreateTokenByRefreshToken(refreshTokenDto.Token);

            return Created(string.Empty, result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return Created(string.Empty, await _authService.CreateUserAsync(createUserDto));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAdminUser(CreateUserDto createUserDto)
        {
            return Created(string.Empty, await _authService.CreateAdminUserAsync(createUserDto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleDto name)
        {
            return Created(string.Empty, await _authService.CreateRoleAsync(name));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUser(UserAppDto userAppDto)
        {
            //Serilog.Log.Information("Kullanıcı  Silindi. Bilgiler => | FaturaNu: " + invoices.InvoiceNu + " | FaturaIsim: " + invoices.Name + " | FaturaToplam: " + invoices.Total + " | FaturaToplamKDV: " + invoices.TotalVat + " | FaturaKDVsiz: " + invoices.ExcludingVat + " | SonOdemeTarihi:  " + invoices.DueDate + " | FaturaTipi: " + invoices.InvoiceType + " | DurumKodu: " + invoices.StatusCode + " | OdenmeDurumu: " + invoices.IsComplete + " | FirmaId: " + invoices.CompanyId + " | UserId: " + invoices.UserId + " | ");
            //return Ok(await _authService.RemoveUserAsync(userAppDto));
            await _authService.RemoveUserAsync(userAppDto);
            //TODO Başarıyla siliyor ama dto da geri dönerken birşey patlıyor düzeltilecek!
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _authService.GetAllUserAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _authService.GetRolesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> GetByIdUser(UserAppDto userAppDto)
        {
            return Ok(await _authService.GetByIdUserAsync(userAppDto));
        }

        [HttpPost]
        public async Task<IActionResult> GetByIdUserRole(UserAppDto userAppDto)
        {
            return Ok(await _authService.GetByIdUserRoleAsync(userAppDto));
        }

    }
}
