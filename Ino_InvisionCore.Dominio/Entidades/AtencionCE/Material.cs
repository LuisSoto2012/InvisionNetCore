using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.AtencionCE
{
    public partial class Material
    {
        [Key]
        public int IdMaterial { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
