using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.Comunes
{
    public class CondicionTrabajo : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdCondicionTrabajo { get; set; }
        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }
        //[JsonIgnore]
        //public virtual int IdCondicionTrabajoEmpleado { get; set; }
        [JsonIgnore]
        public virtual Empleado Empleado { get; set; }
        public CondicionTrabajo()
        {

        }
    }
}
