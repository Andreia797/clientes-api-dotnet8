using ClientesApi.Configurations;
using ClientesApi.DTOs;
using ClientesApi.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClientesApi.Services;

public class AuthService : IAuthService
{
    private readonly JwtSettings _jwt;

    public AuthService(IOptions<JwtSettings> jwt)
    {
        _jwt = jwt.Value;
    }

    public string? Login(LoginRequest request)
    {
        if (request.Username != "admin" ||
            request.Password != "123456")
        {
            return null;
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, request.Username)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwt.SecretKey));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.ExpirationMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}