using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Models
{
    public class CreditCards
    {
        public int Id { get; set; }
        public int CreditCardType { get; set; }
        public int UserId { get; set; }
        public string CardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public int CVC2 { get; set; }
        public int Balance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
