using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Anestesia.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Anestesia.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Anestesia;
using Ino_InvisionCore.Dominio.Entidades.Anestesia;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeAnestesias : IRepositorioDeAnestesias
    {
        private readonly InoContext _context;

        public RepositorioDeAnestesias(InoContext context)
        {
            _context = context;
        }

        public async Task<RespuestaBD> EliminarEvaluacionPreAnestesica(EliminarPreAnestesiaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                //Obtener Registro de BD
                var eval = await _context.EvaluacionesPreAnestesicas.FirstOrDefaultAsync(x => x.Id == solicitud.Id);

                if (eval == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado el registro en la Base de datos.";
                }
                else
                {
                    eval.IdEstado = 0;
                    eval.IdUsuarioModificacion = solicitud.IdUsuario;
                    eval.FechaModificacion = DateTime.Now;
                    await _context.SaveChangesAsync();
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se ha eliminado el registro correctamente.";
                }
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        public async Task<IEnumerable<PreAnestesiaDto>> ListarEvaluacionPreAnestesica(int idAtencion)
        {
            var list = await _context.EvaluacionesPreAnestesicas.Where(x => x.IdAtencion == idAtencion && x.IdEstado == 1).ToListAsync();
            return list.Select(x => new PreAnestesiaDto
            {
                Id = x.Id,
                IdAtencion = x.IdAtencion,
                FechaRegistro = x.FechaCreacion.ToString("dd/MM/yyyy HH:mm")
            });
        }

        public async Task<RespuestaBD> ModificarEvaluacionPreAnestesica(ModificarEvaluacionPreAnestesica solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                var evaluacion = await _context.EvaluacionesPreAnestesicas.FirstOrDefaultAsync(x => x.Id == solicitud.Id);
                if (evaluacion == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado el registro en la BD.";
                    return respuesta;
                }

                evaluacion = Mapper.Map<EvaluacionPreAnestesica>(solicitud);
                await _context.SaveChangesAsync();
                respuesta.Id = 1;
                respuesta.Mensaje = "Modificación satisfactorio!";
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";

            }

            return respuesta;
        }

        public async Task<RespuestaBD> RegistrarEvaluacionPreAnestesica(RegistrarEvaluacionPreAnestesica solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                EvaluacionPreAnestesica evaluacionPreAnestesica = Mapper.Map<EvaluacionPreAnestesica>(solicitud);
                _context.EvaluacionesPreAnestesicas.Add(evaluacionPreAnestesica);
                await _context.SaveChangesAsync();
                respuesta.Id = 1;
                respuesta.Mensaje = "Registro satisfactorio!";
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";

            }

            return respuesta;
        }
    }
}
