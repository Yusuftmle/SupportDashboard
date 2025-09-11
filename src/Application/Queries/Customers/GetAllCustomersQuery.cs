using MediatR;

namespace Application.Queries.Customers
{
    public class GetAll : IRequest<List<CustomerDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
