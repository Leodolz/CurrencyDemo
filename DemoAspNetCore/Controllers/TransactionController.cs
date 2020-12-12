using DemoAspNetCore.DAL;
using DemoAspNetCore.DBControllers;
using DemoAspNetCore.Models;
using DemoAspNetCore.Services;
using DemoAspNetCore.Validator;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class TransactionController : Controller
    {
        private IValidator currencyCodeValidator = new CurrencyCodeValidator();
        private Dictionary<string, ISpecificCurrencyService> SpecificServices = new Dictionary<string, ISpecificCurrencyService>
        {
            { "USD", new DollarCurrencyService() },
            { "BRL", new RealBrCurrencyService() }
        };
        private TransactionDbController transactionDbController = new TransactionDbController();
        // GET: api/<TransactionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "This is reserved for future use";
        }

        // POST api/transaction
        [HttpPost]
        public async Task<decimal> Post(object transaction)
        {
            JObject jTransaction = transaction as JObject;
            Transaction recievedTransaction = jTransaction.ToObject<Transaction>();
            string currencyCode = recievedTransaction.CurrencyCode;
            if (!currencyCodeValidator.Validate(currencyCode))
                return 0m;
            
            transactionDbController.AddTransaction(recievedTransaction);
            ISpecificCurrencyService currencyService = SpecificServices[currencyCode];
            CurrencyExchange currencyExchange =  await currencyService.GetCurrency();

            return (decimal)recievedTransaction.Amount / currencyExchange.BuyingRate;

        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
