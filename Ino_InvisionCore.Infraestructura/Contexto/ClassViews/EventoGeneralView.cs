using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class EventoGeneralView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
    }
}
