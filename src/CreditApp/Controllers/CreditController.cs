using CreditApp.Models;
using CreditApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly CreditService _creditService;

        private CreditController(CreditService creditService)
        {
            _creditService = creditService;
        }

        [HttpPost]
        public IActionResult GetData(Request request)
        {
            try
            {
                Details offer = _creditService.GetOffer(request);
                return Ok(offer);
            }catch
            {
                return BadRequest();
            }
        }
       

    }
}
