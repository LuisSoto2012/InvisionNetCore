using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class PocoFrecuente : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdPocoFrecuente { get; set; }
        [Required]
        public int IdAreaLaboratorio { get; set; }
        [Required]
        public int IdPrueba { get; set; }
        [Required]
        [StringLength(200)]
        public string NombrePrueba { get; set; }
        [Required]
        public int NumeroMes { get; set; }
        [Required]
        public int Total { get; set; }
        [JsonIgnore]
        public virtual AreaLaboratorio AreaLaboratorio { get; set; }

        public PocoFrecuente()
        {

        }
    }
}
