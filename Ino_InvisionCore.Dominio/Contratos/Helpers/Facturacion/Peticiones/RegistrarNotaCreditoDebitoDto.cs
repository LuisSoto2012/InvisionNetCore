// RegistrarNotaCreditoDebitoDto.cs18:1018:10

using System;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones
{
    public class RegistrarNotaCreditoDebitoDto
    {
        public int IdTipoDocProv { get; set; }
        public string NumeroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public int? TipoOperacionGravada { get; set; }
        public string NumeroHistoriaClinica { get; set; }
        public string Paciente { get; set; }
        public ComboBox TipoDocumento { get; set; }
        public ComboBox TipoOperacion { get; set; }
        public int? IdComprobantePagoGalenos { get; set; }
        public string Motivo { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public string Usuario { get; set; }
        public bool? Contingencia { get; set; }
        public DateTime FechaEmision { get; set; }
        public bool? DocElectronico { get; set; }
        public string DocumentoSeleccionado { get; set; }
        public string Direccion { get; set; }
        public decimal? TotalComprobante { get; set; }
    }
}