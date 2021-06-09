using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones
{
    public class EnviarCorreoCuarentenaDto
    {
        public int IdCuentaAtencion { get; set; }
        public string Correo { get; set; }
    }
}
