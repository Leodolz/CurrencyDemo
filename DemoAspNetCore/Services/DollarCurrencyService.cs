using DemoAspNetCore.Constant;
using DemoAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAspNetCore.Services
{
    public class DollarCurrencyService : ISpecificCurrencyService
    {
        private CurrencyService currencyService = new CurrencyService();
        public async Task<CurrencyExchange> GetCurrency()
        {
            return await currencyService.GetCurrency(CurrencyConstants.DollarCurrencyUrl);
        }
    }
}
