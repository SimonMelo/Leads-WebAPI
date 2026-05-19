using Leads.Application.Interfaces.Repositories;
using Leads.Domain.Entities.Base;
using Leads.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);
    
    public void Update(T entity)
        => _dbSet.Update(entity);

    public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        => _dbSet.AnyAsync(predicate, ct);

    public Task<bool> NotExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        => _dbSet.AnyAsync(predicate, ct).ContinueWith(t => !t.Result, ct);

    public void Remove(T entity)
        => _dbSet.Remove(entity);
}