using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas
{
    public class ProcedimientoDto
    {
        public int IdProcedimiento { get; set; }
        public int IdTipoOrdenMedica { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionCorta { get; set; }
    }
}
