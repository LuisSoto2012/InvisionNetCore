using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Peticiones
{
    public class ActualizarRendimientoHoraTrabajador
    {
        public int IdRendimientoHoraTrabajador { get; set; }
        public int NumeroMes { get; set; }
        public int Horas { get; set; }
        public int ExamenesProcesados { get; set; }
        public int NumeroTrabajadores { get; set; }
        public int IdAreaLaboratorio { get; set; }
        public bool EsActivo { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
