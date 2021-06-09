using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class HistorialRiesgoQuirurgicoView
    {
        [Key]
        public Int64 RowId { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEKG { get; set; }
    }
}
