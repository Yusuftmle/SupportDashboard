using MediatR;

namespace Application.Queries.SLAs
{
    public class GetSLAByIdQuery : IRequest<SLADto?>
    {
        public Guid Id { get; set; }
    }
}
