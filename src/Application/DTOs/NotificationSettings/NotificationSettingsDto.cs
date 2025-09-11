using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.NotificationSettings
{
    public class NotificationSettingsDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public bool IsEnabled { get; set; }
        public string Channel { get; set; } = string.Empty;
        public string UserFullName { get; set; } = string.Empty; // Navigation
        public DateTime CreateDate { get; set; }
    }
}
