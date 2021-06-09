using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.Comunes
{
    public class TipoEmpleado : BaseGeneral
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdTipoEmpleado { get; set; }
        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }
        //[JsonIgnore]
        //public virtual int IdTipoEmpleadoDeEmpleado { get; set; }
        [JsonIgnore]
        public virtual Empleado Empleado { get; set; }
    }
}
