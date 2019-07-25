﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.DataAccess
{
    public class BaseDA
    {
        public string ConnectionString

        {
            get
            {
                //
                var cnxString = "SERVER=S300-ST;Database=Chinook;USER ID=sa;PASSWORD=sql;";
                return cnxString;
            }
        }
        public string GetStringValue(IDataReader reader, string campo)
        {
            //<condicion>?<Valor Verdad>: <Valor Falso>
            //GetOrdinal, obtiene la posicion del campo
            return reader.IsDBNull(reader.GetOrdinal(campo))
                                ? null : reader.GetString(reader.GetOrdinal(campo));
        }
    }
    
}
