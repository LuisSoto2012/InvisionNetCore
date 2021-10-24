using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MaterialNoCalibrado.Peticiones
{
    public class NuevoMaterialNoCalibrado
    {
        public int IdAreaLaboratorio { get; set; }
        public int NumeroMes { get; set; }
        public int Calibrado { get; set; }
        public int NoCalibrado { get; set; }
        public int Inoperativo { get; set; }
        public int Total { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public string Origen { get; set; }
    }
}
