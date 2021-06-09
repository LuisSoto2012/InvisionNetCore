using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Peticiones
{
    public class NuevoSubModulo
    {
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public string Ruta { get; set; }
        public int IdModulo { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
