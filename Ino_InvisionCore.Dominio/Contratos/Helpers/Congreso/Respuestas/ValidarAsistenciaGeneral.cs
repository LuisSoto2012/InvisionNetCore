using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Respuestas
{
    public class ValidarAsistenciaGeneral
    {
        public string NombreHorario { get; set; }
        public int IdEventoAsistencia { get; set; }
        public int IdEvento { get; set; }
        public int IdParticipante { get; set; }
        public int IdHorario { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
