using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Department;
using MediatR;

namespace Application.RequestModels.Department
{
    public class UpdateDepartmentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public UpdateDepartmentDto Department { get; set; }
    }
}
