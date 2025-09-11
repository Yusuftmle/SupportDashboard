using Application.DTOs.NotificationSettings;
using MediatR;

namespace Application.Queries.NotificationSettingss
{
    public class GetNotificationSettingsByIdQuery : IRequest<NotificationSettingsDto?>
    {
        public Guid Id { get; set; }
    }
}
