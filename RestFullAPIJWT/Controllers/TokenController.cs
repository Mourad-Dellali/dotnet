using Microsoft.AspNetCore.Mvc;
using RestFullAPIJwt.Requests;
using RestFullAPIJwt.Services;

namespace RestFullAPIJwt.Controllers;

[ApiController]
[Route("api/token")]

public class TokenController(JwtTokenProvider tokenProvider) : ControllerBase
{

    [HttpPost("generate")]
    public IActionResult GenerateToken(GenerateTokenRequest request)
    {
        return Ok(tokenProvider.GenerateJwtToken(request));
    }

}