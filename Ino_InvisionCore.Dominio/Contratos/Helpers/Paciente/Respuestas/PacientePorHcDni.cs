using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas
{
    public class PacientePorHcDni
    {
        public int IdPaciente { get; set; }
        public int? NroHistoriaClinica { get; set; }
        public string NroDocumento { get; set; }
        public string Paciente { get; set; }
        public int IdEspecialidad { get; set; }
        public bool Temporal { get; set; }
    }
}
