using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class VenopunturasFallidas : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdVenopunturasFallidas { get; set; }
        [Required]
        [StringLength(10)]
        public string HistoriaClinica { get; set; }
        [StringLength(10)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(500)]
        public string Paciente { get; set; }
        public bool PacientesAdultosMayoresONinos { get; set; }
        public bool VenasDificiles { get; set; }
        public bool PacienteConPatologiaSubyacente { get; set; }
        [Required]
        public DateTime FechaOcurrencia { get; set; }
        public string Comentario { get; set; }
    }
}
