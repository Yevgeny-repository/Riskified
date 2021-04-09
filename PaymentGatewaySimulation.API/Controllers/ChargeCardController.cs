using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using PaymentGatewaySimulation.BL;
using PaymentGatewaySimulation.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentGatewaySimulation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChargeCardController : ControllerBase
    {
        private IChargeCardService _chargeCardService;

        public ChargeCardController(IChargeCardService chargeCardService)
        {
            Ensure.That(chargeCardService, nameof(chargeCardService)).IsNotNull();
            _chargeCardService = chargeCardService;
        }

        // POST api/<ChargeCardController>
        [HttpPost]
        public async Task<IActionResult> Post([FromHeader(Name = "merchant-identifier")] string identifier, [FromBody] ChargeCardRequest request)
        {
            if (String.IsNullOrEmpty(identifier))
            {
                return BadRequest("no merchant identifier");
            }

            var response = await _chargeCardService.ChargeCard(identifier, request);

            return Ok();
        }
    }
}