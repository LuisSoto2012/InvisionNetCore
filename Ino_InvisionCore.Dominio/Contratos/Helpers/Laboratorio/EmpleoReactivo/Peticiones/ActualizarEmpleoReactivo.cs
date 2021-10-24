using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EmpleoReactivo.Peticiones
{
    public class ActualizarEmpleoReactivo
    {
        public int IdAreaLaboratorio { get; set; }
        public int IdEmpleoReactivo { get; set; }
        public int TotalDeReactivos { get; set; }
        public int NumeroMes { get; set; }
        public int Vencidos { get; set; }
        public bool EsActivo { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public string Origen { get; set; }
    }
}
