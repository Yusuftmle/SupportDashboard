using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly BlazorTicketContext _dbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(BlazorTicketContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    await _transaction.CommitAsync();
                }
                catch
                {
                    await RollbackTransactionAsync();
                    throw;
                }
                finally
                {
                    await DisposeTransactionAsync();
                }
            }
        }
        private async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync(); // Transaction'ı geri al
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _dbContext.Dispose();
        }
    }
}
