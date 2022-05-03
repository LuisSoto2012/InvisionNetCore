using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PocoFrecuente.Peticiones
{
    public class NuevoPocoFrecuente
    {
        public int IdAreaLaboratorio { get; set; }
        public int IdPrueba { get; set; }
        public string NombrePrueba { get; set; }
        public int NumeroMes { get; set; }
        public int Total { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public bool LaminaCuaderno { get; set; }
        public bool CuadernoPaciente { get; set; }
        public bool CuadernoSistema { get; set; }
        public bool SistemaCuaderno { get; set; }
        public ComboBox Origen { get; set; }
    }
}
