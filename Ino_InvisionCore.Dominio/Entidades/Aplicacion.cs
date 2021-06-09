using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class Aplicacion : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdAplicacion { get; set; }
        [StringLength(100)]
        [Required]
        public string Nombre { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Empleado> Empleado { get; set; }
        [JsonIgnore]
        public virtual ICollection<AplicacionEmpleado> AplicacionEmpleados { get; set; }

        public Aplicacion()
        {
            //this.Empleado = new HashSet<Empleado>();
        }
    }
}
