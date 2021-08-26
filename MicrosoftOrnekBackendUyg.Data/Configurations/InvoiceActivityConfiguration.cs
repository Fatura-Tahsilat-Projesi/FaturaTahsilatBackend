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
    class InvoiceActivityConfiguration : IEntityTypeConfiguration<InvoiceActivity>
    {
        public void Configure(EntityTypeBuilder<InvoiceActivity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            
            //builder.HasAlternateKey(x => x.UserId);
            //builder.HasAlternateKey(x => x.InvoiceId);
            //builder.HasAlternateKey(x => x.CompanyId);


            //builder.Property(x => x.UserId).IsRequired();
            //builder.Property(x => x.InvoiceId).IsRequired();
            //builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.StatusCode).IsRequired();
            
            
          

            builder.ToTable("InvoiceActivities");
        }
    }
}
