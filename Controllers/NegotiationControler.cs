using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using NegotiationApi.Models;
using NegotiationApi.Services.Interfaces;

namespace NegotiationApi.Controllers
{

    [ApiController]
    [Route("api/negotiations")]
    public class NegotiationController : ControllerBase
    {

        private readonly INegotiationServices _negotiationServices;


        public NegotiationController(INegotiationServices negotiationServices)
        {
            _negotiationServices = negotiationServices;
        }

        [HttpPost]
        public IActionResult ProposePrice([FromBody] Negotiation negotiation) 
        {
            try
            {
                var result = _negotiationServices.ProposePrice(negotiation);
                return Ok(result);
            }
            catch (ArgumentException ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult RespondToNegotiation(int id, [FromBody] bool accepted)
        {
            try
            {
                var result = _negotiationServices.RespondToNegotiation(id,accepted);
                if (result==null) return NotFound();
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
