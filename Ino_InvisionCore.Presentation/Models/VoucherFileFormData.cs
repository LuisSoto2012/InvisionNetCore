// VoucherFileFormData.cs21:0421:04

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Ino_InvisionCore.Presentation.Models
{
    public class VoucherFileFormData
    {
        public int IdCita { get; set; }
        public IList<IFormFile> Imagen { get; set; }
        public string NumeroDocumento { get; set; }
        public string Voucher { get; set; }
    }
}