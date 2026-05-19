using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Leads.Application.Interfaces.Services.Token;
using Leads.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Leads.Application.Services.Auth;

public class TokenService()
    : ITokenService
{
    public string GenerateToken(Agent agent)
    {
        var key = Environment.GetEnvironmentVariable("JWT_KEY");

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(
            securityKey,
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(
                "Identifier",
                agent.Id.ToString()),

            new Claim(
                "Email",
                agent.Email),

            new Claim(
                "Name",
                agent.Name),

            new Claim(
                "CRECI",
                agent.CRECI),

            new Claim(
                "OfficeId",
                agent.OfficeId.ToString()),
            
        };

        var token = new JwtSecurityToken(
            issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
            audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}