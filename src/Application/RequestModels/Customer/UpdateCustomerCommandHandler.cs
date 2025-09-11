using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Customer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
            if (customer == null || customer.IsDeleted) return false;

            // Update properties via reflection since they're private set
            var properties = typeof(Customer).GetProperties();

            if (!string.IsNullOrEmpty(request.Customer.ContactPerson))
                properties.FirstOrDefault(p => p.Name == "ContactPerson")?.SetValue(customer, request.Customer.ContactPerson);

            if (!string.IsNullOrEmpty(request.Customer.Email))
                properties.FirstOrDefault(p => p.Name == "Email")?.SetValue(customer, request.Customer.Email);

            properties.FirstOrDefault(p => p.Name == "PhoneNumber")?.SetValue(customer, request.Customer.PhoneNumber);
            properties.FirstOrDefault(p => p.Name == "Address")?.SetValue(customer, request.Customer.Address);
            properties.FirstOrDefault(p => p.Name == "IsActive")?.SetValue(customer, request.Customer.IsActive);

            if (Enum.TryParse<CustomerTier>(request.Customer.Tier, out var tier))
                properties.FirstOrDefault(p => p.Name == "Tier")?.SetValue(customer, tier);

            _unitOfWork.CustomerRepository.Update(customer);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
