using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas
{
    public class HistorialCentroQuirurgico
    {
        public int Id { get; set; }
        public DateTime FechaCirugia { get; set; }
        public int? NroHistoriaClinica { get; set; }
        public string Paciente { get; set; }
        public string Medico { get; set; }
        public string CIE10 { get; set; }
        public string Diagnostico { get; set; }
        public string Procedimiento { get; set; }
        public string TipoCirugia { get; set; }
    }
}
