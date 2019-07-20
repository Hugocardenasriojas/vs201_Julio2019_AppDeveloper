using System;
using System.Collections.Generic;
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
    }
}
