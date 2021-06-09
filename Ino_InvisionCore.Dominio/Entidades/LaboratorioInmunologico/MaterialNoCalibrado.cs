using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class MaterialNoCalibrado : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdMaterialNoCalibrado { get; set; }
        [Required]
        public int IdAreaLaboratorio { get; set; }
        [Required]
        public int NumeroMes { get; set; }
        [Required]
        public int Calibrado { get; set; }
        [Required]
        public int NoCalibrado { get; set; }
        [Required]
        public int Inoperativo { get; set; }
        [Required]
        public int Total { get; set; }
        [JsonIgnore]
        public virtual AreaLaboratorio AreaLaboratorio { get; set; }
    }
}
