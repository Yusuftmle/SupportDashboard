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
    public class ConversationHistoryConfiguration : BaseEntityConfiguration<ConversationHistory>
    {
        public override void Configure(EntityTypeBuilder<ConversationHistory> builder)
        {
            base.Configure(builder);

            // Table name
            builder.ToTable("ConversationHistories");

            // Properties
            builder.Property(ch => ch.SessionId)
                .IsRequired();

            builder.Property(ch => ch.Message)
                .IsRequired()
                .HasMaxLength(4000);

            builder.Property(ch => ch.IsFromUser)
                .IsRequired();

            builder.Property(ch => ch.TokenCount);

            builder.Property(ch => ch.PluginUsed)
                .HasMaxLength(100);

            builder.Property(ch => ch.UserId);

            // Navigation properties
            builder.HasOne(ch => ch.User)
                .WithMany()
                .HasForeignKey(ch => ch.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(ch => ch.SessionId);
            builder.HasIndex(ch => ch.UserId);
            builder.HasIndex(ch => ch.CreateDate);
            builder.HasIndex(ch => new { ch.SessionId, ch.CreateDate });
        }
    }
}
