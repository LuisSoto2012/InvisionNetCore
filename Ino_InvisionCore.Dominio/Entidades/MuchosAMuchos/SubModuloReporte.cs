using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos
{
    public class SubModuloReporte
    {
        public int IdSubModulo { get; set; }
        public SubModulo SubModulo { get; set; }

        public int IdReporte { get; set; }
        public Reporte Reporte { get; set; }
    }
}
