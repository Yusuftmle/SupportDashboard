using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Ticket
{
    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _unitOfWork.TicketRepository.GetByIdAsync(request.Id);
            if (ticket == null || ticket.IsDeleted) return false;

            // Soft delete
            ticket.IsDeleted = true;
            _unitOfWork.TicketRepository.Update(ticket);

            // Create deletion event
            var ticketEvent = new TicketEvent(ticket.Id, TicketEventType.Deleted, "Ticket deleted");
            await _unitOfWork.TicketEventRepository.AddAsync(ticketEvent);

            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
    }
}
