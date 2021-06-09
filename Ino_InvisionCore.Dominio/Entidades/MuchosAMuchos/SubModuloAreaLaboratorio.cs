using Ino_InvisionCore.Dominio.Entidades.Comunes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos
{
    public class SubModuloAreaLaboratorio
    {
        public int IdSubModulo { get; set; }
        public SubModulo SubModulo { get; set; }

        public int IdAreaLaboratorio { get; set; }
        public AreaLaboratorio AreaLaboratorio { get; set; }
    }
}
