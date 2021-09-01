using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.DTOs
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public int InvoiceNu { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
        public int TotalVat { get; set; }
        public int ExcludingVat { get; set; }
        public DateTime DueDate { get; set; }
        public int InvoiceType { get; set; }
        public int StatusCode { get; set; }
        public int IsComplete { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
    }
}
