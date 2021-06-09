using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Respuestas
{
    public class OrdenesMedicasCodigosGeneral
    {
        public int IdOrdenesMedicasCodigos { get; set; }
        public string Descripcion { get; set; }
        public int IdOrdenMedica { get; set; }
        public ProcedimientoDto Procedimiento { get; set; }
        public List<ComboBox> OpcionesOrdenMedica { get; set; }
    }
}
