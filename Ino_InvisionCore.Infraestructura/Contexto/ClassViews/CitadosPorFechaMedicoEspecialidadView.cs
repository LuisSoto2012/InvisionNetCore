using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class CitadosPorFechaMedicoEspecialidadView
    {
        public Int64 RowId { get; set; }
        public string NroHistoriaClinica { get; set; }
        public string Paciente { get; set; }
        public string FechaHoraSolicitud { get; set; }
    }
}
