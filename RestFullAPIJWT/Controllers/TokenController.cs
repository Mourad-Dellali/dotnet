using Microsoft.AspNetCore.Mvc;
using RestFullAPIJwt.Permissions;
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

    [HttpPost("refresh")]
    public IActionResult RefreshToken(RefreshTokenRequest request)
    {
        var refreshTokenRecord =  new
        {
            UserId = "79410514-0136-4442-be9b-01f097c57f7a",
            RefreshToken = "7a6fd9e-8c3b-4c1a-9f0e-2b5d6c7e8f9a",
            Expires = DateTime.UtcNow.AddHours(12),
        };

        if (refreshTokenRecord.RefreshToken != request.RefreshToken || refreshTokenRecord.Expires < DateTime.UtcNow)
            return Unauthorized(new { Message = "Invalid or expired refresh token" });
        
        var generateTokenRequest = new GenerateTokenRequest
        {
            Id = refreshTokenRecord.UserId,
            Email = "pm@localhost",
            FirstName = "Manager",
            LastName = "Primary",
            Roles = new List<string> { "ProjectManager" },
            Permissions = new List<string>
            {
                Permission.Project.Create,
                Permission.Project.Read,
                Permission.Project.Update,
                Permission.Project.Delete,
                Permission.Project.AssignMember,
            }
        };

        return Ok(tokenProvider.GenerateJwtToken(generateTokenRequest));
    }
}