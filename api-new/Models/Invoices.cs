using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_new.Models
{
    public class Invoices
    {
        public string InvoiceId { get; set; }

        public string CustomerNumber { get; set; }

        public string InvoiceDate { get; set; }

        public string InvoiceAmount { get; set; }

        public string PaymentAmount { get; set; }

        public bool PaidInFull { get; set; }

        public string InvoiceFilePath { get; set; }

        public string DateDue { get; set; }
    }
}
