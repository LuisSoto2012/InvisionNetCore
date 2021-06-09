using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class MedicoListarView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int IdMedico { get; set; }
        public int IdEmpleado { get; set; }
        public string Medico { get; set; }
    }
}
