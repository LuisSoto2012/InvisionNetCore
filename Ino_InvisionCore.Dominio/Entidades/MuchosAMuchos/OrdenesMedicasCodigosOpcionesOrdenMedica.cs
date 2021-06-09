using Ino_InvisionCore.Dominio.Entidades.OrdenMedica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos
{
    public class OrdenesMedicasCodigosOpcionesOrdenMedica
    {
        public int IdOrdenesMedicasCodigos { get; set; }
        public OrdenesMedicasCodigos OrdenesMedicasCodigos { get; set; }

        public int IdOpcionOrdenMedica { get; set; }
        public OpcionesOrdenMedica OpcionesOrdenMedica { get; set; }
    }
}
