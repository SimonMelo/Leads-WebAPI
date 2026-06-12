using Leads.Domain.Interfaces.Repositories;
using Leads.Domain.Entities;

namespace Leads.Domain.Interfaces.Repositories
{
    public interface ILeadRepository : IRepository<Lead>
    {
        Task<bool> ExistLeadAsync(string email, string cpf);
    }
}
