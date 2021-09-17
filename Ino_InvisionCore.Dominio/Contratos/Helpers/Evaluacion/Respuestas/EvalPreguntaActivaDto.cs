// EvalPreguntaActivaDto.cs23:1123:11

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas
{
    public class EvalPreguntaActivaDto
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string[] Respuestas { get; set; }
        public string RespuestaCorrecta { get; set; }
    }
}