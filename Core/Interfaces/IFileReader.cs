using SalesTaxCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTaxCalculator.FileReader
{
    /// <summary>
    /// // Interface for FileReader , it can be used if we are planning to use ExcelReader , CSVReader or any DBReader
    /// </summary>
    public interface IFileReader
    {
        List<TaxData> GetDataFromFile();
    }
}
