using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if (user == null || user.IsDeleted) return false;

            // Check if user has active tickets
            var hasActiveTickets = await _unitOfWork.TicketRepository.AsQueryable()
                .AnyAsync(t => !t.IsDeleted &&
                    (t.CreatedById == request.Id || t.AssignedToId == request.Id) &&
                    t.Status != TicketStatus.Closed);

            if (hasActiveTickets)
                return false; // Cannot delete user with active tickets

            // Soft delete
            user.IsDeleted = true;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
