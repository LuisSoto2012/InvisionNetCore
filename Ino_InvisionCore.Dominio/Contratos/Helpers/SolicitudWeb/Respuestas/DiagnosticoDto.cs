using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Respuestas
{
    public class DiagnosticoDto
    {
        public int IdDiagnostico { get; set; }
        public string CIE10 { get; set; }
        public string Descripcion { get; set; }
        public string TipoDX { get; set; }
        public string Ojo { get; set; }
    }
}
