using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class CitaPorDiaView
    {
        [Key]
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string NroDocumento { get; set; }
        public int NroHistoriaClinica { get; set; }
        public string Paciente { get; set; }
        public string Especialidad { get; set; }
        public string Servicio { get; set; }
        public string Medico { get; set; }
    }
}
