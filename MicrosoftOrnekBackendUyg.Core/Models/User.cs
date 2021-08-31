using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Models
{
    public class User
    {

        public User()
        {
            Invoices = new Collection<Invoice>();
            //InvoiceActivities = new Collection<InvoiceActivity>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Authorization { get; set; }
        public int TcNu { get; set; }
        public string Address { get; set; }
        public string PhoneNu { get; set; }
        public string Mail { get; set; }
        public int Iban { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
        //public ICollection<InvoiceActivity> InvoiceActivities { get; set; }


        //public virtual List<Invoice> Invoices { get; set; }
        //public virtual List<InvoiceActivity> InvoiceActivities { get; set; }


    }
}
