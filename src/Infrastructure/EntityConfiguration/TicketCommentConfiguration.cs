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
    public class TicketCommentConfiguration : BaseEntityConfiguration<TicketComment>
    {
        public override void Configure(EntityTypeBuilder<TicketComment> builder)
        {
            base.Configure(builder);

            builder.Property(tc => tc.TicketId)
                .IsRequired();

            builder.Property(tc => tc.UserId)
                .IsRequired();

            builder.Property(tc => tc.Content)
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(tc => tc.IsInternal)
                .IsRequired();

            builder.Property(tc => tc.IsPublic)
                .IsRequired();
            builder.Property(tc => tc.IsAIGenerated)
               .HasDefaultValue(false);

            builder.Property(tc => tc.SentimentScore)
                .HasPrecision(5, 2);

            builder.Property(tc => tc.IntentClassification)
                .HasMaxLength(200);

            // Navigation properties
            builder.HasOne(tc => tc.Ticket)
                .WithMany()
                .HasForeignKey(tc => tc.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tc => tc.User)
                .WithMany()
                .HasForeignKey(tc => tc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Index'ler
            builder.HasIndex(tc => tc.TicketId);
            builder.HasIndex(tc => tc.UserId);
            builder.HasIndex(tc => tc.CreateDate);
            builder.HasIndex(tc => tc.IsAIGenerated);
            builder.HasIndex(tc => tc.SentimentScore);
            builder.HasIndex(tc => tc.IntentClassification);
        }
    }
}
