using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Respuestas
{
    public class SolicitudConsultaRapidaDto
    {
        public int IdSolicitud { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string FechaEmision { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoMovil { get; set; }
        public int IdEstadoCivil { get; set; }
        public string FechaNacimiento { get; set; }
        public int IdSexo { get; set; }
        public int IdDepartamento { get; set; }
        public int IdProvincia { get; set; }
        public int IdDistrito { get; set; }
        public string Direccion { get; set; }
        public string MotivoConsulta { get; set; }
        public string FechaSolicitud { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuarioAcepta { get; set; }
        public string FechaAcepta { get; set; }
        public string FechaCita { get; set; }
        public string HoraCita { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public string Edad { get; set; }
        public int TipoSeguro { get; set; }
        public string NumeroReferencia { get; set; }
        public ComboBox Especialidad { get; set; }
        public string OrigenPaciente { get; set; }
        public int? IdUsuarioRechaza { get; set; }
        public string FechaRechazo { get; set; }
        public string MotivoRechazo { get; set; }
        public string TipoPaciente { get; set; }
    }
}
