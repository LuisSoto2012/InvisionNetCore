using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones
{
    public class GuardarNuevaFechaReprogramacionDto
    {
        public int IdSolicitud { get; set; }
        public int IdUsuarioReprograma { get; set; }
        public DateTime NuevaFechaReprogramacion { get; set; }
    }
}
