using Leads.Application.Interfaces.Repositories;
using Leads.Domain.Entities;
using Leads.Infra.Persistence;

namespace Leads.Infra.Repositories
{
    public class AgentRepository(AppDbContext context) : Repository<Agent>(context), IAgentRepository
    {
    }
}
