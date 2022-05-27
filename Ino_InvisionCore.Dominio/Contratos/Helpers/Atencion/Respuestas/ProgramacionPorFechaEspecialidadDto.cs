// ProgramacionPorFechaEspecialidadDto.cs01:2901:29

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas
{
    public class ProgramacionPorFechaEspecialidadDto
    {
        // select  pm.IdEspecialidad, pm.IdProgramacion,m.IdMedico,
        // UPPER(e.ApellidoPaterno + ' ' + e.ApellidoMaterno + ', ' + e.Nombres) as Medico,
        // UPPER(s.Nombre) as Nombre, pm.Fecha, pm.HoraInicio, pm.HoraFin, s.IdServicio
        public int IdEspecialidad { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public int IdServicio { get; set; }
    }
}