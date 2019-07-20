﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Base
{
    public class Solicitud
    {
        //propiedades de una clase. get y set son 2 funciones. get para asignar y set para leer.
        public int NroSolicitud { get; set; }
        public DateTime Fecha { get; set; }
        public string Solicitante { get; set; }
        public int Estado { get; set; }
        public string DetalleSolicitud { get; set; }


        //funcion
        //virtual : probablemente algunas clases hijas pueden modificarlo
        public virtual bool Aprobar()
        {
            return true;
        }
    }
}
