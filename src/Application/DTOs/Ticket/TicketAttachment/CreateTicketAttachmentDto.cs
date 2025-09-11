using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Ticket.TicketAttachment
{
    public class CreateTicketAttachmentDto
    {
        public Guid TicketId { get; set; }
        public Guid? CommentId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public Guid UploadedById { get; set; }
    }
}
