using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class CitaGalenosTicketView
    {
        [Key]
        public int IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        public string Turno { get; set; }
        public string Servicio { get; set; }
        public string Medico { get; set; }
        public int NroHistoriaClinica { get; set; }
        public int NumeroCuenta { get; set; }
        public string Paciente { get; set; }
        public string FuenteFinanciamiento { get; set; }
    }
}
