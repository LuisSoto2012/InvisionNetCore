using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas
{
    public class MedicoCitadosDto
    {
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public int IdProgramacion { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
    }
}
