using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.Models
{
    public class UsuarioLoginModel
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public int IdAplicacion { get; set; }
    }
}
