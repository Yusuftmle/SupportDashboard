using Application.DTOs.Customer;
using MediatR;

namespace Application.Queries.Customers
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto?>
    {
        public Guid Id { get; set; }
    }
}
