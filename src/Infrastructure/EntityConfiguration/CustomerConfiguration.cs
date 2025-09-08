using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class CustomerConfiguration : BaseEntityConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.ContactPerson)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(c => c.Address)
                .HasMaxLength(500);

            builder.Property(c => c.Tier)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(c => c.IsActive)
                .IsRequired();

            // Navigation properties
            builder.HasMany(c => c.Tickets)
                .WithMany()
                .UsingEntity(j => j.TTable("CustomerTickets"));

            // Index'ler
            builder.HasIndex(c => c.Email).IsUnique();
            builder.HasIndex(c => c.CompanyName);
            builder.HasIndex(c => c.Tier);
            builder.HasIndex(c => c.IsActive);
        }
    }
}
