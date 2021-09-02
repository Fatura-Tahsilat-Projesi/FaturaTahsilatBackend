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
    class CompanySeed : IEntityTypeConfiguration<Company>
    {
        private readonly int[] _ids;

        public CompanySeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company { Id = 1, Name = "Elektrik Firması", Category = 1, CompanyCode = 100 },
                new Company { Id = 2, Name = "Su Firması", Category = 2, CompanyCode = 101 },
                new Company { Id = 3, Name = "Doğalgaz Firması", Category = 3, CompanyCode = 102 },
                new Company { Id = 4, Name = "İnternet Firması", Category = 4, CompanyCode = 103 },
                new Company { Id = 5, Name = "Mobil Operatör Firması", Category = 5, CompanyCode = 104 },
                new Company { Id = 6, Name = "Tv Yayın Firması", Category = 6, CompanyCode = 105 }

                );
        }
    }
}
