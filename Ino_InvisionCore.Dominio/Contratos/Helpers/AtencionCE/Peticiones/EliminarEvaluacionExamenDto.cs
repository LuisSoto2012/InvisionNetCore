using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Peticiones
{
    public class EliminarEvaluacionExamenDto
    {
        public int IdEvaluacionExamen { get; set; }
        public int IdAtencion { get; set; }
        public int IdUsuarioModificacion { get; set; }
    }
}
