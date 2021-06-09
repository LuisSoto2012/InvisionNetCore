using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.OrdenMedica
{
    public class OpcionesOrdenMedica : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdOpcionOrdenMedica { get; set; }
        public string Descripcion { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<OrdenesMedicasCodigos> OrdenesMedicasCodigos { get; set; }
        [JsonIgnore]
        public virtual IList<OrdenesMedicasCodigosOpcionesOrdenMedica> OrdenesMedicasCodigosOpcionesOrdenMedicas { get; set; }
    }
}
