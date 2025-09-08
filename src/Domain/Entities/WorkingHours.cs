using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class WorkingHours : BaseEntity
    {
        public DayOfWeek DayOfWeek { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        public bool IsWorkingDay { get; private set; } = true;
        public Guid? DepartmentId { get; private set; }

        // Navigation
        public Department? Department { get; private set; }
    }
}
