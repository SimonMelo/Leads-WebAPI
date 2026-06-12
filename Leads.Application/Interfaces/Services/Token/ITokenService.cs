namespace Leads.Application.Interfaces.Services.Token
{
    public interface ITokenService
    {
        string GenerateToken(Leads.Domain.Entities.Agent agent);
    }
}