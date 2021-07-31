using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Peticiones
{
    public class BuscarPaciente
    {
        public DateTime Fecha { get; set; }
        public int IdMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public string Hc { get; set; }
    }
}
