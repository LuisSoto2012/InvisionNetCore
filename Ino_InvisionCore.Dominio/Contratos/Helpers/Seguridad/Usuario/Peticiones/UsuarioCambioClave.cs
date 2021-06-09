using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones
{
    public class UsuarioCambioClave
    {
        public string Usuario { get; set; }
        public string ClaveAntigua { get; set; }
        public string ClaveNueva { get; set; }
        public string ClaveNuevaRepetida { get; set; }
        public int IdUsuarioModificacion { get; set; }
    }
}
