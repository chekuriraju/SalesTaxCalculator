using SalesTaxCalculator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTaxCalculator
{
     /// <summary>
     /// class for calculating County tax for a given price 
     /// </summary>
    public class CountyTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal price, decimal countyrate)
        {
            decimal itemCountyTaxRate = SalesTaxCalculatorHelper.RoundOff(price * countyrate / 100);
            return itemCountyTaxRate;
        }
    }
}
