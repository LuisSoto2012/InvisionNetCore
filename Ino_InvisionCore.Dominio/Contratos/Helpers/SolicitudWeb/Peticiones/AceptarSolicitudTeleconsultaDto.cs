using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones
{
    public class AceptarSolicitudTeleconsultaDto
    {
        public int IdSolicitud { get; set; }
        public int IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Url { get; set; }
        public string NuevoHoraCita { get; set; }
        public string Especialidad { get; set; }
        public int IdMedico { get; set; }
        public DateTime Fecha { get; set; }
    }
}
