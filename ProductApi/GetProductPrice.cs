using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public class ProductPriceFunction
{
    private readonly HttpClient _httpClient;

    public ProductPriceFunction(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [FunctionName("GetProductPrice")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "getProductPrice")] HttpRequest req,
        ILogger log)
    {
        try
        {
            // Get the URL of the product REST API from the query parameter
            string apiUrl = req.Query["url"];

            // Getting the data via REST API
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var productData = JsonConvert.DeserializeObject<ProductData>(await response.Content.ReadAsStringAsync());
                return new OkObjectResult(productData.Price);
            }
            else
            {
                return new StatusCodeResult((int)response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            log.LogError(ex, "An error occurred while fetching product price data.");
            return new StatusCodeResult(500);
        }
    }
}
