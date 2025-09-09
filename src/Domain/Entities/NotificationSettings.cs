using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class NotificationSettings : BaseEntity
    {
        public Guid UserId { get; private set; }
        public NotificationType Type { get; private set; }
        public bool IsEnabled { get; private set; } = true;
        public NotificationChannel Channel { get; private set; }

        // Navigation
        public User User { get; private set; }
    }
}
