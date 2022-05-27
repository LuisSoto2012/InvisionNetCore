// ProgramacionPorFechaEspecialidadDto.cs01:3001:30

using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class ProgramacionPorFechaEspecialidadView
    {
        [Key]
        public int IdEspecialidad { get; set; }

        public int IdProgramacion { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public int IdServicio { get; set; }
    }
}