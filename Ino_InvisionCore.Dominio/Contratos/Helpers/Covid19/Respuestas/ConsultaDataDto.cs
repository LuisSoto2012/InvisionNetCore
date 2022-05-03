using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Respuestas
{
    public class ConsultaDataDto
    {
        public int IdPersonalINO { get; set; }
        public int NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public int NumeroDosis { get; set; }
        public string FechaPrimeraDosis { get; set; }
        public string FechaSegundaDosis { get; set; }
        public string FechaTerceraDosis { get; set; }
        public bool TieneCI { get; set; }
    }
}
