using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SalesTaxCalculator.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTaxCalculator.Helpers
{
    /// <summary>
    /// Helper class to provide  extension or helper functions
    /// </summary>
    public static class SalesTaxCalculatorHelper
    {
        public static decimal StringToDecimal(string value)
        {
           return Convert.ToDecimal(value, CultureInfo.InvariantCulture) + 0.00M; ;
        }

        public static decimal RoundOff(decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }



    }
}
