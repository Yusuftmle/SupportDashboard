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
    public class KnowledgeBaseArticleConfiguration : BaseEntityConfiguration<KnowledgeBaseArticle>
    {
        public override void Configure(EntityTypeBuilder<KnowledgeBaseArticle> builder)
        {
            base.Configure(builder);

            builder.Property(kb => kb.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(kb => kb.Subject)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(kb => kb.Description)
                .IsRequired();

            builder.Property(kb => kb.DefaultPriority)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(kb => kb.CategoryId);

            builder.Property(kb => kb.IsActive)
                .IsRequired();

            // Navigation properties
            builder.HasOne(kb => kb.Category)
                .WithMany()
                .HasForeignKey(kb => kb.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            // Index'ler
            builder.HasIndex(kb => kb.Subject);
            builder.HasIndex(kb => kb.CategoryId);
            builder.HasIndex(kb => kb.IsActive);
        }
    }
}
