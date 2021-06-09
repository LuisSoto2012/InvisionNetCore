using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Peticiones
{
    public class AtencionesPor
    {
        public DateTime Fecha { get; set; }
        public int IdEspecialidad { get; set; }
        public int IdServicio { get; set; }
        public int IdMedico { get; set; }
    }
}
