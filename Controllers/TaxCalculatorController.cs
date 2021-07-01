using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesTaxCalculator.Response;
using System;
using System.Linq;
using SalesTaxCalculator.FileReader;
using SalesTaxCalculator.Helpers;
using SalesTaxCalculator.Request;

namespace SalesTaxCalculator.Controllers
{
    /// <summary>
    /// TaxCalculator Controller responsible for GET/POST for managing Sales Tax Calculations 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ILogger<TaxCalculatorController> _logger;
        private readonly IFileReader _jsonreader;

        decimal totalPriceWithTaxes = 0.0M;
        decimal totalSalesTax = 0.0M;
        public TaxCalculatorController(ILogger<TaxCalculatorController> logger, IFileReader jsonreader)
        {
            _logger = logger;
            _jsonreader = jsonreader;
        }

        /// <summary>
        /// This API method is for calculating sales tax based on price and zipcode
        /// </summary>
        /// <param name="tcRequest"></param>
        /// <returns>Price wiith tax and Sales Tax</returns>
        [HttpGet("CalculateTax")]
        public ActionResult<TaxCalculatorResponse> CalculateTax([FromQuery] TaxCalculatorRequest tcRequest)
        {

            if (!ModelState.IsValid)
            {
                _logger.LogError("Bad Request Occured - Invalid Inputs");
                return BadRequest("Please provide valid inputs!");
            }


            var taxData = _jsonreader.GetDataFromFile();
            // check if zip code exists in tax data
            var taxDataAvailable = taxData.FirstOrDefault(d => d.ZipCode == tcRequest.ZipCode);

            if(taxDataAvailable==null)
            {
                _logger.LogInformation("Zip Code Not Available in Data Store");
                return NotFound("ZipCode is not available!");
            }


            var countyRate = SalesTaxCalculatorHelper.StringToDecimal(taxDataAvailable.CountyRate);
            var specialRate = SalesTaxCalculatorHelper.StringToDecimal(taxDataAvailable.SpecialRate);
 

            TaxCalculatorFactory factory = new TaxCalculatorFactory();
            // County Tax
            ITaxCalculator countyTaxCal = factory.GetTaxCalculator("CountyTax");
            var calculatedCountyTax = countyTaxCal.CalculateTax(tcRequest.Price, countyRate);
            // State Tax (Passing default value as NC tax is handled in StateTaxCalculator)
            ITaxCalculator stateTaxCal = factory.GetTaxCalculator("StateTax");
            var calculatedStateTax = stateTaxCal.CalculateTax(tcRequest.Price, 0.0M);
            // Special Tax
            ITaxCalculator specialTaxCal = factory.GetTaxCalculator("SpecialTax");
            var calculatedSpecialTax = specialTaxCal.CalculateTax(tcRequest.Price, specialRate);
            // Sales TAX 
            totalSalesTax = calculatedCountyTax + calculatedStateTax + calculatedSpecialTax;
            // add price with taxes 
            totalPriceWithTaxes = tcRequest.Price + totalSalesTax;

            return Ok(new TaxCalculatorResponse { PriceWithTax = Decimal.Round(totalPriceWithTaxes, 2), SalesTax = Decimal.Round(totalSalesTax, 2) });
        }




    }
}