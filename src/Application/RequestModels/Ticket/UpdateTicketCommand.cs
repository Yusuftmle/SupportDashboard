using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Ticket;
using MediatR;

namespace Application.RequestModels.Ticket
{
    public class UpdateTicketCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
        public UpdateTicketDto? Ticket { get; set; }
    }
}
