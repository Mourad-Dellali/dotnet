using APIVersioning.Data;
using APIVersioning.Model;
using APIVersioning.Response.V2;
using Microsoft.AspNetCore.Mvc;

namespace APIVersioning.Controllers.V2;

[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductController(ProductRepository repository) : ControllerBase
{
    [HttpGet("{productId}")]
    public ActionResult<ProductResponse> GetProduct(Guid productId)
    {
        var product = repository.GetProductById(productId);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(ProductResponse.FromModel(product));
    }
    
}