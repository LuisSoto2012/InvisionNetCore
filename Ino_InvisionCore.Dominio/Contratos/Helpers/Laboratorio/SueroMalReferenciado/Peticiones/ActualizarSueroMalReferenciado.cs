using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SueroMalReferenciado.Peticiones
{
    public class ActualizarSueroMalReferenciado
    {
        public int IdSueroMalReferenciado { get; set; }
        public int IdAreaLaboratorio { get; set; }
        public bool TieneReferencia { get; set; }
        public int NumeroMes { get; set; }
        public string Observaciones { get; set; }
        public bool EsActivo { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
