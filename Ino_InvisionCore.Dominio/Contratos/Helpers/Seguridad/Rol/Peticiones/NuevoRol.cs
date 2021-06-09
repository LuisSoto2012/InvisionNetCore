using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Peticiones
{
    public class NuevoRol
    {
        public string Nombre { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
