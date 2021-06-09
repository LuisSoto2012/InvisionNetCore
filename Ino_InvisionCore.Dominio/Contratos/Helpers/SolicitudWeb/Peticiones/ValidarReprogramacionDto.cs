using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones
{
    public class ValidarReprogramacionDto
    {
        public int IdSolicitud { get; set; }
        public int IdUsuarioValida { get; set; }
        public string Correo { get; set; }
    }
}
