using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAspNetCore.Validator
{
    interface IValidator
    {
        bool Validate(string param);
        string GetMessage();
    }
}
