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
    public class TicketAttachmentConfiguration : BaseEntityConfiguration<TicketAttachment>
    {
        public void Configure(EntityTypeBuilder<TicketAttachment> builder)
        {
            // Primary key - sadece FileName ile ya da composite key
            builder.HasKey(ta => new { ta.TicketId, ta.FileName });

            builder.Property(ta => ta.TicketId)
                .IsRequired();

            builder.Property(ta => ta.CommentId);

            builder.Property(ta => ta.FileName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(ta => ta.FilePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(ta => ta.FileSize)
                .IsRequired();

            builder.Property(ta => ta.ContentType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ta => ta.UploadedById)
                .IsRequired();

            // Navigation properties
            builder.HasOne(ta => ta.Ticket)
                .WithMany()
                .HasForeignKey(ta => ta.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ta => ta.Comment)
                .WithMany()
                .HasForeignKey(ta => ta.CommentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ta => ta.UploadedBy)
                .WithMany()
                .HasForeignKey(ta => ta.UploadedById)
                .OnDelete(DeleteBehavior.Restrict);

            // Index'ler
            builder.HasIndex(ta => ta.TicketId);
            builder.HasIndex(ta => ta.CommentId);
            builder.HasIndex(ta => ta.UploadedById);
        }
    }

}
