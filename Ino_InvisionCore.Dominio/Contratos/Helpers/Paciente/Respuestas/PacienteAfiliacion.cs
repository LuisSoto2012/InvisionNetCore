using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas
{
    public class PacienteAfiliacion
    {
        public int IdPaciente { get; set; }
        public string NroHistoriaClinica { get; set; }
        public string NroDocumento { get; set; }
        public string Paciente { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Financiamiento { get; set; }
        public string FechaInscripcion { get; set; }
        public string TipoPaciente { get; set; }
        public string Correo { get; set; }
    }
}
