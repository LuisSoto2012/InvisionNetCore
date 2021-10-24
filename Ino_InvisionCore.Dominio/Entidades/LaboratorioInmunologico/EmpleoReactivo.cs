using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class EmpleoReactivo : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdEmpleoReactivo{ get; set; }
        [Required]
        public int TotalDeReactivos { get; set; }
        [Required]
        public int NumeroMes { get; set; }
        [Required]
        public int Vencidos { get; set; }
        [Required]
        public int IdAreaLaboratorio { get; set; }
        public string Origen { get; set; }
        [JsonIgnore]
        public virtual AreaLaboratorio AreaLaboratorio { get; set; }
    }
}
