// ServicioDeEvaluaciones.cs22:4322:43

using System;
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

        public async Task<RespuestaBD> RegistrarParticipante(RegistrarParticipanteDto solicitud)
        {
            return await _repositorio.RegistrarParticipante(solicitud);
        }

        public async Task<EvalParticipanteDto> ObtenerDatosParticipantePor(string numeroDocumento, string correoElectronico)
        {
            return await _repositorio.ObtenerDatosParticipantePor(numeroDocumento, correoElectronico);
        }

        public async Task<IEnumerable<EvalPreguntaActivaDto>> ListarPreguntasActivas(string modulo, int idParticipante)
        {
            return await _repositorio.ListarPreguntasActivas(modulo, idParticipante);
        }

        public async Task<RespuestaBD> AgregarRespuestaAPregunta(AgregarRespuestaPreguntaDto solicitud)
        {
            return await _repositorio.AgregarRespuestaAPregunta(solicitud);
        }

        public async Task<IEnumerable<EvalResultadoDto>> ListarResultados(int idParticipante, string modulo)
        {
            return await _repositorio.ListarResultados(idParticipante, modulo);
        }

        public async Task<IEnumerable<EvalParticipanteNumPregDto>> ListarParticipantesPorNumeroPreguntas(string modulo, DateTime fecha, int numPreg)
        {
            return await _repositorio.ListarParticipantesPorNumeroPreguntas(modulo, fecha, numPreg);
        }

        public async Task<RespuestaBD> EnviarCertificados(EnviarCertificadosDto solicitud)
        {
            return await _repositorio.EnviarCertificados(solicitud);
        }

        public async Task<IEnumerable<EvalPartCertDto>> ListarParticipantesConCertificado(string modulo)
        {
            return await _repositorio.ListarParticipantesConCertificado(modulo);
        }
    }
}