using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas
{
    public class CitaGalenosTicketDto
    {
        public int IdCita { get; set; }
        public string FechaCita { get; set; }
        public string Turno { get; set; }
        public string Servicio { get; set; }
        public string Medico { get; set; }
        public int NroHistoriaClinica { get; set; }
        public int NumeroCuenta { get; set; }
        public string Paciente { get; set; }
        public string FuenteFinanciamiento { get; set; }
    }
}
