using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SueroMalReferenciado.Peticiones
{
    public class NuevoSueroMalReferenciado
    {
        public int IdAreaLaboratorio { get; set; }
        public bool TieneReferencia { get; set; }
        public int NumeroMes { get; set; }
        public string Observaciones { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public ComboBox Origen { get; set; }
    }
}
