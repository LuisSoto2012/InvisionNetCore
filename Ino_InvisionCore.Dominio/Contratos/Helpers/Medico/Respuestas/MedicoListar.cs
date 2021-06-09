using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas
{
    public class MedicoListar
    {
        public int IdMedico { get; set; }
        public int IdEmpleado { get; set; }
        public string Medico { get; set; }
    }
}
