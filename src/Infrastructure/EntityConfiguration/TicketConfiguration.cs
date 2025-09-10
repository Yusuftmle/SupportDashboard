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
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(t => t.Status)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(t => t.Priority)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(t => t.CreatedById)
                .IsRequired();

            builder.Property(t => t.AssignedToId);

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .IsRequired();

            builder.Property(t => t.ResolutionNotes)
                .HasMaxLength(2000);

            builder.Property(t => t.ResolvedDate);

            builder.Property(t => t.DueDate);

            builder.Property(t => t.Category)
                .HasMaxLength(100);

            builder.Property(t => t.CustomerSatisfactionRating);
            builder.Property(t => t.AIGeneratedSummary);

            builder.Property(t => t.SentimentScore)
                .HasPrecision(5, 2); // -1.00 to 1.00

            builder.Property(t => t.UrgencyScoreAI)
                .HasPrecision(5, 2); // 0.00 to 1.00

            builder.Property(t => t.AIConfidenceLevel)
                .HasPrecision(5, 2); // 0.00 to 1.00

            builder.Property(t => t.SuggestedCategory)
                .HasMaxLength(200);

            // Indexes for AI fields
           

            // Navigation properties
            builder.HasOne(t => t.CreatedBy)
                .WithMany(u => u.TicketsCreated)
                .HasForeignKey(t => t.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.AssignedTo)
                .WithMany(u => u.TicketsAssigned)
                .HasForeignKey(t => t.AssignedToId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(t => t.Events)
                .WithOne(e => e.Ticket)
                .HasForeignKey(e => e.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            // Index'ler
            builder.HasIndex(t => t.Status);
            builder.HasIndex(t => t.Priority);
            builder.HasIndex(t => t.CreatedById);
            builder.HasIndex(t => t.AssignedToId);
            builder.HasIndex(t => t.CreateDate);
            builder.HasIndex(t => t.SentimentScore);
            builder.HasIndex(t => t.UrgencyScoreAI);
            builder.HasIndex(t => new { t.SuggestedCategory, t.AIConfidenceLevel });
        }
    }
}
