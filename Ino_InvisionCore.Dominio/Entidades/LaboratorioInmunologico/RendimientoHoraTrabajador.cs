using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class RendimientoHoraTrabajador : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdRendimientoHoraTrabajador { get; set; }
        [Required]
        public int NumeroMes { get; set; }
        [Required]
        public int Horas { get; set; }
        [Required]
        public int ExamenesProcesados { get; set; }
        [Required]
        public int NumeroTrabajadores { get; set; }
        [Required]
        public int IdAreaLaboratorio { get; set; }
        [JsonIgnore]
        public virtual AreaLaboratorio AreaLaboratorio { get; set; }
    }
}
