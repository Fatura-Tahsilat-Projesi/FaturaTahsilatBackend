using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Core.Models
{
    public class Log
    {
        public int Id { get; set; }

        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }

       // public string Datetime { get; set; }
        //Denetim Türü, Information, Warning
        //public string EventType { get; set; }
        //public string Description { get; set; }
        public string UserId { get; set; }
        public ICollection<UserApp> UserApps { get; set; }

        //public virtual UserApp User { get; set; }
        //public virtual User User { get; set; }
    }
}
