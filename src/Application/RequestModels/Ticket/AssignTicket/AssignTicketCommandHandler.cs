using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Ticket.AssignTicket
{
    public class AssignTicketCommandHandler : IRequestHandler<AssignTicketCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssignTicketCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AssignTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _unitOfWork.TicketRepository.GetByIdAsync(request.Id);
            if (ticket == null || ticket.IsDeleted) return false;

            var oldAssignee = ticket.AssignedToId?.ToString();
            ticket.AssignTo(request.AgentId);

            _unitOfWork.TicketRepository.Update(ticket);

            // Create assignment event
            var ticketEvent = new TicketEvent(ticket.Id, TicketEventType.Assigned,
                $"Ticket assigned from {oldAssignee ?? "unassigned"} to {request.AgentId}");
            ticketEvent.SetUser(request.AgentId);
            ticketEvent.SetValueChange(oldAssignee, request.AgentId.ToString());

            await _unitOfWork.TicketEventRepository.AddAsync(ticketEvent);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
