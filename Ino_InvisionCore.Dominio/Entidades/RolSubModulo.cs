using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class RolSubModulo : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdRolSubModulo { get; set; }
        // Set the column order so it appears nice in the database
        [ForeignKey("Rol")]
        public int IdRol { get; set; }
        [ForeignKey("SubModulo")]
        public int IdSubModulo { get; set; }
        // Add the navigation properties
        [JsonIgnore]
        public virtual Rol Rol { get; set; }
        [JsonIgnore]
        public virtual SubModulo SubModulo { get; set; } 
        // Add any additional fields you need
        public bool Ver { get; set; }
        public bool Agregar { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
    }
}
