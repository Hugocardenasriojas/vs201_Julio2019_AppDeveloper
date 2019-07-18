using App.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class SolicitudAcceso:Solicitud

    {
        public int NivelAcceso { get; set; }
        public override bool Aprobar()
        {
            //Al usar override se usara la logica de la hija y no de la base
            //Tambien en el padre debe estar la funcion con la palabra virtual
            //No se puede agregar mas parametros que no este en el padre
            var resultado = false;
            if(this.NivelAcceso > 2)//No es administrado
            resultado=true;
            return resultado;
        }
    }
}
