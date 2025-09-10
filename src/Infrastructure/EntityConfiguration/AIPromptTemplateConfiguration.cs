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
    public class AIPromptTemplateConfiguration : BaseEntityConfiguration<AIPromptTemplate>
    {
        public override void Configure(EntityTypeBuilder<AIPromptTemplate> builder)
        {
            base.Configure(builder);

            // Table name
            builder.ToTable("AIPromptTemplates");

            // Properties
            builder.Property(apt => apt.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(apt => apt.Template)
                .IsRequired();

            builder.Property(apt => apt.Category)
                .HasMaxLength(100);

            builder.Property(apt => apt.Parameters);

            builder.Property(apt => apt.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            // Indexes
            builder.HasIndex(apt => apt.Name)
                .IsUnique();

            builder.HasIndex(apt => apt.Category);
            builder.HasIndex(apt => apt.IsActive);
            builder.HasIndex(apt => new { apt.Category, apt.IsActive });
        }
    }
}
