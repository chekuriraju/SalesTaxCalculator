using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTaxCalculator
{
    /// <summary>
    /// class for calculating Special tax for a given price 
    /// </summary>
    public class SpecialTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal price, decimal specialrate)
        {
            decimal itemSpecialTaxRate = price * specialrate / 100;
            return itemSpecialTaxRate;
        }
    }
}
