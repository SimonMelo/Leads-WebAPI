using Leads.Domain.Interfaces.Repositories;
using Leads.Domain.Entities;
using Leads.Infra.Persistence;

namespace Leads.Infra.Repositories
{
    public class LeadSourceRepository(AppDbContext context) : Repository<LeadSource>(context), ILeadSourceRepository
    {
    }
}
