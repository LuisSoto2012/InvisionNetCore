using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones
{
    public class AgregarPINEmpleado
    {
        public int IdEmpleado { get; set; }
        public string SecurityPIN { get; set; }
    }
}
