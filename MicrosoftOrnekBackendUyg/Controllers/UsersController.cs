using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly IService<User> _userService;
        private readonly IUserService _userService;
        IConfiguration Configuration;
        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            this.Configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Save(User user)
        {
            var newUser = await _userService.AddAsync(user);
            return Ok(newUser);
        }

        [HttpPost("{login}")]
        public async Task<IActionResult> Login(int id)
        {
            var response = _userService.Authenticate(id);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetToken(Employee model)
        {
            string secretSection = Configuration.GetSection("AppSettings").GetSection("Secret").Value;

            string token = _userService.CreateTokenAsync(new TokenDescriptor
            {
                Claims = new Claim[]
                    {
                        new Claim("id", "1"),
                        new Claim("userName", "rwer"),
                        new Claim("password", model.Password),
                        new Claim("email", model.Email),
                        new Claim("country", "Türkiye")
                    },
                ExpiresValue = DateTime.UtcNow.AddMinutes(5),
                Secret = secretSection
            });
            return new JsonResult(new
            {
                Token = token
            });
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            var updateUser = _userService.Update(user);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var user = _userService.GetByIdAsync(id).Result;

            _userService.Remove(user);
            return NoContent();
        }

        //[HttpPost]
        //[Route("/ValidateUserAsync")]
        //public async Task<User> ValidateUserAsync(User request)
        //{
        //    return await _userService.ValidateUserAsync(request);
        //}
    }
}
