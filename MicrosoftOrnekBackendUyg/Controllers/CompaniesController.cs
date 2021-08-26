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


        [HttpPost]
        public async Task<IActionResult> Save(Company company)
        {
            var newCompany = await _companyService.AddAsync(company);
            return Ok(newCompany);
        }



    }
}
