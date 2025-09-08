using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class TicketConfiguration : BaseEntityConfiguration<Ticket>
    {
        public override void Configure(EntityTypeBuilder<Ticket> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Description)
                .IsRequired();

            builder.Property(t => t.Status)
                .HasConversion<string>() // Enum string olarak DB’ye
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .IsRequired();

            builder.HasOne(t => t.CreatedBy)
                .WithMany(u => u.TicketsCreated) // User entity’de collection name
                .HasForeignKey(t => t.CreatedById)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.AssignedTo)
                .WithMany(u => u.TicketsAssigned) // User entity’de collection name
                .HasForeignKey(t => t.AssignedToId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(t => t.Events)
                .WithOne(e => e.Ticket)
                .HasForeignKey(e => e.TicketId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
