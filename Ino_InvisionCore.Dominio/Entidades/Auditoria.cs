using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades
{
    public class Auditoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdAuditoria { get; set; }
        [StringLength(200)]
        public string Accion { get; set; }
        [StringLength(200)]
        public string NombreTabla { get; set; }
        public string ValoresAntiguos { get; set; }
        public string ValoresNuevos { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int IdUsuario { get; set; }
        [StringLength(50)]
        public string IpLogueo{ get; set; }
    }
}
