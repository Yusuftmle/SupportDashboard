using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.NotificationSettings
{
    public class UpdateNotificationSettingsDto
    {
        public bool IsEnabled { get; set; }
        public string Channel { get; set; } = string.Empty;
    }
}
