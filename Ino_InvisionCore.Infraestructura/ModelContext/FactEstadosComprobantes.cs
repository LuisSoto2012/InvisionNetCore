using System;
using System.Collections.Generic;

namespace Ino_InvisionCore.Infraestructura.ModelContext
{
    public partial class FactEstadosComprobantes
    {
        public FactEstadosComprobantes()
        {
            FactComprobantesPago = new HashSet<FactComprobantesPago>();
        }

        public int IdEstadoComprobante { get; set; }
        public string Descripcion { get; set; }

        public ICollection<FactComprobantesPago> FactComprobantesPago { get; set; }
    }
}
