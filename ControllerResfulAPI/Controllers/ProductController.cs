using System.Text;
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
    [HttpDelete("{productId:guid}")]
    public IActionResult Delete(Guid productId)
    {
        var product = repository.GetProductById(productId);
        if (product == null)
        return NotFound("Product Doesn't Exists{productId}");

        var deletesucced= repository.DeleteProduct(product.Id);
        if (!deletesucced)
        return StatusCode(500,"Failed To Delete Product");

        return NoContent();
    }

    [HttpGet("csv")]
    public IActionResult GetProductCSV()
    {
        var products= repository.GetProductsPage(1,100);
        
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("Id,Name,Price");

        foreach (var p in products)
        {
            csvBuilder.AppendLine($"{p.Id},{p.Name},{p.Price}");
        }

        var fileBytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());

        return File(fileBytes,"Text/csv", "product-catalog_1-100.csv");
    }

    [HttpGet("physical-csv-file")]
    public IActionResult GetPhysicalFile()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(),"Files","product-catalog_1-100.csv");
        return PhysicalFile(filePath, "text/csv", "product-export.csv");
    }


    [HttpGet("products-legacy")]
    public IActionResult GetRedirect()
    {
        return Redirect("/api/products/temp-products");
    }

    [HttpGet("temp-products")]
    public IActionResult TempProduct()
    {
        return Ok(new
        {
            message = "You're in the temp endpoint. Chill."
        });
    }
    [HttpGet("legacy-product")]
    public IActionResult GetPermanentRedirect()
    {
        return RedirectPermanent("/api/products/product-catalog");
    }

    [HttpGet("product-catalog")]
    public IActionResult Catalog()
    {
        return Ok(new { message = "New Permanenet Location"});
    }
}