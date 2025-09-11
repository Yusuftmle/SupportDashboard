using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Department
{
    public class UpdateDepartmentDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? ManagerId { get; set; }
        public bool IsActive { get; set; }
    }
}
