using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.RequestModels.Ticket
{
    public class DeleteTicketCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
