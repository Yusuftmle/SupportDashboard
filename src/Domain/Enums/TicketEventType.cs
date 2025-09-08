using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum TicketEventType
    {
        Created = 1,
        StatusChanged = 2,
        AssigneeChanged = 3,
        PriorityChanged = 4,
        CommentAdded = 5,
        Resolved = 6,
        Reopened = 7
    }
}
