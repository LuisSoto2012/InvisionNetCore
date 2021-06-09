using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class CuposPorProgramacionView
    {
        [Key]
        public Int64 RowId { get; set; }
        public string Cupo { get; set; }
    }
}
