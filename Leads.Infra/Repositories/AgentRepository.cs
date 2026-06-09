using Leads.Domain.Interfaces.Repositories;
using Leads.Domain.Entities;
using Leads.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infra.Repositories
{
    public class AgentRepository(AppDbContext context) : Repository<Agent>(context), IAgentRepository
    {
        public async Task<Agent?> ExistAgentAsync(string email, string creci)
            => await _context.Agents.FirstOrDefaultAsync(a => a.Email == email && a.CRECI == creci); 
    }
}
