using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class TicketConsultaExterna : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdTicketConsultaExterna { get; set; }
        [Required]
        public int IdPaciente { get; set; }
        [Required]
        [StringLength(10)]
        public string HistoriaClinica { get; set; }
        [StringLength(10)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(500)]
        public string Paciente { get; set; }
        [Required]
        [StringLength(30)]
        public string NroBoletaFua { get; set; }
        [Required]
        public int IdImpresion { get; set; }
        [Required]
        public int IdMedico { get; set; }
        [StringLength(500)]
        public string Medico { get; set; }
        public int IdImpresionRevision { get; set; }
        [Required]
        public int IdTurno { get; set; }
        [Required]
        public int IdEspecialidad { get; set; }
        [Required]
        public int Prioridad { get; set; }
        [Required]
        public int Contador { get; set; }
        public int Edad { get; set; }
        [Required]
        public bool AtencionEspecial { get; set; }
    }
}
