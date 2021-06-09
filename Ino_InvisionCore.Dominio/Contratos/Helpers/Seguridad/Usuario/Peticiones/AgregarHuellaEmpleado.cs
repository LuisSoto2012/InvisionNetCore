using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones
{
    public class AgregarHuellaEmpleado
    {
        public int IdEmpleado { get; set; }
        public string RutaHuella { get; set; }
        public string RutaRostro { get; set; }
    }
}
