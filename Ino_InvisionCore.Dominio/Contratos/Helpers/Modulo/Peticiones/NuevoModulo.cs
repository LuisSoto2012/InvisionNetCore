using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Peticiones
{
    public class NuevoModulo
    {
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public string Icono { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
