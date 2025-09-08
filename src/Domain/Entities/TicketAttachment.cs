using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TicketAttachment
    {
        public Guid TicketId { get; private set; }
        public Guid? CommentId { get; private set; } // Hangi yoruma ait
        public string FileName { get; private set; } = string.Empty;
        public string FilePath { get; private set; } = string.Empty;
        public long FileSize { get; private set; }
        public string ContentType { get; private set; } = string.Empty;
        public Guid UploadedById { get; private set; }

        // Navigation
        public Ticket Ticket { get; private set; }
        public TicketComment? Comment { get; private set; }
        public User UploadedBy { get; private set; }
    }
}
