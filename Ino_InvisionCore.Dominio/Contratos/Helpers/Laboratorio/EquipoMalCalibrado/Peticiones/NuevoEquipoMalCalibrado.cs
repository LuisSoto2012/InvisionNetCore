using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoMalCalibrado.Peticiones
{
    public class NuevoEquipoMalCalibrado
    {
        public int IdAreaLaboratorio { get; set; }
        public int TotalDeEquipos { get; set; }
        public int NumeroMes { get; set; }
        public int Inadecuados { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public ComboBox Origen { get; set; }
    }
}
