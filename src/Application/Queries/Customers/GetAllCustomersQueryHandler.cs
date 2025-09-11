using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Customer;
using Application.Repositories.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.Queries.Customers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var query = _customerRepository.AsQueryable()
                .AsNoTracking()
                .Where(c => !c.IsDeleted);

            if (!string.IsNullOrEmpty(request.Tier) && Enum.TryParse<CustomerTier>(request.Tier, out var tier))
                query = query.Where(c => c.Tier == tier);

            if (request.IsActive.HasValue)
                query = query.Where(c => c.IsActive == request.IsActive.Value);

            var result = await query
                .OrderBy(c => c.CompanyName)
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
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
