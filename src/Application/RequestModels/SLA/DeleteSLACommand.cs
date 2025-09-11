using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.RequestModels.SLA
{
    public class DeleteSLACommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
