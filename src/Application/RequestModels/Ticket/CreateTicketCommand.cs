using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Ticket;
using MediatR;

namespace Application.RequestModels.Ticket
{
    public class CreateTicketCommand : IRequest<Guid>
    {
        public CreateTicketDto Ticket { get; set; }
    }
}
