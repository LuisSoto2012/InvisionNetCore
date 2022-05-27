// ReprogramacionesCuposLibresView.cs01:4301:43

using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class ReprogramacionesCuposLibresView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int IdProgramacion { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Cupo { get; set; }
    }
}