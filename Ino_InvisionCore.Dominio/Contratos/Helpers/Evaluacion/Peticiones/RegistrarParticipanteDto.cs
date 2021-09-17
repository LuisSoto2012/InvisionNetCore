// RegistrarParticipanteDto.cs22:2822:28

using System;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones
{
    public class RegistrarParticipanteDto
    {
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaEmision { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public string Pais { get; set; }
        public string Ocupacion { get; set; }
        public string Region { get; set; }
        public string Sector { get; set; }
        public string NivelAtencion { get; set; }
    }
}