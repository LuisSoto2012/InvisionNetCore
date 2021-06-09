using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.OrdenMedica;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class Procedimiento : BaseGeneral
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdProcedimiento { get; set; }
        [Required]
        [StringLength(20)]
        public string Codigo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string DescripcionCorta { get; set; }
        [Required]
        public int IdEspecialidad { get; set; }
        //[JsonIgnore]
        //public virtual int IdProcedimientoOrdenesMedicasCodigos { get; set; }
        [JsonIgnore]
        public virtual OrdenesMedicasCodigos OrdenesMedicasCodigos { get; set; }
        [JsonIgnore]
        public virtual ICollection<TipoOrdenMedica_Procedimiento> TipoOrdenMedica_Procedimientos { get; set; }
    }
}
