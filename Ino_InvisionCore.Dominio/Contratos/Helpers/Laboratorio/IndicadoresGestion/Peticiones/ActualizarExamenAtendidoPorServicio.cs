using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Peticiones
{
    public class ActualizarExamenAtendidoPorServicio
    {
        public int IdExamen { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public int TotalPacientes { get; set; }
        public bool EsActivo { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
