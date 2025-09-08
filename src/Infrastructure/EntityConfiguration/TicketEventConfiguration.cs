using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class TicketEventConfiguration : BaseEntityConfiguration<TicketEvent>
    {
        public override void Configure(EntityTypeBuilder<TicketEvent> builder)
        {
            base.Configure(builder);

            builder.Property(te => te.EventType)
                .HasConversion<string>() // Enum string olarak
                .IsRequired();

            builder.Property(te => te.EventData)
                .HasMaxLength(2000); // Opsiyonel JSON verisi

            builder.HasOne(te => te.Ticket)
                .WithMany(t => t.Events)
                .HasForeignKey(te => te.TicketId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
