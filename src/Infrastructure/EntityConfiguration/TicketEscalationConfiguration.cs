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
    public class TicketEscalationConfiguration : BaseEntityConfiguration<TicketEscalation>
    {
        public override void Configure(EntityTypeBuilder<TicketEscalation> builder)
        {
            base.Configure(builder);

            builder.Property(te => te.TicketId)
                .IsRequired();

            builder.Property(te => te.FromUserId)
                .IsRequired();

            builder.Property(te => te.ToUserId)
                .IsRequired();

            builder.Property(te => te.Reason)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(te => te.EscalatedDate)
                .IsRequired();

            builder.Property(te => te.Type)
                .HasConversion<string>()
                .IsRequired();

            // Navigation properties
            builder.HasOne(te => te.Ticket)
                .WithMany()
                .HasForeignKey(te => te.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(te => te.FromUser)
                .WithMany()
                .HasForeignKey(te => te.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(te => te.ToUser)
                .WithMany()
                .HasForeignKey(te => te.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Index'ler
            builder.HasIndex(te => te.TicketId);
            builder.HasIndex(te => te.EscalatedDate);
        }
    }
}
