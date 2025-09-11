using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Customer;
using Application.Repositories.Interfaces;
using MediatR;

namespace Application.Queries.Customers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.AsQueryable()
                .AsNoTracking()
                .Where(c => c.Id == request.Id && !c.IsDeleted)
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    CompanyName = c.CompanyName,
                    ContactPerson = c.ContactPerson,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address,
                    Tier = c.Tier.ToString(),
                    IsActive = c.IsActive,
                    CreateDate = c.CreateDate,
                    TicketCount = c.Tickets.Count(t => !t.IsDeleted)
                })
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
