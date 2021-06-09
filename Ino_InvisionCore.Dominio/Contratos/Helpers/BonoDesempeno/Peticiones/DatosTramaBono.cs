using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Peticiones
{
    public class DatosTramaBono
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int IdEspecialidad { get; set; }
        public char Tipo_Paciente { get; set; } = 'T';
        public int? IdServicio { get; set; }
    }
}
