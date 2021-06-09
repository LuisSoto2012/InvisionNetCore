using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones
{
    public class CrearSolicitudTeleconsultaDto
    {
        public int IdCuentaAtencion { get; set; }
        public int IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        public string HoraCita { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public string NroHistoriaClinica { get; set; }
        public string NroDocumento { get; set; }
        public string Especialidad { get; set; }
        public string Turno { get; set; }
        public int IdDepartamento { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public string FteFto { get; set; }
    }
}
