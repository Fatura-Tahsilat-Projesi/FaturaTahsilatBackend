using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Models
{
    public class Fatura
    {
        public int FaturaId { get; set; }
        public int tutar { get; set; }
        public int topkdv { get; set; }
        public int kdvsizfiyat { get; set; }
        public DateTime son_odeme { get; set; }
        public string icerik { get; set; }
        public int odendi { get; set; }
        public string Name { get; set; }
        public int IsComplete { get; set; }
        //public virtual Users KullaniciSutunu { get; set; }
    }
}
