using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicrosoftOrnekBackendUyg.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Data.Seeds
{
    class InvoiceSeed : IEntityTypeConfiguration<Invoice>
    {
        private readonly int[] _ids;

        public InvoiceSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasData(
                new Invoice { InvoiceId = 1, InvoiceNu = 1, Name = "Su Faturası Örneği", Total = 100, TotalVat = 70, ExcludingVat = 30, DueDate = DateTime.ParseExact("10/10/2021 23:59:00", "dd/MM/yyyy HH:mm:ss", null), InvoiceType = 0, StatusCode = 0, IsComplete = 0, CompanyId=0, UserId = 0 },
                new Invoice { InvoiceId = 2, InvoiceNu = 2, Name = "Elektrik Faturası Örneği", Total = 120, TotalVat = 60, ExcludingVat = 60, DueDate = DateTime.ParseExact("10/12/2021 18:00:00", "dd/MM/yyyy HH:mm:ss", null), InvoiceType = 1, StatusCode = 0, IsComplete = 0, CompanyId = 0, UserId = 0 }
                );
        }
    }
}
