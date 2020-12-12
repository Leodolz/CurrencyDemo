using DemoAspNetCore.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAspNetCore.Validator
{
    public class CurrencyCodeValidator: IValidator
    {
        private IEnumerable<string> CurrencyCodeList = CurrencyConstants.CurrencyCodesList;
        private string ErrorMessage = "";
        
        public bool Validate(string currencyCode)
        {
            bool result = CurrencyCodeList.Contains(currencyCode);
            if (!result)
                ErrorMessage = "Invalid currency code, please use other one";
            return result;
        }

        public string GetMessage()
        {
            return ErrorMessage;
        }
    }
}
