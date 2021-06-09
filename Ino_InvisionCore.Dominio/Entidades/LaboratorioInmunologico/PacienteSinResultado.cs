using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class PacienteSinResultado : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdPacienteSinResultado { get; set; }
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
        public bool MuestraNoTomada { get; set; }
        [Required]
        public bool ResultadoNoIngresado { get; set; }
        [Required]
        public bool PruebaNoRegistrada { get; set; }
        [Required]
        public bool ResultadoNoRegistrado { get; set; }
        [Required]
        public bool ResultadoNoImpreso { get; set; }
    }
}
