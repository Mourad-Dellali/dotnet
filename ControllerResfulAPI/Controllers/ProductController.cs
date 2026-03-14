using ControllerResfulAPI.Data;
using ControllerResfulAPI.models;
using ControllerResfulAPI.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ControllerResfulAPI.Controllers;

[ApiController]
[Route("/api/products")]

public class ProductController(ProductRepository repository): ControllerBase
{
    [HttpOptions]
    public IActionResult OptionsProducts()
    {
        Response.Headers.Append("Allow","GET, HEAD, POST, PUT, PATCH, DELETE, OPTIONS");
        return NoContent();
    }

    [HttpHead("{productId:guid}")]
    public IActionResult HeadProduct(Guid productId)
    {
        return repository.ExistsById(productId) ? Ok() : NotFound();
    }
    [HttpGet]
    public IActionResult GetPaged(int page=1, int pageSize=10)
    {
        page= Math.Max(1,page);
        pageSize=Math.Clamp(pageSize,1,100);
        int totalCount=repository.GetProductCount();
        var products=repository.GetProductsPage(page,pageSize);
        var PagedResult = PagedResult<ProductResponse>.Create(
            ProductResponse.FromModels(products),
            totalCount,
            page,
            pageSize
        );
        return Ok(PagedResult);
    }
    [HttpGet("{productId:guid}", Name= "GetProductById")]
    public ActionResult<ProductResponse> GetProductById(Guid productId, bool includeReviews= false)
    {
        var product=repository.GetProductById(productId);

        if (product is null)
            return NotFound();
        
        List<ProductReview> reviews=null;
        if (includeReviews)
        {
            reviews= repository.GetProductReviews(productId);
        }

        return ProductResponse.FromModel(product,reviews);
    }
}