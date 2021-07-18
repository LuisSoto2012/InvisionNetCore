// PacienteCitaWeb.cs00:4200:42

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;

namespace Ino_InvisionCore.Dominio.Entidades.CitasWeb
{
    public class PacienteCitaWeb : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required] public int IdPacienteGalenos { get; set; }
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
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [StringLength(15)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(20)]
        public string TelefonoMovil { get; set; }
        [Required]
        [StringLength(500)]
        public string Direccion { get; set; }
        [Required] public int IdSexo { get; set; }
        [Required] public int IdEstadoCivil { get; set; }
        [Required] public int IdTipoDocumento { get; set; }  
        [Required]
        [StringLength(500)]
        public string CorreoElectronico { get; set; }
        [Required]
        [StringLength(50)]
        public string Usuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Contrasena { get; set; }

        public int IdRol { get; set; }
        [JsonIgnore]
        public virtual Rol Rol { get; set; }

        public PacienteCitaWeb()
        {
            //this.Roles = new HashSet<Rol>();
            //this.Aplicaciones = new HashSet<Aplicacion>();
        }
    }
}