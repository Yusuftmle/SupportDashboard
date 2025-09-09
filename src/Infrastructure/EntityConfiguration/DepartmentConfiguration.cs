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
    public class DepartmentConfiguration : BaseEntityConfiguration<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            base.Configure(builder);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Description)
                .HasMaxLength(500);

            builder.Property(d => d.IsActive)
                .IsRequired();

            builder.Property(d => d.ManagerId);

            // Navigation properties
            builder.HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(d => d.Users)
                .WithMany();

            builder.HasMany(d => d.Categories)
                .WithOne(c => c.Department)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

            // Index'ler
            builder.HasIndex(d => d.Name).IsUnique();
            builder.HasIndex(d => d.IsActive);
        }
    }
}
