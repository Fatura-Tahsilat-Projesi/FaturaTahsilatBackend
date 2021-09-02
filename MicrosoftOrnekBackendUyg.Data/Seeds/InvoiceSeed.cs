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
                new Invoice { InvoiceId = 1, InvoiceNu = 1, Name = "Elektrik Faturası Örneği", Total = 150, TotalVat = 70, ExcludingVat = 80, DueDate = DateTime.ParseExact("01/09/2021 13:35:00", "dd/MM/yyyy HH:mm:ss", null), InvoiceType = 1, StatusCode = 0, IsComplete = 0, CompanyId=1, UserId = 1 },
                new Invoice { InvoiceId = 2, InvoiceNu = 2, Name = "Su Faturası Örneği", Total = 170, TotalVat = 60, ExcludingVat = 110, DueDate = DateTime.ParseExact("02/09/2021 10:05:00", "dd/MM/yyyy HH:mm:ss", null), InvoiceType = 2, StatusCode = 1, IsComplete = 1, CompanyId = 1, UserId = 1 },
                new Invoice { InvoiceId = 3, InvoiceNu = 3, Name = "Doğalgaz Faturası Örneği", Total = 200, TotalVat = 60, ExcludingVat = 140, DueDate = DateTime.ParseExact("03/09/2021 11:05:00", "dd/MM/yyyy HH:mm:ss", null), InvoiceType = 3, StatusCode = 1, IsComplete = 1, CompanyId = 1, UserId = 1 },
                new Invoice { InvoiceId = 4, InvoiceNu = 4, Name = "İnternet Faturası Örneği", Total = 100, TotalVat = 60, ExcludingVat = 40, DueDate = DateTime.ParseExact("04/09/2021 12:05:00", "dd/MM/yyyy HH:mm:ss", null), InvoiceType = 4, StatusCode = 1, IsComplete = 1, CompanyId = 1, UserId = 1 },
                new Invoice { InvoiceId = 5, InvoiceNu = 5, Name = "Mobil Fatura Örneği", Total = 50, TotalVat = 20, ExcludingVat = 30, DueDate = DateTime.ParseExact("05/09/2021 12:25:00", "dd/MM/yyyy HH:mm:ss", null), InvoiceType = 5, StatusCode = 1, IsComplete = 1, CompanyId = 1, UserId = 1 },
                new Invoice { InvoiceId = 6, InvoiceNu = 6, Name = "Tv Yayın Faturası Örneği", Total = 100, TotalVat = 60, ExcludingVat = 40, DueDate = DateTime.ParseExact("06/09/2021 15:05:25", "dd/MM/yyyy HH:mm:ss", null), InvoiceType = 6, StatusCode = 1, IsComplete = 1, CompanyId = 1, UserId = 1 }

                );
        }
    }
}
