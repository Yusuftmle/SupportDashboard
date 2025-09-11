using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Department;
using MediatR;

namespace Application.RequestModels.Department
{
    public class CreateDepartmentCommand : IRequest<Guid>
    {
        public CreateDepartmentDto Department { get; set; }
    }
}
