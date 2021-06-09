using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Respuestas
{
    public class ExamenAtendidoPorServicioDto
    {
        public int IdExamen { get; set; }
        public string FechaOcurrencia { get; set; }
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public int TotalPacientes { get; set; }
        public int EsActivo { get; set; }
        public string FechaCreacion { get; set; }
    }
}
