using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class CodigosRespuestaIndicadoresDesempeno : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(4)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }
    }
}
