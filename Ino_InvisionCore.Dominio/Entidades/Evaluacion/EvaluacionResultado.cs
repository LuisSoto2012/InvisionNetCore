// Evaluacion.cs23:2923:29

using System;

namespace Ino_InvisionCore.Dominio.Entidades.Evaluacion
{
    public class EvaluacionResultado
    {
        public int Id { get; set; }
        public string Modulo { get; set; }
        public int IdParticipante { get; set; }
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public string IdRespuesta { get; set; }
        public string Respuesta { get; set; }
        public string IdRespuestaCorrecta { get; set; }
        public string RespuestaCorrecta { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}