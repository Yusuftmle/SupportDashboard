using MediatR;

namespace Application.Queries.WorkingHourss
{
    public class GetAll : IRequest<List<WorkingHoursDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
