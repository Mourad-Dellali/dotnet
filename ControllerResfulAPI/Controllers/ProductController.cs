using ControllerResfulAPI.Data;
using ControllerResfulAPI.models;
using ControllerResfulAPI.Requests;
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


    [HttpPost]
    public IActionResult CreateProduct(CreateProductRequest request)
    {
        if (repository.ExistsByName(request.Name))
        return Conflict($"A product with a similar Name already exists {request.Name}");
        
        var product = new Product
        {
          Id=Guid.NewGuid(),
          Name=request.Name,
          Price=request.Price  
        };
        repository.AddProduct(product);

        return CreatedAtRoute(routeName: nameof(GetProductById),
        routeValues: new {productId= product.Id},
        value: ProductResponse.FromModel(product));
    }

    [HttpPut("{productId:guid}")]
    public IActionResult Put(Guid productId, UpdateProductRequest request)
    {
        var product = repository.GetProductById(productId);
        if (product == null)
        return NotFound($"Product Not Found With Id {productId}");

        product.Name=request.Name;
        product.Price= request.Price;

        var succeeded= repository.UpdateProduct(product);

        if(!succeeded) 
        return StatusCode(500,"Failed to Update Product");

        return CreatedAtRoute(routeName:nameof(GetProductById),
        routeValues: new {productId=productId},
        value:ProductResponse.FromModel(product));

    }
}