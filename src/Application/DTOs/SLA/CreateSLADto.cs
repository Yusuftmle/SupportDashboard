using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.SLA
{
    public class CreateSLADto
    {
        public string Name { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public int ResponseTimeHours { get; set; }
        public int ResolutionTimeHours { get; set; }
    }
}
