# Azure Function for Product Price Retrieval

This Azure Function receives a URL of a product REST API, calls that URL, and returns the price as an `int`.

## Usage

To use this Azure Function locally, run the application in Visual Studio or Visual Studio Code and make an HTTP GET request to the following endpoint:

http://localhost:7151/api/getProductPrice?url={product-api-url}


Replace `{product-api-url}` with the URL of the product REST API you want to retrieve the price from.

The function will return the product's price as an `int`.

## Deployment

Deploy this Azure Function to your Azure account using your preferred deployment method.

