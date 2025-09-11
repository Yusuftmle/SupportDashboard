using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.WorkingHours
{
    public class CreateWorkingHoursDto
    {
        public string DayOfWeek { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsWorkingDay { get; set; } = true;
        public Guid? DepartmentId { get; set; }
    }
}
