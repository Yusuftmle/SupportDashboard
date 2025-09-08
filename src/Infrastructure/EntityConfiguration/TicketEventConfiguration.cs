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

            builder.Property(te => te.TicketId)
                .IsRequired();

            builder.Property(te => te.EventType)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(te => te.EventData)
                .HasMaxLength(2000);

            builder.Property(te => te.UserId);

            builder.Property(te => te.OldValue)
                .HasMaxLength(500);

            builder.Property(te => te.NewValue)
                .HasMaxLength(500);

            builder.Property(te => te.Comment)
                .HasMaxLength(1000);

            // Navigation properties
            builder.HasOne(te => te.Ticket)
                .WithMany(t => t.Events)
                .HasForeignKey(te => te.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(te => te.User)
                .WithMany()
                .HasForeignKey(te => te.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Index'ler
            builder.HasIndex(te => te.TicketId);
            builder.HasIndex(te => te.EventType);
            builder.HasIndex(te => te.CreateDate);
        }
    }
}
