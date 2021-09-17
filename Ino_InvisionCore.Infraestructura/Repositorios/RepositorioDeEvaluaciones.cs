// RepositorioDeEvaluaciones.cs22:2922:29

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Evaluacion;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Evaluacion;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeEvaluaciones : IRepositorioDeEvaluaciones
    {
        private readonly InoContext _inoContext;

        public RepositorioDeEvaluaciones(InoContext inoContext)
        {
            _inoContext = inoContext;
        }
        
        public async Task<RespuestaBD> RegistrarPreguntaYRespuestas(RegistrarPreguntaRespuestaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                EvaluacionPregunta evaluacionPregunta = Mapper.Map<EvaluacionPregunta>(solicitud);
                _inoContext.EvaluacionPreguntas.Add(evaluacionPregunta);
                await _inoContext.SaveChangesAsync();
                respuesta.Id = 0;
                respuesta.Mensaje = "Pregunta registrada satisfactoriamente!";
            }
            catch (Exception e)
            {
                respuesta.Id = 0;;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        public async  Task<IEnumerable<EvalPreguntaDto>> ListarPreguntas(string modulo)
        {
            IList<EvalPreguntaDto> preguntas = new List<EvalPreguntaDto>();

            var dbPreguntas = await _inoContext.EvaluacionPreguntas
                                    .Where(x => x.Modulo == modulo)
                                    .ToListAsync();

            foreach (var p in dbPreguntas)
            {
                EvalPreguntaDto dto = new EvalPreguntaDto();
                dto.Id = p.Id;
                dto.Modulo = p.Modulo;
                dto.Pregunta = p.Pregunta;
                dto.Activo = p.Activo ? 1 : 0;
                dto.FechaCreacion = p.FechaCreacion.ToString("dd/MM/yyyy");
                string[] respuestas = p.Respuestas.Split("|");
                if (respuestas.Length > 0)
                {
                    dto.RptaA = respuestas.Length > 0 ? respuestas[0].Split("^")[1] : "";
                    dto.RptaB = respuestas.Length > 1 ? respuestas[1].Split("^")[1] : "";
                    dto.RptaC = respuestas.Length > 2 ? respuestas[2].Split("^")[1] : "";
                    dto.RptaD = respuestas.Length > 3 ? respuestas[3].Split("^")[1] : "";
                    dto.RptaE = respuestas.Length > 4 ? respuestas[4].Split("^")[1] : "";
                    string respCorrecta = respuestas.ToList().Where(x => x.Contains("RESP_CORRECTA")).First();
                    string[] respSplit = respCorrecta.Split("^");
                    dto.RptaCorrecta = respSplit[0] + ". " + respSplit[1];
                    preguntas.Add(dto);
                }
            }
            return preguntas;
        }

        public async Task<RespuestaBD> ActivarPregunta(ActivarPreguntaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                //1. Obtener Pregunta de la DB
                var eval = await _inoContext.EvaluacionPreguntas.FirstOrDefaultAsync(x => x.Id == solicitud.Id);

                if (eval == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado la pregunta en la Base de Datos.";
                }
                else
                {
                    //2. Actualizar en DB
                    eval.Activo = solicitud.Activar;
                    eval.IdUsuarioModificacion = solicitud.IdUsuario;
                    eval.FechaModificacion = DateTime.Today;
                    await _inoContext.SaveChangesAsync();
                    respuesta.Id = 1;
                    respuesta.Mensaje = $"Se ha {(solicitud.Activar ? "activado" : "desactivado")} la pregunta correctamente!";
                }
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> ModificarPreguntaYRespuestas(ModificarPreguntaRespuestaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                //1. Obtener Pregunta de la DB
                EvaluacionPregunta eval = await _inoContext.EvaluacionPreguntas.FirstOrDefaultAsync(x => x.Id == solicitud.Id);

                if (eval == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado la pregunta en la Base de Datos.";
                }
                else
                {
                    //2. Actualizar
                    Mapper.Map<ModificarPreguntaRespuestaDto, EvaluacionPregunta>(solicitud, eval);
                    await _inoContext.SaveChangesAsync();
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se ha actualizado la pregunta correctamente!";
                }
                
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }
    }
}