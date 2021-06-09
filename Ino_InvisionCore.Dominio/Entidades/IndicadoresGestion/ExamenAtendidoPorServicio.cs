using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.IndicadoresGestion
{
    public class ExamenAtendidoPorServicio : BaseGeneral
    {
        public int IdExamen { get; set; }
        public DateTime FechaOcurrencia { get; set; }
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public int TotalPacientes { get; set; }
    }
}
