using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas
{
    public class RolGeneral
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public bool EsActivo { get; set; }
    }
}
