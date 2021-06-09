using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoMalCalibrado.Repuestas
{
    public class EquipoMalCalibradoGeneral
    {
        public int IdEquipoMalCalibrado { get; set; }
        public int IdAreaLaboratorio { get; set; }
        public int TotalDeEquipos { get; set; }
        public int NumeroMes { get; set; }
        public string NombreMes { get; set; }
        public int Inadecuados { get; set; }
        public bool EsActivo { get; set; }
        public string AreaLaboratorio { get; set; }
        public string FechaCreacion { get; set; }
    }
}
