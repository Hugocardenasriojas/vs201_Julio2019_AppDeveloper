using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.DataAccess
{
    public class InvoiceDA:BaseDA
    {
        //Se pasa la identidad Invoice
        public int InsertInvoice(Invoice invoice)
        {
            int result = 0;
            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                //Iniciando la transaccion
                var transaction = cnx.BeginTransaction();
                try
                {
                    var commandCab = cnx.CreateCommand();
                    commandCab.CommandText = "usp_InsertInvoice";
                    commandCab.CommandType = CommandType.StoredProcedure;
                    commandCab.Parameters.Add(
                        new SqlParameter("@CustomerId", invoice.CustomerId));
                    commandCab.Parameters.Add(
                        new SqlParameter("@InvoiceDate", invoice.InvoiceDate));
                    commandCab.Parameters.Add(
                        new SqlParameter("@BillingAddress", invoice.BillingAddress));
                    commandCab.Parameters.Add(
                        new SqlParameter("@BillingCity", invoice.BillingCity));
                    commandCab.Parameters.Add(
                        new SqlParameter("@BillingState", invoice.BillingState));
                    commandCab.Parameters.Add(
                        new SqlParameter("@BillingCountry", invoice.BillingCountry));
                    commandCab.Parameters.Add(
                        new SqlParameter("@BillingPostalCode", invoice.BillingPostalCode));
                    commandCab.Parameters.Add(
                        new SqlParameter("@Total", invoice.Total));
                    //Obteniendo el codigo secuencial
                    //Aqui se ejecuta el commandcab, 
                    var id = Convert.ToInt32(commandCab.ExecuteScalar());
                    /*
                    BillingAddress nvarchar(70), 
                    @BillingCity nvarchar(40), 
                    @BillingState nvarchar(40), 
                    @BillingCountry nvarchar(40), 
                    @BillingPostalCode nvarchar(40), 
                    @Total
                     */
                    foreach (var lines in invoice.InvoiceLine)
                    {
                        var commandDet = cnx.CreateCommand();
                        commandDet.CommandText = "usp_InsertInvoiceLine";
                        commandDet.CommandType = CommandType.StoredProcedure;
                        commandDet.Parameters.Add(new SqlParameter("@InvoiceId", id));
                        commandDet.Parameters.Add(new SqlParameter("@TrackId", lines.TrackId));
                        commandDet.Parameters.Add(new SqlParameter("@UnitPrice", lines.UnitPrice));
                        commandDet.Parameters.Add(new SqlParameter("@Quantity", lines.Quantity));
                        commandDet.ExecuteNonQuery();
                        /*
                        @InvoiceId int, 
                        @TrackId int, 
                        @UnitPrice numeric(10,2), 
                        @Quantity int
                        */

                    }
                    //commandCab.ExecuteNonQuery();

                    //
                    transaction.Commit();
                    result = id;

                }
                catch(Exception ex)
                {
                    //Deshaciendo la transaccion
                    transaction.Rollback();
                }
            }
                return result;
        }

        public object insertinvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
