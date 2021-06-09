using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class EquipoMalCalibrado : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdEquipoMalCalibrado { get; set; }
        [Required]
        public int IdAreaLaboratorio { get; set; }
        [Required]
        public int TotalDeEquipos { get; set; }
        [Required]
        public int NumeroMes { get; set; }
        [Required]
        public int Inadecuados { get; set; }
        [JsonIgnore]
        public virtual AreaLaboratorio AreaLaboratorio { get; set; }
    }
}
