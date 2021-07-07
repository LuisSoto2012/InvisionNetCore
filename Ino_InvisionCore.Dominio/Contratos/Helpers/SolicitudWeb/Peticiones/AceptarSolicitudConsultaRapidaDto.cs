using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones
{
    public class AceptarSolicitudConsultaRapidaDto
    {
        public int IdSolicitud { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaCita { get; set; }
        public ComboBox HoraCita { get; set; }
        public ComboBox Especialidad { get; set; }
        public string MotivoRechazo { get; set; }
        public int IdOperacion { get; set; }
    }
}
