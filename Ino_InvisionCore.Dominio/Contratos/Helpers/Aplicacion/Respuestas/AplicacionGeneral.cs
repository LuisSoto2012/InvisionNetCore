using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Respuestas
{
    public class AplicacionGeneral
    {
        public int IdAplicacion { get; set; }
        public string Nombre { get; set; }
        public bool EsActivo { get; set; }
    }
}
