// MedicoPorEspecialidadOldView.cs01:1901:19

using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class MedicoPorEspecialidadOldView
    {
        [Key]
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public int IdEspecialidad { get; set; }
    }
}