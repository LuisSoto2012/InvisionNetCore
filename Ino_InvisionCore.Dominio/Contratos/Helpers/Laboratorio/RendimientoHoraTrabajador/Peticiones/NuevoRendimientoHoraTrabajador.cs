using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Peticiones
{
    public class NuevoRendimientoHoraTrabajador
    {
        public int NumeroMes { get; set; }
        public int Horas { get; set; }
        public int ExamenesProcesados { get; set; }
        public int NumeroTrabajadores { get; set; }
        public int IdAreaLaboratorio { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
