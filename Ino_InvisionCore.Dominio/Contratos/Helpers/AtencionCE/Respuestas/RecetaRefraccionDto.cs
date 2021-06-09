using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Respuestas
{
    public class RecetaRefraccionDto
    {
        public int IdRecetaRefraccion { get; set; }

        public int IdCita { get; set; }

        public string Paciente { get; set; }
        public string NroDocumento { get; set; }
        public string DxOD { get; set; }
        public string DxOI { get; set; }

        public bool EstaImpreso { get; set; }
    }
}
