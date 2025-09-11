using Application.DTOs.SLA;
using MediatR;

namespace Application.Queries.SLAs
{
    public class GetAll : IRequest<List<SLADto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
