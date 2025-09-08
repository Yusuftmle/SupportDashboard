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
    public class WorkingHoursConfiguration : BaseEntityConfiguration<WorkingHours>
    {
        public override void Configure(EntityTypeBuilder<WorkingHours> builder)
        {
            base.Configure(builder);

            builder.Property(wh => wh.DayOfWeek)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(wh => wh.StartTime)
                .IsRequired();

            builder.Property(wh => wh.EndTime)
                .IsRequired();

            builder.Property(wh => wh.IsWorkingDay)
                .IsRequired();

            builder.Property(wh => wh.DepartmentId);

            // Navigation properties
            builder.HasOne(wh => wh.Department)
                .WithMany()
                .HasForeignKey(wh => wh.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint - her department için her gün tek kayıt
            builder.HasIndex(wh => new { wh.DepartmentId, wh.DayOfWeek }).IsUnique();
        }
    }
}
