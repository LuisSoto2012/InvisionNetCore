using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Respuestas
{
    public class TiempoEsperaAtencion
    {
        public string NumeroDocumento { get; set; }
        public string FuenteFinanciamiento { get; set; }
        public string FechaTicket { get; set; }
        public string FechaAtencion { get; set; }
        public string TipoPaciente { get; set; }
        public string Especialidad { get; set; }
    }
}
