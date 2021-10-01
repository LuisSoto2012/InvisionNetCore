// EvalPartCertView.cs23:0123:01

using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class EvalPartCertView
    {
        public int Id { get; set; }
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
        public int Certificado1 { get; set; }
        public int Certificado2 { get; set; }
        public int Certificado3 { get; set; }
        public int Certificado4 { get; set; }
        public int Certificado5 { get; set; }
        public DateTime FechaCertificado1 { get; set; }
        public DateTime FechaCertificado2 { get; set; }
        public DateTime FechaCertificado3 { get; set; }
        public DateTime FechaCertificado4 { get; set; }
        public DateTime FechaCertificado5 { get; set; }
        public string Modulo { get; set; }
    }
}