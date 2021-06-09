using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class CitadosPorFechaView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int IdEspecialidad { get; set; }
        public string Fecha { get; set; }
        public string Especialidad { get; set; }
        public int Conteo { get; set; }
    }
}
