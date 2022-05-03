using System;
using System.Collections.Generic;

namespace Ino_InvisionCore.Infraestructura.ModelContext
{
    public partial class FactComprobantesPago
    {
        public FactComprobantesPago()
        {
            FactComprobantesPagoDetalle = new HashSet<FactComprobantesPagoDetalle>();
        }

        public int IdComprobantePago { get; set; }
        public string NroSerie { get; set; }
        public string NroDocumento { get; set; }
        public int? IdTipoDocProv { get; set; }
        public string NroDocumentoProv { get; set; }
        public string NombreProveedor { get; set; }
        public int? TipoOperacion { get; set; }
        public string NroHistoriaClinica { get; set; }
        public string Paciente { get; set; }
        public int? IdTipoDocumento { get; set; }
        public int? IdTipoOperacion { get; set; }
        public int? IdComprobantePagoGalenos { get; set; }
        public string Concepto { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Igv { get; set; }
        public decimal? IgvCalc { get; set; }
        public decimal? Total { get; set; }
        public string TotalLetras { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool? Contingencia { get; set; }
        public DateTime? FechaEmision { get; set; }

        public FactEstadosComprobantes EstadoNavigation { get; set; }
        public FactTipoDocumento IdTipoDocumentoNavigation { get; set; }
        public FactTipoOperacion IdTipoOperacionNavigation { get; set; }
        public ICollection<FactComprobantesPagoDetalle> FactComprobantesPagoDetalle { get; set; }
    }
}
