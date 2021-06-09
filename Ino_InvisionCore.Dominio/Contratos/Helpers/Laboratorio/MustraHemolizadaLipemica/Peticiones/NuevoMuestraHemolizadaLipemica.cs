using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MustraHemolizadaLipemica.Peticiones
{
    public class NuevoMuestraHemolizadaLipemica
    {
        public int IdAreaLaboratorio { get; set; }
        public string TipoPrueba { get; set; }
        public string HistoriaClinica { get; set; }
        public string NumeroDocumento { get; set; }
        public string Paciente { get; set; }
        public int NumeroMes { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
