using Leads.Domain.Interfaces.Repositories;
using Leads.Domain.Entities;
using Leads.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infra.Repositories
{
    public class LeadRepository(AppDbContext context) : Repository<Lead>(context), ILeadRepository
    {
        public async Task<bool> ExistLeadAsync(string email, string cpf)
        {
            return await _context.Agents
                .AnyAsync(a => a.Email == email || a.CPF == cpf);
        }
    }
}
