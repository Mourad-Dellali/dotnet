using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RestFullAPIJwt.Requests;
using RestFullAPIJwt.Responses;

namespace RestFullAPIJwt.Services;

public class JwtTokenProvider(IConfiguration configuration)
{
    public TokenResponse GenerateJwtToken(GenerateTokenRequest request)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");

        var Issuer = jwtSettings["issuer"];
        var audience = jwtSettings["Audience"];
        var key = jwtSettings["SecretKey"];
        var expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["TokenExpirationInMinutes"]!));
        
        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Sub, request.Id!),
            new (JwtRegisteredClaimNames.Email, request.Email!),
            new (JwtRegisteredClaimNames.FamilyName, request.LastName!),
            new (JwtRegisteredClaimNames.GivenName, request.FirstName!),

        };

        foreach (var role in request.Roles)
            claims.Add(new(ClaimTypes.Role, role));

        foreach (var permission in request.Permissions)
            claims.Add(new("permission", permission));

        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expires,
            Issuer = Issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!)),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.CreateToken(descriptor);

        return new TokenResponse
        {
            AccessToken = tokenHandler.WriteToken(securityToken),
            RefreshToken = "7a6fd9e-8c3b-4c1a-9f0e-2b5d6c7e8f9a",
            Expires = expires
        };


        
    }
}