using Leads.Domain.Entities;

namespace Leads.Application.Interfaces.Repositories
{
    public interface ILeadRepository : IRepository<Lead>
    {
        Task<bool> ExistLeadAsync(string email, string cpf);
    }
}
