using System;
using System.Collections.Generic;
using App.Entities.Base;
using App_Data.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class InvoiceDATest
    {
        [TestMethod]
        public void Insert()
        {
            var invoice = new Invoice();
            invoice.CustomerId = 1;
            invoice.InvoiceDate = DateTime.Now;
            invoice.BillingAddress = "address";
            invoice.BillingCity = "city";
            invoice.BillingCountry = "country";
            invoice.BillingPostalCode = "postalcode";
            invoice.Total = 100;

            invoice.InvoiceLine = new List<InvoiceLine>();
            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 1,
                    UnitPrice = 11,
                    Quantity = 111
                });
            invoice.InvoiceLine.Add(
            new InvoiceLine()
            {
                TrackId = 2,
                UnitPrice = 22,
                Quantity = 222
            }
            );
            invoice.InvoiceLine.Add(
            new InvoiceLine()
            {
                TrackId = 3,
                UnitPrice = 33,
                Quantity = 333
            }
            );
            var da = new InvoiceDA();
            var id = da.InsertInvoice(invoice);
            Assert.IsTrue(id > 0);
        }
    }
}
