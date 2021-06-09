using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones
{
    public class MedidaCorrectivaDto
    {
        public string Descripcion_MedidaCorrectiva { get; set; }
        public string Responsable_MedidaCorrectiva { get; set; }
        public DateTime FechaEjecucion_MedidaCorrectiva { get; set; }
        public string EstadoImplementacion_MedidaCorrectiva { get; set; }
    }
}
