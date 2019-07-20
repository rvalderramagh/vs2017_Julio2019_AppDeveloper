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

        //override no usare la clase de mi padre sino creare una para mi
        public override bool Aprobar()
        {
            var resultado = false;

            if (this.NivelAcceso > 2) // No es administrador
                resultado = true;

            return resultado;
        }
    }
}
