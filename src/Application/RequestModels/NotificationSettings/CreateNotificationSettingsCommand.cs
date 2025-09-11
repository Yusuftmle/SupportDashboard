using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.NotificationSettings;
using MediatR;

namespace Application.RequestModels.NotificationSettings
{
    public class CreateNotificationSettingsCommand : IRequest<Guid>
    {
        public CreateNotificationSettingsDto Settings { get; set; }
    }
}
