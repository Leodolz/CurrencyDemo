using DemoAspNetCore.Constant;
using DemoAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAspNetCore.Services
{
    public class RealBrCurrencyService : ISpecificCurrencyService
    {
        private CurrencyService currencyService = new CurrencyService();

        public async Task<CurrencyExchange> GetCurrency()
        {
            CurrencyExchange currencyExchange = await currencyService.GetCurrency(CurrencyConstants.DollarCurrencyUrl);
            currencyExchange.BuyingRate = currencyExchange.BuyingRate / 4.0m;
            currencyExchange.SellingRate = currencyExchange.SellingRate / 4.0m;
            return currencyExchange;
        }
    }
}
