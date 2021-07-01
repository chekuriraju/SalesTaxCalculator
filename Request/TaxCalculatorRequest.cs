using System.ComponentModel.DataAnnotations;

namespace SalesTaxCalculator.Request
{
    /// <summary>
    ///  API Request 
    /// </summary>
    public class TaxCalculatorRequest
    {
        /// <summary>
        /// Price of the Item / Product 
        /// </summary>
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }
        /// <summary>
        /// ZipCode at which the transaction / purchase has been made 
        /// </summary>
        [Required]
        public int ZipCode { get; set; }
    }
}
