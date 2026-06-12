using Leads.Domain.Interfaces.Repositories;
using Leads.Domain.Entities;

namespace Leads.Domain.Interfaces.Repositories
{
    public interface IAgentRepository : IRepository<Agent>
    {
        Task<Agent?> ExistAgentAsync(string email, string creci);
    }
}
