// AgregarRespuestaPreguntaDto.cs23:2523:25

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones
{
    public class AgregarRespuestaPreguntaDto
    {
        public int IdParticipante { get; set; }
        public int IdPregunta { get; set; }
        public string Respuesta { get; set; }
    }
}