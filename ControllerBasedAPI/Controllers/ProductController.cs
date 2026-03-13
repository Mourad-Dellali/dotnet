using Microsoft.AspNetCore.Mvc;

namespace ControllerBasedAPI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    [HttpGet("test")]
    public string Get()
    {
        return "Product #1, Price $2.99";
    }
}