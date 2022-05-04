// ComprobantePagoDto.cs19:2519:25

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Respuestas
{
    public class ComprobantePagoDto
    {
        // Fecha -> FechaEmision
        // Numero -> Serie + NroDoc
        // TipoDoc -> De acuerdo al IdTipoDocuemtno -> NC,ND,Ret
        // TipoDocIdentidad -> 1: DNI, 6: RUC
        // NumeroDocIdentidad -> NroDocumentoProv
        // ReceptorRazonSocial -> NombreProveedor
        // Total - > Total
        // Estado -> 0: ANULADO, 1: REGISTRADO, 2: ENVIADO, 3: ACEPTADO

        public string FechaEmision { get; set; }
        public string Documento { get; set; }
        public string TipoDoc { get; set; }
        public string TipoDocIdentidad { get; set; }
        public string NroDocIdentidad { get; set; }
        public string ReceptorRazonSocial { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
    }
}