using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Reporte.Respuestas
{
    public class ReporteGeneral
    {
        public int IdReporte { get; set; }
        public string Nombre { get; set; }
        public string NombreSSRS { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public int Ancho { get; set; }
        public int TamanoDialog { get; set; }
    }
}
