using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.ConsultaWeb
{
    public class SolicitudCita
    {
        [Key]
        public int IdSolicitudCita { get; set; }
        [Required]
        [StringLength(200)]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(200)]
        public string ApellidoMaterno { get; set; }
        [Required]
        [StringLength(200)]
        public string PrimerNombre { get; set; }
        [Required]
        [StringLength(200)]
        public string SegundoNombre { get; set; }
        [Required]
        public int IdTipoDocumento { get; set; }
        [Required]
        [StringLength(30)]
        public string NumeroDocumento { get; set; }
        [StringLength(100)]
        public string CorreoElectronico { get; set; }
        [StringLength(20)]
        public string TelefonoMovil { get; set; }
        public int IdEstadoCivil { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public int IdSexo { get; set; }
        [Required]
        public int IdDepartamento { get; set; }
        [Required]
        public int IdProvincia { get; set; }
        [Required]
        public int IdDistrito { get; set; }
        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }
        [Required]
        public bool Zoom { get; set; }
        [Required]
        [StringLength(500)]
        public string MotivoConsulta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuarioAcepta { get; set; }
        public int IdUsuarioRechaza { get; set; }
        public DateTime? FechaAcepta { get; set; }
        public DateTime? FechaRechaza { get; set; }
        public int IdUsuarioAtiende { get; set; }
        public DateTime? FechaAtiende { get; set; }
        public int IdMedico { get; set; }
        public int IdResidente { get; set; }
        public DateTime? FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string UrlCita { get; set; }
        public string MotivoRechazo { get; set; }
        public DateTime? FechaRecetaEmision { get; set; }
        public DateTime? FechaRecetaValidoHasta { get; set; }
        public string CodProc { get; set; }
        public string DesProc { get; set; }
        public string TipoConsulta { get; set; }

        public SolicitudCita()
        {
            FechaCreacion = DateTime.Now;
            IdEstado = 0;
        }
    }
}
