using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.ConsultaWeb
{
    public class SolicitudReprogramacion
    {
        [Key]
        public int IdSolicitud { get; set; }
        [Required]
        public int IdCuentaAtencion { get; set; }
        [Required]
        [StringLength(500)]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(500)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(20)]
        public string NumeroDocumento { get; set; }
        [StringLength(20)]
        public string TelefonoMovil { get; set; }
        [Required]
        [StringLength(100)]
        public string Correo { get; set; }
        [Required]
        public int IdDepartamento { get; set; }
        [Required]
        public int IdProvincia { get; set; }
        [Required]
        public int IdDistrito { get; set; }
        [Required]
        [StringLength(500)]
        public string MotivoInasistencia { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuarioReprograma { get; set; }
        public DateTime? FechaReprogramacion { get; set; }
        public DateTime? NuevaFechaReprogramacion { get; set; }
        public int IdUsuarioValida { get; set; }
        public DateTime? FechaValidacion { get; set; }
        public SolicitudReprogramacion()
        {
            IdEstado = 0;
            FechaCreacion = DateTime.Now;
        }
    }
}
