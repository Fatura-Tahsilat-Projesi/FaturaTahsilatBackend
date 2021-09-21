using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.RabbitMQ
{
    public class OnlinePaymentEvent
    {
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
    }
}
