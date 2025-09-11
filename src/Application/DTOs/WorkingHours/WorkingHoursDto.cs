using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.WorkingHours
{
    public class WorkingHoursDto
    {
        public Guid Id { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsWorkingDay { get; set; }
        public Guid? DepartmentId { get; set; }
        public DateTime CreateDate { get; set; }
        public string? DepartmentName { get; set; } // Navigation
    }
}
