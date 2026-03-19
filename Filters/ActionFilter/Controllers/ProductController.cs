using ActionFilter.Data.ProductRepository;
using ActionFilter.Filters.LogginFilter;
using ActionFilter.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilter.Controllers;


[ApiController]
[Route("api/products")]
[LoggingFilter]

public class ProductController(ProductRepository repository) : ControllerBase
{
    [HttpGet]
    
    public IActionResult GetProductPage(int pageNumber = 1, int pageSize = 10)
    {
        var products = repository.GetProductsPage(pageNumber, pageSize);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(Guid id)
    {
        var product = repository.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        repository.AddProduct(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }



}