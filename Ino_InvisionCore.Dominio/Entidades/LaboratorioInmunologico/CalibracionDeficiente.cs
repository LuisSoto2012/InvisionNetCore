using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class CalibracionDeficiente : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdCalibracionDeficiente { get; set; }
        [Required]
        public int IdAreaLaboratorio { get; set; }
        [Required]
        public bool EstaCalibrado { get; set; }
        [Required]
        public int NumeroMes { get; set; }
        public string Observaciones { get; set; }
        [JsonIgnore]
        public virtual AreaLaboratorio AreaLaboratorio { get; set; }
    }
}
