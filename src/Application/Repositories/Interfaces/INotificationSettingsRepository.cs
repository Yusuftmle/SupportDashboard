using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;

namespace Application.Repositories.Interfaces
{
    public interface INotificationSettingsRepository : IGenericRepository<NotificationSettings>
    {
        Task<NotificationSettings> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<NotificationSettings>> GetEnabledNotificationsAsync();
    }
}
