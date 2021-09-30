using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicrosoftOrnekBackendUyg.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Data.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<CustomUser>
    {
        public void Configure(EntityTypeBuilder<CustomUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(200);
            builder.Property(x => x.TcNu).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Iban).IsRequired();



            builder.ToTable("CustomUsers");
        }
    }
}
