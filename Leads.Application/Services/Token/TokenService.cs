using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Leads.Application.Interfaces.Services.Token;
using Leads.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Leads.Application.Services.Auth;

public class TokenService(IConfiguration configuration) : ITokenService
{

    public string GenerateToken(Agent agent)
    {
        var key = configuration["Jwt:Key"]!;

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(
            securityKey,
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("Identificador", agent.Id.ToString()),
            new Claim("Email", agent.Email),
            new Claim("Nome", agent.Name),
            new Claim("CRECI", agent.CRECI),
            new Claim("Role", agent.IsAdmin ? "Admin" : "Agent")
        };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}