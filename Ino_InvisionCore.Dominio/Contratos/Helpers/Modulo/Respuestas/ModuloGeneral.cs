using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas
{
    public class ModuloGeneral
    {
        public int IdModulo { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public string Icono { get; set; }
        public bool EsActivo { get; set; }
        public List<SubModuloGeneral> SubModulos { get; set; }
    }
}
