using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Respuestas
{
    public class Adicionales
    {
        public int IdAdicional { get; set; }
        public string Hc { get; set; }
        public string Paciente { get; set; }
        public string Especialidad { get; set; }
        public string Medico { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaAdicional { get; set; }
    }
}
