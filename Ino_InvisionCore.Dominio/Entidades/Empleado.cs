using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class Empleado : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdEmpleado { get; set; }
        [Required]
        [StringLength(200)]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(200)]
        public string ApellidoMaterno { get; set; }
        [Required]
        [StringLength(200)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(500)]
        public string Correo { get; set; }
        [Required]
        public int IdCondicionTrabajo { get; set; }
        [Required]
        public int IdTipoEmpleado { get; set; }
        [Required]
        public int IdTipoDocumento { get; set; }
        [Required]
        [StringLength(10)]
        public string NumeroDocumento { get; set; }
        [StringLength(20)]
        public string CodigoPlanilla { get; set; }
        [Required]
        [StringLength(50)]
        public string Usuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Contrasena { get; set; }
        public bool LoginEstado { get; set; }
        public string LoginIp { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Rol> Roles { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Aplicacion> Aplicaciones { get; set; }

        public string RutaHuella { get; set; }
        public string RutaRostro { get; set; }
        //public string RutaVoz { get; set; }
        public string SecurityPIN { get; set; }
        public DateTime? FechaPIN { get; set; }

        [JsonIgnore]
        public virtual CondicionTrabajo CondicionTrabajo { get; set; }
        [JsonIgnore]
        public virtual TipoEmpleado TipoEmpleado { get; set; }
        [JsonIgnore]
        public virtual TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; }
        [JsonIgnore]
        public virtual ICollection<AplicacionEmpleado> AplicacionEmpleados { get; set; }
        [JsonIgnore]
        public virtual IList<EmpleadoRol> EmpleadoRoles { get; set; }

        public Empleado()
        {
            //this.Roles = new HashSet<Rol>();
            //this.Aplicaciones = new HashSet<Aplicacion>();
        }
    }
}
