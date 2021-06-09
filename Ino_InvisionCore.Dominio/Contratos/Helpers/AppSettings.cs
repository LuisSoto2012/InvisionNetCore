using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string UsuarioAdmin { get; set; }
        public string UrlToken { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Authorization { get; set; }
        public string UrlRegistro { get; set; }
        public string RutaDeRepositorio { get; set; }
    }
}
