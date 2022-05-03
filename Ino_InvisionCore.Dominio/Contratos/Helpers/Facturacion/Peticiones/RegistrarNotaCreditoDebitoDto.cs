// RegistrarNotaCreditoDebitoDto.cs18:1018:10

using System;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones
{
    public class RegistrarNotaCreditoDebitoDto
    {
        public int IdTipoDocProv { get; set; }
        public string NroDocumentoProv { get; set; }
        public string NombreProveedor { get; set; }
        public int TipoOperacion { get; set; }
        public string NroHistoriClinica { get; set; }
        public string Paciente { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdTipoOperacion { get; set; }
        public int IdComprobantePagoGalenos { get; set; }
        public string Concepto { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public string Usuario { get; set; }
        public bool Contingencia { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}