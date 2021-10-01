// IServicioDeEvaluaciones.cs22:4322:43

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Evaluacion
{
    public interface IServicioDeEvaluaciones
    {
        Task<RespuestaBD> RegistrarPreguntaYRespuestas(RegistrarPreguntaRespuestaDto solicitud);
        Task<IEnumerable<EvalPreguntaDto>> ListarPreguntas(string modulo);
        Task<RespuestaBD> ActivarPregunta(ActivarPreguntaDto solicitud);
        Task<RespuestaBD> ModificarPreguntaYRespuestas(ModificarPreguntaRespuestaDto solicitud);
        Task<RespuestaBD> RegistrarParticipante(RegistrarParticipanteDto solicitud);
        Task<EvalParticipanteDto> ObtenerDatosParticipantePor(string numeroDocumento, string correoElectronico);
        Task<IEnumerable<EvalPreguntaActivaDto>> ListarPreguntasActivas(string modulo, int idParticipante);
        Task<RespuestaBD> AgregarRespuestaAPregunta(AgregarRespuestaPreguntaDto solicitud);
        Task<IEnumerable<EvalResultadoDto>> ListarResultados(int idParticipante, string modulo);
        Task<IEnumerable<EvalParticipanteNumPregDto>> ListarParticipantesPorNumeroPreguntas(string modulo, DateTime fecha, int numPreg);
        Task<RespuestaBD> EnviarCertificados(EnviarCertificadosDto solicitud);
        Task<IEnumerable<EvalPartCertDto>> ListarParticipantesConCertificado(string modulo);
    }
}