using System;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class AtencionConstanciaTop5View
    {
        public int IdCuentaAtencion { get; set; }
        public string Ate { get; set; }
        public DateTime FechaAtencion { get; set; }
        public string EstadoAtencion { get; set; }
    }
}