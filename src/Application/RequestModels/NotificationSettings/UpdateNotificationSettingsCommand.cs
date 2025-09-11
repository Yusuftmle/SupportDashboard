using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.NotificationSettings;
using MediatR;

namespace Application.RequestModels.NotificationSettings
{
    public class UpdateNotificationSettingsCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public UpdateNotificationSettingsDto Settings { get; set; }
    }
}
