using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Base
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public String BillingAddress { get; set; }
        public String BillingCity { get; set; }
        public String BillingState { get; set; }
        public String BillingCountry { get; set; }
        public String BillingPostalCode { get; set; }
        public Decimal Total { get; set; }
        /*
            [BillingAddress], 
            [BillingCity], [BillingState], 
            [BillingCountry], [BillingPostalCode], 
            [Total]
        */
        public List<InvoiceLine> InvoiceLine { get; set; }
    }
}
