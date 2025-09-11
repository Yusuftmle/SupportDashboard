using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Ticket.TicketCategory;
using MediatR;

namespace Application.RequestModels.Ticket.TicketCategory
{
    public class UpdateTicketCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public UpdateTicketCategoryDto Category { get; set; }
    }
}
