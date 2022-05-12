using System;
using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Entidades.Facturacion
{
    public partial class FactTipoDocumento
    {
        public FactTipoDocumento()
        {
            FactComprobantesPago = new HashSet<FactComprobantesPago>();
            FactNroDocumento = new HashSet<FactNroDocumento>();
            FactTipoOperacion = new HashSet<FactTipoOperacion>();
        }

        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }

        public ICollection<FactComprobantesPago> FactComprobantesPago { get; set; }
        public ICollection<FactNroDocumento> FactNroDocumento { get; set; }
        public ICollection<FactTipoOperacion> FactTipoOperacion { get; set; }
    }
}
