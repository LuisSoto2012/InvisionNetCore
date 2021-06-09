using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class Modulo : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdModulo { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        public int Orden { get; set; }
        [Required]
        [StringLength(50)]
        public string Icono { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubModulo> SubModulos { get; set; }
    }
}
