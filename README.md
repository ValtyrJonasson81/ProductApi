# Azure Function for Product Price Retrieval

This Azure Function receives a URL of a product REST API, calls that URL, and returns the price as an `int`.

## Usage

To use this Azure Function locally, run the application in Visual Studio or Visual Studio Code and make an HTTP GET request to the following endpoint:

http://{your-function-url]/api/getProductPrice?url={product-api-url}

Replace `{product-api-url}` with the URL of the product REST API you want to retrieve the price from.
Replace `{your-function-url}` with the URL of the service.


The function will return the product's price as an `int`.

## OpenAPI 

RenderOpenApiDocument: [GET] http://localhost:7151/api/openapi/{version}.{extension}

## Swagger

RenderSwaggerDocument: [GET] http://localhost:7151/api/swagger.{extension}
RenderSwaggerUI: [GET] http://localhost:7151/api/swagger/ui

## Deployment

Deploy this Azure Function to your Azure account using your preferred deployment method.

