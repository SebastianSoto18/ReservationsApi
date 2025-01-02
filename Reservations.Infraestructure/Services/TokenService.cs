using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Reservations.Application.Services;
using Reservations.Domain.Models;

namespace Reservations.Infraestructure.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public string GenerateTokenAsync(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(userClaims),
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = credentials,
            Issuer = configuration["Jwt:Issuer"], 
            Audience = configuration["Jwt:Audience"]
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}