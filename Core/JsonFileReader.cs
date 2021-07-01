using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SalesTaxCalculator.Model;
using System.Collections.Generic;
using System.IO;

namespace SalesTaxCalculator.FileReader
{
    public class JsonFileReader : IFileReader
    {
        private readonly ILogger<JsonFileReader> _logger;
        private readonly IConfiguration _configuration;

        public JsonFileReader(ILogger<JsonFileReader> logger , IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public List<TaxData> GetDataFromFile()
        {
            // Read path from configuration
            var filePath = _configuration["FilePath"];
            List<TaxData> taxData = null;
            try
            {
                string jsonString = System.IO.File.ReadAllText(filePath);
                _logger.LogInformation("Successfully read the JSON file");
                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                taxData = JsonConvert.DeserializeObject<List<TaxData>>(jsonString, serializerSettings);
            }
            catch (FileNotFoundException e)
            {
                _logger.LogError("File Not available" + e.FileName);
            }
            return taxData;
        }
    }
}
