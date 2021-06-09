using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Peticiones
{
    public class ActualizarTicketConsultaExterna
    {
        public int IdTicketConsultaExterna { get; set; }
        public int IdImpresion { get; set; }
        public int IdImpresionRevision { get; set; }
    }
}
