using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_new.Models
{
    public class Invoices
    {
        public int ClientId { get; set; }

        public string InvoiceDate { get; set; }

        public string InvoiceDue { get; set; }

        public string InvoicePdfFileName { get; set; }
    }
}
