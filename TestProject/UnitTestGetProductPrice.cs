using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using ProductApi;

namespace TestProject
{
    [TestClass]
    public class UnitTestGetProductPrice
    {
        [TestMethod]
        public async Task GetProductPrice_Returns_Price()
        {
            // Arrange
           
            var context = new DefaultHttpContext().Request;
            var dictionary = new Dictionary<string, StringValues>();
            dictionary.Add("url", "https://backend.kronan.is/api/products/100253420");
            context.Query = new QueryCollection(dictionary)   ;


            // Act
            var result = await ProductPriceFunction.Run(context, null);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}