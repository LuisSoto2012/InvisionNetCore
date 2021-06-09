using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Respuestas
{
    public class SolicitudReprogramacionCitaCuarentenaDto
    {
        public int IdSolicitud { get; set; }
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
        public int IdEstado { get; set; }
        public string FechaCreacion { get; set; }
        public int IdUsuarioReprograma { get; set; }
        public string NuevaFechaReprogramacion { get; set; }
    }
}
