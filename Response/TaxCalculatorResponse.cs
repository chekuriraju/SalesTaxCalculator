namespace SalesTaxCalculator.Response
{
    /// <summary>
    /// API Response 
    /// </summary>
    public class TaxCalculatorResponse
    {
        /// <summary>
        ///  Total Sales Tax Calculated which will ideally be sum of County Tax + State Tax + City Tax + Special Tax 
        /// </summary>
        public decimal SalesTax { get; set; }
        /// <summary>
        /// Total Price of product / item including Sales Tax 
        /// </summary>
        public decimal PriceWithTax { get; set; }
    }
}
