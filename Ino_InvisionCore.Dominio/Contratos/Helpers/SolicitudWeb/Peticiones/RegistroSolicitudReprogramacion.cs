using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones
{
    public class RegistroSolicitudReprogramacion
    {
        public int IdCuentaAtencion { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string NumeroDocumento { get; set; }
        public string TelefonoMovil { get; set; }
        public string Correo { get; set; }
        public int IdDepartamento { get; set; }
        public int IdProvincia { get; set; }
        public int IdDistrito { get; set; }
        public string MotivoInasistencia { get; set; }
    }
}
