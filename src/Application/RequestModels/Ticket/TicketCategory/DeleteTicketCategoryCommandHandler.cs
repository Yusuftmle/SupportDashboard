using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Ticket.TicketCategory
{
    public class DeleteTicketCategoryCommandHandler : IRequestHandler<DeleteTicketCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTicketCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTicketCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.TicketCategoryRepository.GetByIdAsync(request.Id);
            if (category == null || category.IsDeleted) return false;

            // Check if category has active tickets
            var hasActiveTickets = category.Tickets.Any(t => !t.IsDeleted && t.Status != TicketStatus.Closed);
            if (hasActiveTickets)
                return false; // Cannot delete category with active tickets

            // Soft delete
            category.IsDeleted = true;
            _unitOfWork.TicketCategoryRepository.Update(category);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
