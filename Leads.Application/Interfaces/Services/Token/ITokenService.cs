using Leads.Domain.Entities;

namespace Leads.Application.Interfaces.Services.Token
{
    public interface ITokenService
    {
        string GenerateToken(Agent agent);
    }
}
