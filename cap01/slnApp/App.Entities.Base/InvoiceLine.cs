﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Base
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public Decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        /*
         [InvoiceId], [TrackId], [UnitPrice], [Quantity]*/
    }
}
