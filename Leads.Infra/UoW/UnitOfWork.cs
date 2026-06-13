using Leads.Domain.Interfaces.Repositories;
using Leads.Infra.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace Leads.Infra.UoF;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    
    public async Task BeginTransactionAsync()
    {
        _transaction = await dbContext.Database.BeginTransactionAsync();
    }

    public async Task<int> CommitAsync()
    {
        return await dbContext.SaveChangesAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction is null)
            throw new InvalidOperationException("No active transaction.");
        
        await _transaction.CommitAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction is null)
            throw new InvalidOperationException("No active transaction.");
        
        await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        dbContext.Dispose();
    }
}