using SalesTaxCalculator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTaxCalculator
{
    /// <summary>
    /// class for calculating State tax for a given price 
    /// </summary>
    public class StateTaxCalculator : ITaxCalculator
    {
        public static decimal NC_TAX = 4.75M;
        public decimal CalculateTax(decimal price, decimal tax)
        {
            decimal itemStateTaxRate = SalesTaxCalculatorHelper.RoundOff(price * NC_TAX / 100);
            return itemStateTaxRate;
        }
    }
}
