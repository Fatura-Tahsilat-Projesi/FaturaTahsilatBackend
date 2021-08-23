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
    class FaturaSeed : IEntityTypeConfiguration<Fatura>
    {
        private readonly int[] _ids;

        public FaturaSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.HasData(
                new Fatura { FaturaId = 1, tutar = 100, topkdv = 70, kdvsizfiyat = 30, son_odeme = DateTime.ParseExact("10/10/2021 23:59:00", "dd/MM/yyyy HH:mm:ss", null), icerik = "Su", Name = "Su Faturası", odendi = 0, IsComplete = 0},
                new Fatura { FaturaId = 2, tutar = 120, topkdv = 60, kdvsizfiyat = 60, son_odeme = DateTime.ParseExact("10/12/2021 18:00:00", "dd/MM/yyyy HH:mm:ss", null), icerik = "Elektrik", Name = "Elektrik Faturası", odendi = 0, IsComplete = 0 }
                );
        }
    }
}
