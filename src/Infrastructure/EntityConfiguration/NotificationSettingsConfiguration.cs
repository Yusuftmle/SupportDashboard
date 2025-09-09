using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class NotificationSettingsConfiguration : BaseEntityConfiguration<NotificationSettings>
    {
        public override void Configure(EntityTypeBuilder<NotificationSettings> builder)
        {
            base.Configure(builder);

            builder.Property(ns => ns.UserId)
                .IsRequired();

            builder.Property(ns => ns.Type)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(ns => ns.IsEnabled)
                .IsRequired();

            builder.Property(ns => ns.Channel)
                .HasConversion<string>()
                .IsRequired();

            // Navigation properties
            builder.HasOne(ns => ns.User)
                .WithMany()
                .HasForeignKey(ns => ns.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Composite unique index
            builder.HasIndex(ns => new { ns.UserId, ns.Type, ns.Channel }).IsUnique();
        }
    }
}
