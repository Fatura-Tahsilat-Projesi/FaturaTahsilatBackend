using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Models
{
    public class InvoiceActivity
    {
        public int Id { get; set; }
        //[ForeignKey("UserId")]
        public string UserId { get; set; }
        //[ForeignKey("InvoiceId")]
        public int InvoiceId { get; set; }
        //[ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int StatusCode { get; set; }
        //[JsonIgnore]
        //public virtual User User { get; set; }
        [JsonIgnore]
        public virtual Invoice Invoice { get; set; }
        //public virtual UserApp User { get; set; }

        //[JsonIgnore]
        //public virtual Company Company { get; set; }

        //public virtual List<Invoice> Invoices { get; set; }
    }
}
