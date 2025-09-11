using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.WorkingHours;
using MediatR;

namespace Application.RequestModels.WorkingHours
{

    public class UpdateWorkingHoursCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public UpdateWorkingHoursDto WorkingHours { get; set; }
    }
}
