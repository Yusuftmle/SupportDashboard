using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Enums;
using Infrastructure.Persistence.Repositories;
using MediatR;

namespace Application.RequestModels.Ticket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTicketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket(
                request.Ticket.Title,
                request.Ticket.Description,
                request.Ticket.CreatedById
            );

            if (Enum.TryParse<PriorityStatus>(request.Ticket.Priority, out var priority))
                ticket.GetType().GetProperty("Priority")?.SetValue(ticket, priority);

            if (!string.IsNullOrEmpty(request.Ticket.Category))
                ticket.GetType().GetProperty("Category")?.SetValue(ticket, request.Ticket.Category);

            if (request.Ticket.DueDate.HasValue)
                ticket.GetType().GetProperty("DueDate")?.SetValue(ticket, request.Ticket.DueDate);

            await _unitOfWork.TicketRepository.AddAsync(ticket);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            // Create ticket event
            var ticketEvent = new TicketEvent(ticket.Id, TicketEventType.Created, "Ticket created");
            ticketEvent.SetUser(request.Ticket.CreatedById);
            await _unitOfWork.TicketEventRepository.AddAsync(ticketEvent);
            await _unitOfWork.CommitAsync(cancellationToken);

            return ticket.Id;
        }
    }

}
