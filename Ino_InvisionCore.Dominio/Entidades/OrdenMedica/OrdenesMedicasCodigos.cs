using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.OrdenMedica
{
    public class OrdenesMedicasCodigos : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdOrdenesMedicasCodigos { get; set; }
        [Required]
        public int IdProcedimiento { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public int IdOrdenMedica { get; set; }
        [JsonIgnore]
        public OrdenesMedicas OrdenesMedicas { get; set; }
        [JsonIgnore]
        public virtual Procedimiento Procedimiento { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<OpcionesOrdenMedica> OpcionesOrdenMedica { get; set; }
        [JsonIgnore]
        public virtual IList<OrdenesMedicasCodigosOpcionesOrdenMedica> OrdenesMedicasCodigosOpcionesOrdenMedicas { get; set; }
    }
}
