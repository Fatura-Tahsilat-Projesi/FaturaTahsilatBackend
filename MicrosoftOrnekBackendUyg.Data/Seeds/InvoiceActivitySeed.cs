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
    class InvoiceActivitySeed:IEntityTypeConfiguration<InvoiceActivity>
    {
        private readonly int[] _ids;
        public InvoiceActivitySeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<InvoiceActivity> builder)
        {
            builder.HasData(
                new InvoiceActivity { Id = 1, UserId = "1", InvoiceId = 1, CompanyId = 1, TransactionDate = DateTime.ParseExact("01/09/2021 10:05:00", "dd/MM/yyyy HH:mm:ss", null), StatusCode = 0 },
                new InvoiceActivity { Id = 2, UserId = "2", InvoiceId = 2, CompanyId = 2, TransactionDate = DateTime.ParseExact("02/09/2021 11:25:00", "dd/MM/yyyy HH:mm:ss", null), StatusCode = 1 },
                new InvoiceActivity { Id = 3, UserId = "3", InvoiceId = 3, CompanyId = 3, TransactionDate = DateTime.ParseExact("03/09/2021 12:05:00", "dd/MM/yyyy HH:mm:ss", null), StatusCode = 2 },
                new InvoiceActivity { Id = 4, UserId = "4", InvoiceId = 4, CompanyId = 4, TransactionDate = DateTime.ParseExact("04/09/2021 14:05:00", "dd/MM/yyyy HH:mm:ss", null), StatusCode = 3 },
                new InvoiceActivity { Id = 5, UserId = "5", InvoiceId = 5, CompanyId = 5, TransactionDate = DateTime.ParseExact("05/09/2021 15:25:00", "dd/MM/yyyy HH:mm:ss", null), StatusCode = 50 },
                new InvoiceActivity { Id = 6, UserId = "6", InvoiceId = 6, CompanyId = 6, TransactionDate = DateTime.ParseExact("06/09/2021 16:05:00", "dd/MM/yyyy HH:mm:ss", null), StatusCode = -1 }
                );
        }
    }
}
