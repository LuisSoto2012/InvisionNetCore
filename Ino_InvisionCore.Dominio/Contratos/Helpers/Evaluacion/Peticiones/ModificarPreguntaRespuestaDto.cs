// ModificarPreguntaRespuestaDto.cs23:2723:27

using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones
{
    public class ModificarPreguntaRespuestaDto
    {
        public int Id { get; set; }
        public string Modulo { get; set; }
        public string Pregunta { get; set; }
        public List<EvalRespuestaDto> Respuestas { get; set; }
        public int IdUsuario { get; set; }
        public int Activo { get; set; }
    }
}