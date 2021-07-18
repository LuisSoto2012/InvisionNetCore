// CupoProgramacionView.cs03:2003:20

using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class CupoProgramacionView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int IdProgramacion { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Estado { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
    }
}