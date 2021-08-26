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
    class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.InvoiceId);
            builder.Property(x => x.InvoiceId).UseIdentityColumn();

            //builder.HasAlternateKey(x => x.UserId);
            //builder.HasAlternateKey(x => x.CompanyId);

            builder.Property(x => x.Total).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalVat).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.ExcludingVat).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DueDate).IsRequired();
            builder.Property(x => x.InvoiceType).IsRequired();
            builder.Property(x => x.StatusCode).IsRequired();
            builder.Property(x => x.IsComplete).IsRequired();
            builder.Property(x => x.CompanyId).IsRequired();



            builder.ToTable("Invoices");

        }
    }
}
