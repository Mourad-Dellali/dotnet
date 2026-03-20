using System.Runtime.Versioning;
using FluentValidation.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.Controllers;


[ApiController]
[Route("api/products")]

public class ProductController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(CreateProductRequest request)
    {
        return Created($"/api/products/{Guid.NewGuid()}", request);
    }
}