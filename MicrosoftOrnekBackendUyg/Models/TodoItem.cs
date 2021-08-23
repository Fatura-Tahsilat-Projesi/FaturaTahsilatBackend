﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Models
{
    public class TodoItem
    {
        public long ItemId { get; set; }
        public int tutar { get; set; }
        public int topkdv { get; set; }
        public int kdvsizfiyat { get; set; }
        public DateTime son_odeme { get; set; }
        public string icerik { get; set; }
        public bool odendi { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        //public string Secret { get; set; }
    }
}
