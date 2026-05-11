using Leads.Domain.Entities;

namespace Leads.Application.Interfaces.Repositories
{
    public interface IAgentRepository : IRepository<Agent>
    {
        Task<Agent?> ExistAgentAsync(string email, string creci);
    }
}
