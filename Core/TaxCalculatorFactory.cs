using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SalesTaxCalculator
{
    /// <summary>
    /// Abstract Factory for providing the required TaxCalculator based on type of Tax (CountyTax , StateTax , SpecialTax)
    /// </summary>
    public class TaxCalculatorFactory
    {
        private Dictionary<String, ITaxCalculator> taxCalculators;

        public TaxCalculatorFactory()
        {
            taxCalculators = new Dictionary<String, ITaxCalculator>();
            RegisterInFactory("CountyTax", new CountyTaxCalculator());
            RegisterInFactory("StateTax", new StateTaxCalculator());
            RegisterInFactory("SpecialTax", new SpecialTaxCalculator());
        }

        public void RegisterInFactory(string strategy, ITaxCalculator taxCalc)
        {
            taxCalculators.Add(strategy, taxCalc);
        }

        public ITaxCalculator GetTaxCalculator(String strategy)
        {
            ITaxCalculator taxCalc = (ITaxCalculator)taxCalculators[strategy];
            return taxCalc;
        }

    }
}
