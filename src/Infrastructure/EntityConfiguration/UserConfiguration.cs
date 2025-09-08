using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder); // Id ve CreateDate ayarları
            builder.Property(u => u.FullName).IsRequired().HasMaxLength(150);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        }
    }
}
