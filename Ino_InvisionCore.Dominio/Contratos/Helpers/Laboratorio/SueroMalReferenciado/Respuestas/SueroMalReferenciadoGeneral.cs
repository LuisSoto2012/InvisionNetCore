using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SueroMalReferenciado.Respuestas
{
    public class SueroMalReferenciadoGeneral
    {
        public int IdSueroMalReferenciado { get; set; }
        public int IdAreaLaboratorio { get; set; }
        public bool TieneReferencia { get; set; }
        public int NumeroMes { get; set; }
        public string NombreMes { get; set; }
        public string Observaciones { get; set; }
        public string AreaLaboratorio { get; set; }
        public bool EsActivo { get; set; }
        public string FechaCreacion { get; set; }
        public string Origen { get; set; }
    }
}
