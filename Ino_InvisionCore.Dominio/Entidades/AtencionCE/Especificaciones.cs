using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.AtencionCE
{
    public partial class Especificaciones
    {
        [Key]
        public int IdEspecificacion { get; set; }
        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }
    }
}
