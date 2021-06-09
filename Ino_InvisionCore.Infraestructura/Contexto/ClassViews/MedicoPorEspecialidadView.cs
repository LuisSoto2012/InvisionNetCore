using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class MedicoPorEspecialidadView
    {
        [Key]
        //public Int64 RowId { get; set; }
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
    }
}
