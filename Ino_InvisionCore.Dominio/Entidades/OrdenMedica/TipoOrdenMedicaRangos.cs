using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.OrdenMedica
{
    public class TipoOrdenMedicaRangos : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdTipoOrdenMedicaRangos { get; set; }
        [Required]
        public int Inicial { get; set; }
        [Required]
        public int Final { get; set; }
        [StringLength(500)]
        public string Condicionales { get; set; }
        [Required]
        public int IdTipoOrdenMedica { get; set; }
        [JsonIgnore]
        public TipoOrdenMedica TipoOrdenMedica { get; set; }
    }
}
