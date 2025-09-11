using MediatR;

namespace Application.Queries.WorkingHourss
{
    public class GetWorkingHoursByIdQuery : IRequest<WorkingHoursDto?>
    {
        public Guid Id { get; set; }
    }
}
