using System;
using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Entidades.Facturacion
{
    public partial class FactTipoOperacion
    {
        public FactTipoOperacion()
        {
            FactComprobantesPago = new HashSet<FactComprobantesPago>();
        }

        public int IdTipoOperacion { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public FactTipoDocumento IdTipoDocumentoNavigation { get; set; }
        public ICollection<FactComprobantesPago> FactComprobantesPago { get; set; }
    }
}
