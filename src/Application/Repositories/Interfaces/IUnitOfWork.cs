namespace Infrastructure.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        void Dispose();
        Task RollbackTransactionAsync();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}