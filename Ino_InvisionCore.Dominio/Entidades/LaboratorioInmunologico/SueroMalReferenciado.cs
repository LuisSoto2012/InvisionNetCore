using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class SueroMalReferenciado :  BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdSueroMalReferenciado { get; set; }
        [Required]
        public int IdAreaLaboratorio { get; set; }
        [Required]
        public bool TieneReferencia { get; set; }
        [Required]
        public int NumeroMes { get; set; }
        public string Observaciones { get; set; }
        public string Origen { get; set; }
        [JsonIgnore]
        public virtual AreaLaboratorio AreaLaboratorio { get; set; }
    }
}
