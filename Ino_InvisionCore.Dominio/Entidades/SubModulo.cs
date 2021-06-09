using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class SubModulo : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdSubModulo { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        public int Orden { get; set; }
        [Required]
        [StringLength(500)]
        public string Ruta { get; set; }
        [Required]
        public int IdModulo { get; set; }
        [JsonIgnore]
        public Modulo Modulo { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<AreaLaboratorio> AreaLaboratorios { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Reporte> Reportes { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubModuloAreaLaboratorio> SubModuloAreaLaboratorios { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubModuloReporte> SubModuloReportes { get; set; }

        [JsonIgnore]
        public virtual ICollection<RolSubModulo> RolSubModulos { get; set; }

        public SubModulo()
        {
            //this.AreaLaboratorios = new HashSet<AreaLaboratorio>();
        }
    }
}
