using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas
{
    public class CitaPorDiaDto
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public string Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string NroDocumento { get; set; }
        public string NroHistoriaClinica { get; set; }
        public string Paciente { get; set; }
        public string Especialidad { get; set; }
        public string Servicio { get; set; }
        public string Medico { get; set; }
    }
}
