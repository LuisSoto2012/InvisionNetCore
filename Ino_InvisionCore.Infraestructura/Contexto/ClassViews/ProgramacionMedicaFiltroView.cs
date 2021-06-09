using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class ProgramacionMedicaFiltroView
    {
        [Key]
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public int IdProgramacion { get; set; }
    }
}
