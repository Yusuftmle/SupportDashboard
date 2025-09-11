using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.WorkingHours;
using MediatR;

namespace Application.RequestModels.WorkingHours
{
    public class CreateWorkingHoursCommand : IRequest<Guid>
    {
        public CreateWorkingHoursDto WorkingHours { get; set; }
    }
}
