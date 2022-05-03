using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones
{
    public class RechazarVoucherDto
    {
        public int IdCita { get; set; }
        public int IdUsuario { get; set; }
        public string MotivoRechazo { get; set; }
    }
}
