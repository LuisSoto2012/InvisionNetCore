using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.OrdenMedica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.EntidadesView
{
    public class OrdenesMedicasCodigosView : BaseGeneral
    {
        public int IdOrdenesMedicasCodigos { get; set; }
        public string Descripcion { get; set; }
        public int IdOrdenMedica { get; set; }
        public Procedimiento Procedimiento { get; set; }
        public List<OpcionesOrdenMedicaView> OpcionesOrdenMedica { get; set; }
    }
}
