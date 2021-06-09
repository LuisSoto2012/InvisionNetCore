using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.ConsultaWeb_ConsultaRapida
{
    public class SolicitudConsultaRapida
    {
        [Key]
        public int IdSolicitud{ get; set; }
        [Required]
        [StringLength(200)]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(200)]
        public string ApellidoMaterno { get; set; }
        [Required]
        [StringLength(200)]
        public string Nombres { get; set; }
        [Required]
        public int IdTipoDocumento { get; set; }
        [Required]
        [StringLength(30)]
        public string NumeroDocumento { get; set; }
        public DateTime? FechaEmision { get; set; }
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
        [StringLength(500)]
        public string MotivoConsulta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public int IdEstado { get; set; }
        public int IdUsuarioAcepta { get; set; }
        public DateTime? FechaAcepta { get; set; }
        public DateTime? FechaCita { get; set; }
        public string HoraCita { get; set; }
        public int? IdMedico { get; set; }
        public string Medico { get; set; }
        public int? TipoSeguro { get; set; }
        public string NumeroReferencia { get; set; }
        public int? IdEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; }
        public string OrigenPaciente { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public SolicitudConsultaRapida()
        {
            FechaCreacion = DateTime.Now;
            IdEstado = 0;
        }
    }
}
