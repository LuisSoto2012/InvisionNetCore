using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas
{
    public class HistorialLaboratorio
    {
        public int IdMovimiento { get; set; }
        public int? NroHistoriaClinica { get; set; }
        public string Paciente { get; set; }
        public int IdLabEstado { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Medico { get; set; }
    }
}
