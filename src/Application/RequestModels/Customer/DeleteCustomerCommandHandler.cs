using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Customer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
            if (customer == null || customer.IsDeleted) return false;

            // Check if customer has active tickets
            var hasActiveTickets = customer.Tickets.Any(t => !t.IsDeleted && t.Status != TicketStatus.Closed);
            if (hasActiveTickets)
                return false; // Cannot delete customer with active tickets

            // Soft delete
            customer.IsDeleted = true;
            _unitOfWork.CustomerRepository.Update(customer);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
