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
    public class SLAConfiguration : BaseEntityConfiguration<SLA>
    {
        public override void Configure(EntityTypeBuilder<SLA> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Priority)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(s => s.ResponseTimeHours)
                .IsRequired();

            builder.Property(s => s.ResolutionTimeHours)
                .IsRequired();

            builder.Property(s => s.IsActive)
                .IsRequired();

            // Navigation properties
            builder.HasMany(s => s.Tickets)
                .WithMany();

            // Index'ler
            builder.HasIndex(s => s.Priority);
            builder.HasIndex(s => s.IsActive);
        }
    }
}
