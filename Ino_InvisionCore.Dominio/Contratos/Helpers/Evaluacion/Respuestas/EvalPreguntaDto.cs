// EvalPreguntaDto.cs22:4522:45

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas
{
    public class EvalPreguntaDto
    {
        public int Id { get; set; }
        public string Modulo { get; set; }
        public string Pregunta { get; set; }
        public string RptaA { get; set; }
        public string RptaB { get; set; }
        public string RptaC { get; set; }
        public string RptaD { get; set; }
        public string RptaE { get; set; }
        public string RptaCorrecta { get; set; }
        public int Activo { get; set; }
        public string FechaCreacion { get; set; }
    }
}