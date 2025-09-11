using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.RequestModels.Ticket.AssignTicket
{
    public class CloseTicketCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string? ResolutionNotes { get; set; }
        public int? SatisfactionRating { get; set; }
    }
}
