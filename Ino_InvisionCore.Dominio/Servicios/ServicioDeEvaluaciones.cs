// ServicioDeEvaluaciones.cs22:4322:43

using System.Collections.Generic;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Evaluacion;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Evaluacion;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeEvaluaciones : IServicioDeEvaluaciones
    {
        private readonly IRepositorioDeEvaluaciones _repositorio;

        public ServicioDeEvaluaciones(IRepositorioDeEvaluaciones repositorio)
        {
            _repositorio = repositorio;
        }
        
        public async Task<RespuestaBD> RegistrarPreguntaYRespuestas(RegistrarPreguntaRespuestaDto solicitud)
        {
            return await _repositorio.RegistrarPreguntaYRespuestas(solicitud);
        }

        public async Task<IEnumerable<EvalPreguntaDto>> ListarPreguntas(string modulo)
        {
            return await _repositorio.ListarPreguntas(modulo);
        }

        public async Task<RespuestaBD> ActivarPregunta(ActivarPreguntaDto solicitud)
        {
            return await _repositorio.ActivarPregunta(solicitud);
        }

        public async Task<RespuestaBD> ModificarPreguntaYRespuestas(ModificarPreguntaRespuestaDto solicitud)
        {
            return await _repositorio.ModificarPreguntaYRespuestas(solicitud);
        }
    }
}