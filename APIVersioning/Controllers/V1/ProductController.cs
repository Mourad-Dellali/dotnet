using APIVersioning.Data;
using APIVersioning.Model;
using APIVersioning.Response.V1;
using Microsoft.AspNetCore.Mvc;

namespace APIVersioning.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/products")]
[Route("api/v{version:apiVersion}/products")]
public class ProductController(ProductRepository repository) : ControllerBase
{
    [HttpGet("{productId}")]
    public ActionResult<ProductResponse> GetProduct(Guid productId)
    {

        Response.Headers["Deprecation"] = "true";
        Response.Headers["Sunset"] = "Wed, 31 Jun 2025 23:59:59";
        Response.Headers["Link"] = "</api/v2/products>; rel=\"successor-version\"";
        var product = repository.GetProductById(productId);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(ProductResponse.FromModel(product));
    }
    
}