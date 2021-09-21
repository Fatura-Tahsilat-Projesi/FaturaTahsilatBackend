using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Services;
using MicrosoftOrnekBackendUyg.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly IService<CreditCards> _creditCardService;
        //private readonly RabbitMQPublisher _rabbitMQPublisher;

        public CreditCardsController(IService<CreditCards> service)
        {
            _creditCardService = service;
            //_rabbitMQPublisher = rabbitMQPublisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //_rabbitMQPublisher.Publish(new CreditCards() { Id = 1, Balance = 250, UserId = 1, CardNumber = "1111", CreditCardType = 1, CVC2 = 123, ExpMonth = 9, ExpYear = 3, CreatedAt = DateTime.ParseExact("01/09/2021 10:05:00", "dd/MM/yyyy HH:mm:ss", null) });
            var creditCards = await _creditCardService.GetAllAsync();
            return Ok(creditCards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var creditCard = await _creditCardService.GetByIdAsync(id);

            return Ok(creditCard);
        }


        [HttpPost]
        public async Task<IActionResult> Save(CreditCards creditCard)
        {
            var newcreditCard = await _creditCardService.AddAsync(creditCard);
            return Ok(newcreditCard);
        }


        [HttpPut]
        public IActionResult Update(CreditCards creditCard)
        {
            var updateCreditCard = _creditCardService.Update(creditCard);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var creditCard = _creditCardService.GetByIdAsync(id).Result;

            _creditCardService.Remove(creditCard);
            return NoContent();
        }

    }
}
