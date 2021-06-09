using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.OrdenMedica
{
    public class TipoOrdenMedica : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdTipoOrdenMedica { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Required]
        public int IdEspecialidad { get; set; }
        public int TamanoFormulario { get; set; }
        [StringLength(100)]
        public string TituloFormulario { get; set; }
        [JsonIgnore]
        public virtual ICollection<TipoOrdenMedicaRangos> TipoOrdenMedicaRangos { get; set; }
        //[JsonIgnore]
        //public virtual int IdTipoOrdenMedicaOrdenesMedicas { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrdenesMedicas> OrdenesMedicas { get; set; }
        [JsonIgnore]
        public virtual ICollection<TipoOrdenMedica_Procedimiento> TipoOrdenMedica_Procedimientos { get; set; }

    }
}
