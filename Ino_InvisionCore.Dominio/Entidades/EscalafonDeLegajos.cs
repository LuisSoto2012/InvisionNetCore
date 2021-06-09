using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class EscalafonDeLegajos : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdEscalafonDeLegajos { get; set; }
        [Required]
        [StringLength(3)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(20)]
        public string Seccion { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
