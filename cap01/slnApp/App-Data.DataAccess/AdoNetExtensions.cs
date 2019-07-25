using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.DataAccess
{
    public static class AdoNetExtensions
        //Extensiones de funciones.
    {
        public static string GetStringValue(this IDataReader reader, string campo)
            //Al tener la palabra reservada this, no se comporta como parametro
            //Al colocar this, se esta extendiendo la clase this IDataReader
        {
            //<condicion>?<Valor Verdad>: <Valor Falso>
            //GetOrdinal, obtiene la posicion del campo
            return reader.IsDBNull(reader.GetOrdinal(campo))
                                ? null : reader.GetString(reader.GetOrdinal(campo));
        }
    }
}
