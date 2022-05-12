// FactNroDocumento.cs22:5622:56

namespace Ino_InvisionCore.Dominio.Entidades.Facturacion
{
    public partial class FactNroDocumento
    {
        public int IdFactNroDocumento { get; set; }
        public int IdTipoComprobante { get; set; }
        public string NroSerie { get; set; }
        public string NroDocumento { get; set; }
        public string NroDocumentoInicial { get; set; }
        public string NroDocumentoFinal { get; set; }

        public FactTipoDocumento IdTipoComprobanteNavigation { get; set; }
    }
}