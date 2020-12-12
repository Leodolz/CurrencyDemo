using DemoAspNetCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAspNetCore.Constant
{
    public static class CurrencyConstants
    {
        public static IEnumerable<string> CurrencyCodesList =
            new string[] { "USD",  "BRL"};

        public static string DollarCurrencyUrl = "http://www.bancoprovincia.com.ar/Principal/Dolar";

    }
}
