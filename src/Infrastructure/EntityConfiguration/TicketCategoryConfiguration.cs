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
    public class TicketCategoryConfiguration : BaseEntityConfiguration<TicketCategory>
    {
        public void Configure(EntityTypeBuilder<TicketCategory> builder)
        {
            // Primary key - Name kullanıyorum geçici olarak
            builder.HasKey(tc => tc.Name);

            builder.Property(tc => tc.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(tc => tc.Description)
                .HasMaxLength(500);

            builder.Property(tc => tc.DepartmentId);

            builder.Property(tc => tc.IsActive)
                .IsRequired();

            builder.Property(tc => tc.EstimatedResolutionHours)
                .IsRequired();

            // Navigation properties
            builder.HasOne(tc => tc.Department)
                .WithMany(d => d.Categories)
                .HasForeignKey(tc => tc.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(tc => tc.Tickets)
                .WithMany();

            // Index'ler
            builder.HasIndex(tc => tc.DepartmentId);
            builder.HasIndex(tc => tc.IsActive);
        }
    }
}
