using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IService<Company> _companyService;

        public CompaniesController(IService<Company> service)
        {
            _companyService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyService.GetAllAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyService.GetByIdAsync(id);

            return Ok(company);
        }


        [HttpPost]
        public async Task<IActionResult> Save(Company company)
        {
            var newCompany = await _companyService.AddAsync(company);
            return Ok(newCompany);
        }


        [HttpPut]
        public IActionResult Update(Company company)
        {
            var updateCompany = _companyService.Update(company);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var company = _companyService.GetByIdAsync(id).Result;

            _companyService.Remove(company);
            return NoContent();
        }

    }
}
