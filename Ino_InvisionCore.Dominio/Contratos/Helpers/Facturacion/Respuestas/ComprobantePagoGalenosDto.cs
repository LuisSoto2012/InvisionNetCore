// ComprobantePagoGalenosDto.cs23:4023:40

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Respuestas
{
    public class ComprobantePagoGalenosDto
    {
        public int IdComprobantePago { get; set; }
        public string NroSerie { get; set; }
        public string NroDocumento { get; set; }
        public string Numero { get; set; }
        public string NumeroDocumentoProveedor { get; set; }
        public string Proveedor { get; set; }
        public string Fecha { get; set; }
        public decimal Total { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
    }
}