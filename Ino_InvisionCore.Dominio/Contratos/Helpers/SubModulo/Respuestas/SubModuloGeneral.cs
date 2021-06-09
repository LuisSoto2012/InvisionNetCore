using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas
{
    public class SubModuloGeneral
    {
        public int IdSubModulo { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public string Ruta { get; set; }
        public bool EsActivo { get; set; }
        public int IdModulo { get; set; }
        public bool ConPermisos { get; set; }
    }
}
