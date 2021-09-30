using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Models
{
    public class Invoice
    {

        public Invoice()
        {
            InvoiceActivities = new Collection<InvoiceActivity>();
        }

        public int InvoiceId { get; set; }
        public int InvoiceNu { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
        public int TotalVat { get; set; }
        //VAT:KDV
        public int ExcludingVat { get; set; }
        public DateTime DueDate { get; set; }
        public int InvoiceType { get; set; }
        public int StatusCode { get; set; }
        public int IsComplete { get; set; }
        //[ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        //[ForeignKey("UserId")]
        public string UserId { get; set; }

        public ICollection<InvoiceActivity> InvoiceActivities { get; set; }
        public ICollection<UserApp> UserApps { get; set; }
        [JsonIgnore]
        public virtual Company Company { get; set; }
        //public virtual UserApp User { get; set; }

        //public virtual User User { get; set; }

    }
}
