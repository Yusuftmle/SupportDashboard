using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class NotificationSettingsRepository : GenericRepository<NotificationSettings>, INotificationSettingsRepository
    {
        public NotificationSettingsRepository(BlazorTicketContext dbContext) : base(dbContext, dbContext.Set<NotificationSettings>())
        {
        }

        public async Task<NotificationSettings> GetByUserIdAsync(Guid userId)
        {
            return await FirstOrDefaultAsync(n => n.UserId == userId);
        }

        public async Task<IEnumerable<NotificationSettings>> GetEnabledNotificationsAsync()
        {
            return await GetList(n => n.IsEnabled);
        }
    }

}
