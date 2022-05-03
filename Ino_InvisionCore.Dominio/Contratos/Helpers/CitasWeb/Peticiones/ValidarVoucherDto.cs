// ValidarVoucherDto.cs20:4920:49

using System;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones
{
    public class ValidarVoucherDto
    {
        public int IdCita { get; set; }
        public int IdUsuario { get; set; }
        public string NroComprobante { get; set; }
        public DateTime? FechaEmisionComprobante { get; set; }
    }
}