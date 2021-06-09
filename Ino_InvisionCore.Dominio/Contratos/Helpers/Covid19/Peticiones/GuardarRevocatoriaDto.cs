using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Peticiones
{
    public class GuardarRevocatoriaDto
    {
        public int IdCI { get; set; }
        public bool? RevCI_P1 { get; set; }
        public bool? RevCI_P2 { get; set; }
        public bool? RevCI_P3 { get; set; }

        public int IdUsuarioRegistro { get; set; }
    }
}
