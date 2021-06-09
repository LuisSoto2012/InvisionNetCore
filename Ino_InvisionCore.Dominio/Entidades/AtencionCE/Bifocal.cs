using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.AtencionCE
{
    public partial class Bifocal
    {
        [Key]
        public int IdBifocal { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
