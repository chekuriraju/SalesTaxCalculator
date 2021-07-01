namespace SalesTaxCalculator.Model
{
    /// <summary>
    /// TaxData Model class 
    /// </summary>
    public class TaxData
    {
        public int ZipCode { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string NormalizedCounty { get; set; }
        public string City { get; set; }
        public string NormalizedCity { get; set; }
        public string NormalizedTaxRegionName { get; set; }
        public string CombinedRate { get; set; }
        public string StateRate { get; set; }
        public string CountyRate { get; set; }
        public string CityRate { get; set; }
        public string SpecialRate { get; set; }
        public string EstimatedPopulation { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }

    }
}
