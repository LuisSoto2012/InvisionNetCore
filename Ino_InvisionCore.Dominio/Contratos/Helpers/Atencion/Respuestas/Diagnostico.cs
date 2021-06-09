using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas
{
    public class Diagnostico
    {
        public int IdDiagnostico { get; set; }
        public string CodigoCIE10 { get; set; }
        public string Descripcion { get; set; }
    }
}
