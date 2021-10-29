using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.VacunacionCOVID19
{
    public class VacunacionCOVID19
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdPersonalINO { get; set; }
        [Required]
        [StringLength(20)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(250)]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(250)]
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [StringLength(100)]
        public string Actividad { get; set; }
        [StringLength(100)]
        public string Telefono { get; set; }
        public DateTime? PrimeraDosisFecha { get; set; }
        public DateTime? SegundaDosisFecha { get; set; }
        public DateTime? TerceraDosisFecha { get; set; }
        
        [StringLength(50)]
        public string RA1D_Pulso { get; set; }
        [StringLength(50)]
        public string RA1D_PresionArterial { get; set; }
        [StringLength(50)]
        public string RA1D_Saturacion { get; set; }
        [MaxLength]
        public string RA1D_Diagnosticos { get; set; }
        [MaxLength]
        public string RA1D_Observaciones { get; set; }

        [StringLength(50)]
        public string RA2D_Pulso { get; set; }
        [StringLength(50)]
        public string RA2D_PresionArterial { get; set; }
        [StringLength(50)]
        public string RA2D_Saturacion { get; set; }
        [MaxLength]
        public string RA2D_Diagnosticos { get; set; }
        [MaxLength]
        public string RA2D_Observaciones { get; set; }
        
        [StringLength(50)]
        public string RA3D_Pulso { get; set; }
        [StringLength(50)]
        public string RA3D_PresionArterial { get; set; }
        [StringLength(50)]
        public string RA3D_Saturacion { get; set; }
        [MaxLength]
        public string RA3D_Diagnosticos { get; set; }
        [MaxLength]
        public string RA3D_Observaciones { get; set; }

        public DateTime? FechaRegistroPrimeraDosisReaccionesAdversas { get; set; }
        public DateTime? FechaRegistroSegundaDosisReaccionesAdversas { get; set; }
        public DateTime? FechaRegistroTerceraDosisReaccionesAdversas { get; set; }
        public int IdUsuarioRegistroPrimeraDosis { get; set; }
        public int? IdUsuarioRegistroSegundaDosis { get; set; }
        public int? IdUsuarioRegistroTerceraDosis { get; set; }
        public int? IdUsuarioRegistroPrimeraDosisReaccionesAdversas { get; set; }
        public int? IdUsuarioRegistroSegundaDosisReaccionesAdversas { get; set; }
        public int? IdUsuarioRegistroTerceraDosisReaccionesAdversas { get; set; }

        public VacunacionCOVID19()
        {
            
        }
    }
}
