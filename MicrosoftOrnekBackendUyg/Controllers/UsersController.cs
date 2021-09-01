using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IService<User> _userService;
        public UsersController(IService<User> service)
        {
            _userService = service;
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
    }
}
