using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class AtencionTrabajador : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdAtencionTrabajador { get; set; }
        [Required]
        [StringLength(50)]
        public string TipoAtencion { get; set; }
        [Required]
        [StringLength(10)]
        public string HistoriaClinica { get; set; }
        [StringLength(10)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(500)]
        public string Paciente { get; set; }
        [StringLength(50)]
        public string Presion { get; set; }
        public int? Temperatura { get; set; }
        public int? Peso { get; set; }
        public int? Talla { get; set; }
        public int? Pulso { get; set; }
        public string Motivo { get; set; }
        public int? CantidadDias { get; set; }
        [JsonIgnore]
        public virtual ICollection<AtencionTrabajador_Diagnostico> AtencionTrabajador_Diagnosticos { get; set; }
    }
}
