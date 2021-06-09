using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class SolicitudDatosIncompletos : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdSolicitudDatosIncompletos { get; set; }
        [Required]
        public DateTime FechaOcurrencia { get; set; }
        [Required]
        [StringLength(10)]
        public string HistoriaClinica { get; set; }
        [StringLength(10)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(500)]
        public string Paciente { get; set; }
        [Required]
        public bool FaltaDatos { get; set; }
        [Required]
        public bool SinMovimiento { get; set; }
        [Required]
        public bool MovimientoIncorrecto { get; set; }
    }
}
