// RegistrarPreguntaRespuestaDto.cs22:2722:27

using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones
{
    public class RegistrarPreguntaRespuestaDto
    {
        public string Modulo { get; set; }
        public string Pregunta { get; set; }
        public List<EvalRespuestaDto> Respuestas { get; set; }
        public int IdUsuario { get; set; }
    }
}