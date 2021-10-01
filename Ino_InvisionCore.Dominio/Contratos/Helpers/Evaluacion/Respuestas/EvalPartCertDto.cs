// EvalPartCertDto.cs23:0023:00

using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas
{
    public class EvalPartCertDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string FechaEmision { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public string Pais { get; set; }
        public string Ocupacion { get; set; }
        public string Region { get; set; }
        public string Sector { get; set; }
        public string NivelAtencion { get; set; }
        public List<EvalCertFlagDto> Certificados { get; set; }
    }
}