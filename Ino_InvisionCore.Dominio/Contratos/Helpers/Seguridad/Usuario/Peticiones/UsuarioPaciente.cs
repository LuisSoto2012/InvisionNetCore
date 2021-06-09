using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones
{
    public class UsuarioPaciente
    {
        public string Correo { get; set; }
        public string NroDocumento { get; set; }
        public int IdEmpleado { get; set; }
    }
}
