using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas
{
    public class PacienteCitado
    {
        public int IdPaciente { get; set; }
        public int? NroHistoriaClinica { get; set; }
        public string NroDocumento { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string PrimerNombre { get; set; }
        public string Especialidad { get; set; }
        public string Servicio { get; set; }
        public int IdArchivo { get; set; }
    }
}
