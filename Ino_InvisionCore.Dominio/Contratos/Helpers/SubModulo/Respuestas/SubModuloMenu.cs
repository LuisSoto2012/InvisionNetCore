using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas
{
    public class SubModuloMenu
    {
        public int IdSubModulo { get; set; }
        public int IdModulo { get; set; }
        public string SubModulo { get; set; }
        public string Ruta { get; set; }
        public int Orden { get; set; }
        public bool Ver { get; set; }
        public bool Agregar { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
    }
}
