using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class TicketTagConfiguration : BaseEntityConfiguration<TicketTag>
    {
        public override void Configure(EntityTypeBuilder<TicketTag> builder)
        {
            base.Configure(builder);

            builder.Property(tt => tt.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(tt => tt.Color)
                .IsRequired()
                .HasMaxLength(7);

            builder.Property(tt => tt.IsActive)
                .IsRequired();

            // Many-to-many relationship
            builder.HasMany(tt => tt.Tickets)
                .WithMany()
                .UsingEntity(j => j.ToTable("TicketTicketTags"));

            // Index'ler
            builder.HasIndex(tt => tt.Name).IsUnique();
            builder.HasIndex(tt => tt.IsActive);
        }
    }
}
