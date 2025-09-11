using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.RequestModels.WorkingHours
{
    public class DeleteWorkingHoursCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
