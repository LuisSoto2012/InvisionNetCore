using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Peticiones
{
    public class NuevoAdicional
    {
        public int IdAdicional { get; set; }
        public string Hc { get; set; }
        public string Paciente { get; set; }
        public int IdEspecialidad { get; set; }
        public int IdServicio { get; set; }
        public int IdMedico { get; set; }
        public DateTime FechaAdicional { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuario { get; set; }
    }
}
