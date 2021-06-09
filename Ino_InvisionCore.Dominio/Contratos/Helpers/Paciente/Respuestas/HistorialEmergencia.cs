using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas
{
    public class HistorialEmergencia
    {
        public int IdEmergencia { get; set; }
        public int? NroHistoriaClinica { get; set; }
        public string Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public string Medico { get; set; }
        public string Residente { get; set; }
    }
}
