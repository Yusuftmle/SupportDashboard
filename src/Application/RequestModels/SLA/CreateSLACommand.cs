using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.SLA;
using MediatR;

namespace Application.RequestModels.SLA
{
    public class CreateSLACommand : IRequest<Guid>
    {
        public CreateSLADto SLA { get; set; }
    }
}
