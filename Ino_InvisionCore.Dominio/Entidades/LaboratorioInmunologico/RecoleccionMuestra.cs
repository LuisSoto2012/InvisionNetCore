using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class RecoleccionMuestra : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdRecoleccionMuestra { get; set; }
        [Required]
        [StringLength(10)]
        public string HistoriaClinica { get; set; }
        [StringLength(10)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(500)]
        public string Paciente { get; set; }
        public bool RecoleccionInapropiada { get; set; }
        public bool MuestrasPerdidas { get; set; }
        public bool MuestrasMalRotuladas { get; set; }
        [Required]
        public DateTime FechaOcurrencia { get; set; }
        public string Comentario { get; set; }
    }
}
