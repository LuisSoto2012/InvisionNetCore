// IRepositorioDeEvaluaciones.cs22:2622:26

using System.Collections.Generic;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Evaluacion
{
    public interface IRepositorioDeEvaluaciones
    {
        Task<RespuestaBD> RegistrarPreguntaYRespuestas(RegistrarPreguntaRespuestaDto solicitud);
        Task<IEnumerable<EvalPreguntaDto>> ListarPreguntas(string modulo);
        Task<RespuestaBD> ActivarPregunta(ActivarPreguntaDto solicitud);
        Task<RespuestaBD> ModificarPreguntaYRespuestas(ModificarPreguntaRespuestaDto solicitud);
    }
}