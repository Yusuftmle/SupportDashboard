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
    public class AIExecutionLogConfiguration : BaseEntityConfiguration<AIExecutionLog>
    {
        public override void Configure(EntityTypeBuilder<AIExecutionLog> builder)
        {
            base.Configure(builder);

            // Table name
            builder.ToTable("AIExecutionLogs");

            // Properties
            builder.Property(ael => ael.WorkflowName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(ael => ael.StepName)
                .HasMaxLength(200);

            builder.Property(ael => ael.InputData);

            builder.Property(ael => ael.OutputData);

            builder.Property(ael => ael.ExecutionTimeMs)
                .HasDefaultValue(0);

            builder.Property(ael => ael.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ael => ael.ErrorMessage)
                .HasMaxLength(2000);

            builder.Property(ael => ael.TicketId);

            // Navigation properties
            builder.HasOne(ael => ael.Ticket)
                .WithMany()
                .HasForeignKey(ael => ael.TicketId)
                .OnDelete(DeleteBehavior.SetNull);

            // Indexes
            builder.HasIndex(ael => ael.TicketId);
            builder.HasIndex(ael => ael.WorkflowName);
            builder.HasIndex(ael => ael.Status);
            builder.HasIndex(ael => ael.CreateDate);
            builder.HasIndex(ael => new { ael.WorkflowName, ael.Status });
            builder.HasIndex(ael => new { ael.TicketId, ael.CreateDate });
        }
    }
}
