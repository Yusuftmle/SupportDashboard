using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.NotificationSettings
{
    public class CreateNotificationSettingsDto
    {
        public Guid UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
        public string Channel { get; set; } = string.Empty;
    }
}
