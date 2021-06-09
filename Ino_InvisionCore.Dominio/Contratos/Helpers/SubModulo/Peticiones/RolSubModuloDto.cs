using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Peticiones
{
    public class RolSubModuloDto
    {
        public int IdRolSubModulo { get; set; }
        public int IdRol { get; set; }
        public int IdSubModulo { get; set; }
        public bool Ver { get; set; }
        public bool Agregar { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
        public bool EsActivo { get; set; }
        public int IdUsuarioRegistra { get; set; }
    }
}
