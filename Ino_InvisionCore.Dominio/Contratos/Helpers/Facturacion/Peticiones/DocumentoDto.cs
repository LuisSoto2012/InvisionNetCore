// DocumentoDto.cs22:1822:18

using System;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones
{
    public class DocumentoDto
    {
        public int IdComprobantePago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Numero { get; set; }
        public decimal Pagado { get; set; }
        public decimal Retencion { get; set; }
        public string TipoDocumento { get; set; }
    }
}