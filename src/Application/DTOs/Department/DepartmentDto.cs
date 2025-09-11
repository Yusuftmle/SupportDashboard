using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Department
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public Guid? ManagerId { get; set; }
        public string? ManagerName { get; set; } // Navigation
        public int UserCount { get; set; } // Navigation count
        public int CategoryCount { get; set; } // Navigation count
        public DateTime CreateDate { get; set; }
    }
}
