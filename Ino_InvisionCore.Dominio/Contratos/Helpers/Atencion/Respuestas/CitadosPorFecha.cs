using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas
{
    public class CitadosPorFecha
    {
        public int IdEspecialidad { get; set; }
        public string Fecha { get; set; }
        public string Especialidad { get; set; }
        public int Conteo { get; set; }
    }
}
