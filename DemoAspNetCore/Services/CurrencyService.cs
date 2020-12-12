using DemoAspNetCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoAspNetCore.Services
{
    public class CurrencyService
    {
        public async Task<CurrencyExchange> GetCurrency(string CurrencyUrl)
        {
            CurrencyExchange deliveredCurrency;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(CurrencyUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    deliveredCurrency = TransformToCurrency(apiResponse);
                }
            }
            return deliveredCurrency;
        }

        private CurrencyExchange TransformToCurrency(string apiResponse)
        {
            string[] responseArray = JsonConvert.DeserializeObject<string[]>(apiResponse);
            decimal buyingRate = Convert.ToDecimal(responseArray[0], new CultureInfo("en-US"));
            decimal sellingRate = Convert.ToDecimal(responseArray[1], new CultureInfo("en-US"));
            string message = responseArray[2];

            return new CurrencyExchange(buyingRate, sellingRate, message);
        }
    }
}
