using Application.DTOs.NotificationSettings;
using MediatR;

namespace Application.Queries.NotificationSettingss
{
    public class GetAll : IRequest<List<NotificationSettingsDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
