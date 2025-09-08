using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class BlazorTicketContext: DbContext
    {
        public const String DEFAULT_SCHEMA = "dbo";


        public BlazorTicketContext(DbContextOptions<BlazorTicketContext> options) : base(options)
        {
        }

        // DbSet'ler
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCreatedEvent> TicketEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Soft delete için global query filter
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var isDeletedProperty = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
                    var filter = Expression.Lambda(Expression.Equal(isDeletedProperty, Expression.Constant(false)), parameter);
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
                }
            }
        }

        // SaveChanges override'ları aynı kalabilir
        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            var addedEntities = ChangeTracker.Entries()
                                           .Where(i => i.State == EntityState.Added)
                                           .Select(i => (BaseEntity)i.Entity);
            PrepareAddedEntities(addedEntities);
        }

        private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.CreateDate == DateTime.MinValue)
                    entity.CreateDate = DateTime.Now;
            }
        }

    }
}
