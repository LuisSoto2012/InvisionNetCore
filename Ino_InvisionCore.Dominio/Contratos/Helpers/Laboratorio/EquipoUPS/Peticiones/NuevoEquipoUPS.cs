using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoUPS.Peticiones
{
    public class NuevoEquipoUPS
    {
        public int IdAreaLaboratorio { get; set; }
        public bool TieneUPS { get; set; }
        public int NumeroMes { get; set; }
        public string Observaciones { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
