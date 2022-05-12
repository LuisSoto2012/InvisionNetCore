// ComprobantePagoGalenosView.cs23:4523:45

using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class ComprobantePagoGalenosView
    {
        [Key]
        public int IdComprobantePago { get; set; }
        public string NroSerie { get; set; }
        public string NroDocumento { get; set; }
        public string Numero { get; set; }
        public string NumeroDocumentoProveedor { get; set; }
        public string Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
    }
}