using Microsoft.Extensions.Logging;
using MicrosoftOrnekBackendUyg.Core.Models;
using MicrosoftOrnekBackendUyg.Core.Repositories;
using MicrosoftOrnekBackendUyg.Core.Services;
using MicrosoftOrnekBackendUyg.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Service.Services
{
    public class PaymentService : IPaymentService
    {

        public PaymentService()
        {
        }

        public void PaymentUpdate(int InvoiceId)
        {
            //Invoice fatura = new Invoice();
            //var tmpInvoice = _unitOfWork.Invoices.GetByIdAsync(InvoiceId);
            //var tmpInvoice = _invoiceService.GetByIdAsync(InvoiceId);
            //fatura = tmpInvoice.Result;
            //Debug.Print($"Gelen Mesaj = fatura = {fatura}- tmpInvoice = {tmpInvoice}");
            //_unitOfWork.Invoices.Update(fatura);
            //throw new NotImplementedException();
        }
    }
}
