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
    class UserSeed: IEntityTypeConfiguration<User>
    {
        private readonly int[] _ids;
        public UserSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, UserName = "superadmin", Name = "Muhammed ", Surname = "Karadaş1", Authorization = 2, TcNu=1, Address = "Erzurum", PhoneNu = "05342906884", Mail = "muhammedkaradastr@gmail.com", Iban = 1, CreatedAt = DateTime.ParseExact("01/09/2021 10:25:00", "dd/MM/yyyy HH:mm:ss", null) },
                new User { Id = 2, UserName = "normaladmin", Name = "Muhammed", Surname = "Karadaş2", Authorization = 1, TcNu = 2, Address = "İstanbul", PhoneNu = "05342906884", Mail = "muti5@windowslive.com", Iban = 2, CreatedAt = DateTime.ParseExact("02/09/2021 12:25:00", "dd/MM/yyyy HH:mm:ss", null) },
                new User { Id = 3, UserName = "normaluser", Name = "Muhammed", Surname = "Karadaş3", Authorization = 0, TcNu = 3, Address = "Erzurum", PhoneNu = "05342906884", Mail = "muti323@gmail.com", Iban = 3, CreatedAt = DateTime.ParseExact("03/09/2021 15:35:00", "dd/MM/yyyy HH:mm:ss", null) }

                );
        }
    }
}
