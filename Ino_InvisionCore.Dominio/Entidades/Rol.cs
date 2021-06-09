using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class Rol : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdRol { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Empleado> Empleado { get; set; }
        [JsonIgnore]
        public virtual IList<EmpleadoRol> EmpleadoRoles { get; set; }

        [JsonIgnore]
        public virtual IList<RolSubModulo> RolSubModulos { get; set; }

        public Rol()
        {
            //this.Empleado = new HashSet<Empleado>();
        }
    }
}
