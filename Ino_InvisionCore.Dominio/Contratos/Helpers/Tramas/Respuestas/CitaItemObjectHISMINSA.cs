using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Respuestas
{
    public class CitaItemObjectHISMINSA
    {
        public object[] labs { get; set; }
        public string tipodiagnostico { get; set; }
        public string codigo { get; set; }
        public string tipoitem { get; set; } = "CX";
    }
}
