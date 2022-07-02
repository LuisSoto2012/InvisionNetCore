using System;
using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Entidades.Facturacion
{
    public partial class FactComprobantesPagoDetalle
    {
        public int IdComprobantePagoDetalle { get; set; }
        public int? IdComprobantePago { get; set; }
        public int? IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Importe { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Monto { get; set; }
        public string Numero { get; set; }
        public decimal? Pagado { get; set; }
        public decimal? Retencion { get; set; }
        public string TipoDocumento { get; set; }

        public FactComprobantesPago IdComprobantePagoNavigation { get; set; }
    }
}
