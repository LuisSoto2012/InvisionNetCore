using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class ComboBoxView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        [NotMapped]
        public string Codigo { get; set; }
    }
}
