using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones
{
    public class RegistroSolicitudConsultaRapidaDto
    {
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaEmision { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoMovil { get; set; }
        public int IdEstadoCivil { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdSexo { get; set; }
        public int IdDepartamento { get; set; }
        public int IdProvincia { get; set; }
        public int IdDistrito { get; set; }
        public string Direccion { get; set; }
        public string MotivoConsulta { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public ComboBox Medico { get; set; }
        public int TipoSeguro { get; set; }
        public string NumeroReferencia { get; set; }
        public string OrigenPaciente { get; set; }
    }
}
