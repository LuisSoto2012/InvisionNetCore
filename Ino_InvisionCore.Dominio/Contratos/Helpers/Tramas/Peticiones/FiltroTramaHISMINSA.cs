using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Peticiones
{
    public class FiltroTramaHISMINSA
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int IdEspecialidad { get; set; }
    }
}
