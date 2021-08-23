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
    class FaturaConfiguration : IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.HasKey(x => x.FaturaId);
            builder.Property(x => x.FaturaId).UseIdentityColumn();

            builder.Property(x => x.tutar).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.topkdv).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.kdvsizfiyat).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            
            builder.ToTable("Faturalar");

        }
    }
}
