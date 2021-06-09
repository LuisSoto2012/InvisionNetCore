using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas
{
    public class ModuloMenu
    {
        public int IdModulo { get; set; }
        public string Modulo { get; set; }
        public string Icono { get; set; }
        public int Orden { get; set; }
        public List<SubModuloMenu> SubModulo { get; set; }
    }
}
