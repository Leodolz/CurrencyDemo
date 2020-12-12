using DemoAspNetCore.Models;
using DemoAspNetCore.Services;
using DemoAspNetCore.Validator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private IValidator currencyCodeValidator = new CurrencyCodeValidator();
        private Dictionary<string, ISpecificCurrencyService> SpecificServices = new Dictionary<string, ISpecificCurrencyService> 
        {
            { "USD", new DollarCurrencyService() },
            { "BRL", new RealBrCurrencyService() }
        };
        // GET: api/<CurrencyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Currency/5
        [HttpGet("code={code}")]
        public async Task<CurrencyExchange> Get(string code)
        {
            if (!currencyCodeValidator.Validate(code))
                return new CurrencyExchange(0, 0, currencyCodeValidator.GetMessage());
            ISpecificCurrencyService currencyService = SpecificServices[code];
            return await currencyService.GetCurrency();
        }

        // POST api/Currency
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Currency/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Currency/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
