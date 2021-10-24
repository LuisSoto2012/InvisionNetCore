using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EmpleoReactivo.Peticiones
{
    public class NuevoEmpleoReactivo
    {
        public int IdAreaLaboratorio { get; set; }
        public int TotalDeReactivos { get; set; }
        public int NumeroMes { get; set; }
        public int Vencidos { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public string Origen { get; set; }
    }
}
