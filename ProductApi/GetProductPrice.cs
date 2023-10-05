using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductApi
{
    public static class ProductPriceFunction
    {

        [FunctionName("GetProductPrice")]
        [OpenApiOperation(operationId: "GetProductPrice", tags: new[] { "price" })]
        [OpenApiParameter(name: "url", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The url of the Product Information API")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]

        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "getProductPrice")] HttpRequest req,
            ILogger log)
        {
            try
            {
                // Get the URL of the product REST API from the query parameter
                string apiUrl = req.Query["url"];

                var httpClient = new HttpClient();

                // Getting the data via REST API
                var response = await  httpClient.GetAsync(apiUrl);

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
}
