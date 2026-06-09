using Leads.Domain.Entities.Base;
using System.Linq.Expressions;

namespace Leads.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(int id);

        Task<bool> NotExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
