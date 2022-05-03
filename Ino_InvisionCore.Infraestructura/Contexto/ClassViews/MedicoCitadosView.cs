using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class MedicoCitadosView
    {
        [Key]
        public Int64 RowNumber { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public int IdProgramacion { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
    }
}
