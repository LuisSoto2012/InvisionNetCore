// SubirVoucherDto.cs20:5120:51

using System;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones
{
    public class SubirVoucherDto
    {
        public int IdCita { get; set; }
        public string NumeroDocumento { get; set; }
        public string RutaCompleta { get; set; }
        public string Voucher { get; set; }
        public DateTime FechaPago { get; set; }
    }
}