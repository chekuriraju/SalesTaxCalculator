using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTaxCalculator
{

    /// <summary>
    /// Interface to Calculate Tax with input price and tax 
    /// </summary>
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal price, decimal tax);
    }
}
