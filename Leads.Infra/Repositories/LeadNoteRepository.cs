using Leads.Domain.Interfaces.Repositories;
using Leads.Domain.Entities;
using Leads.Infra.Persistence;

namespace Leads.Infra.Repositories
{
    public class LeadNoteRepository(AppDbContext context) : Repository<LeadNote>(context), ILeadNoteRepository
    {
    }
}
