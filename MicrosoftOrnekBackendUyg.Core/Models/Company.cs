using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Models
{
    public class Company
    {

        public Company()
        {
            Invoices = new Collection<Invoice>();
            //InvoiceActivities = new Collection<InvoiceActivity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public int CompanyCode { get; set; }

        public string UserId { get; set; }
        //public virtual UserApp User { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<UserApp> UserApps { get; set; }

        //public ICollection<InvoiceActivity> InvoiceActivities { get; set; }

        //public virtual List<Invoice> Invoices { get; set; }
        //public virtual List<InvoiceActivity> InvoiceActivities { get; set; }

    }
}
