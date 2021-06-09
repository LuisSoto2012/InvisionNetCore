using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class AtencionTrabajador_Diagnostico : BaseGeneral
    {
        public int Id { get; set; }
        [ForeignKey("AtencionTrabajador")]
        public int IdAtencionTrabajador { get; set; }
        public int IdDiagnostico { get; set; }
        // Add the navigation properties
        [JsonIgnore]
        public AtencionTrabajador AtencionTrabajador { get; set; }
        [Required]
        [StringLength(20)]
        public string TipoDiagnostico { get; set; }

    }
}
