
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones
{
    public class AceptarRechazarSolicitudCita
    {
        public int IdSolicitudCita { get; set; }
        public int IdOperacion { get; set; }
        public int IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public ComboBoxMedico Medicos { get; set; }
        public ComboBoxMedico Residentes { get; set; }
        public DateTime FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string UrlCita { get; set; }
        public string MotivoRechazo { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
    }
}
