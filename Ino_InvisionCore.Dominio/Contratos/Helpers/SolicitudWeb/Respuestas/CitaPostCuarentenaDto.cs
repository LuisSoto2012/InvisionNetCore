using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Respuestas
{
    public class CitaPostCuarentenaDto
    {
        public int IdCuentaAtencion { get; set; }
        public int IdCita { get; set; }
        public string FechaCita { get; set; }
        public string HoraCita { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public string NombresPaciente { get; set; }
        public string ApellidosPaciente { get; set; }
        public string NroDocumento { get; set; }
        public string NroHistoriaClinica { get; set; }
        public string Especialidad { get; set; }
        public string Turno { get; set; }
        public int IdDepartamento { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public string FteFto { get; set; }
    }
}
