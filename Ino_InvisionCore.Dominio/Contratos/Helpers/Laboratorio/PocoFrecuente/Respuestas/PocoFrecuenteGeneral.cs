using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PocoFrecuente.Repuestas
{
    public class PocoFrecuenteGeneral
    {
        public int IdPocoFrecuente { get; set; }
        public int IdAreaLaboratorio { get; set; }
        public int IdPrueba { get; set; }
        public string NombrePrueba { get; set; }
        public int NumeroMes { get; set; }
        public int Total { get; set; }
        public bool EsActivo { get; set; }
        public string AreaLaboratorio { get; set; }
        public string NombreMes { get; set; }
        public string FechaCreacion { get; set; }
        public bool LaminaCuaderno { get; set; }
        public bool CuadernoPaciente { get; set; }
        public bool CuadernoSistema { get; set; }
        public bool SistemaCuaderno { get; set; }
        public string Origen { get; set; }
    }
}
