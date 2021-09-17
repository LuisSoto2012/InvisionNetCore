// EvalResultadoDto.cs23:4723:47

using System;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas
{
    public class EvalResultadoDto
    {
        public int RowNumber { get; set; }
        public string Pregunta { get; set; }
        public DateTime Fecha { get; set; }
        public string FechaStr { get; set; }
        public string RptaIngresada { get; set; }
        public string RptaCorrecta { get; set; }
    }
}