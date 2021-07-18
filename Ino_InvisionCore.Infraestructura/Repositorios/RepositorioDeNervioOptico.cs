using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.NervioOptico.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.NervioOptico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.NervioOptico;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.NervioOptico;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeNervioOptico : IRepositorioDeNervioOptico
    {
        private readonly InoContext _context;

        public RepositorioDeNervioOptico(InoContext context)
        {
            _context = context;
        }

        public async Task<RespuestaBD> EliminarNervioOptico(EliminarNervioOptico solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();
            try
            {
                var nervioOpticoDB = await _context.NerviosOpticos.FirstOrDefaultAsync(x => x.Id == solicitud.Id);
                if (nervioOpticoDB == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado información en la base de datos";
                    return respuesta;
                }
                nervioOpticoDB.IdEstado = 0;
                nervioOpticoDB.IdUsuarioModificacion = solicitud.IdUsuarioModificacion;
                nervioOpticoDB.FechaModificacion = DateTime.Now;
                await _context.SaveChangesAsync();
                respuesta.Id = 1;
                respuesta.Mensaje = "Eliminación satisfactoria!";
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor.";
            }

            return respuesta;  
        }

        public async Task<IEnumerable<NervioOpticoDto>> ListarNervioOptico(int idAtencion)
        {
            var list = await _context.NerviosOpticos.Where(x => x.IdAtencion == idAtencion && x.IdEstado == 1).ToListAsync();
            return list.Select(x => Mapper.Map<NervioOpticoDto>(x));
        }

        public async Task<RespuestaBD> ModificarNervioOptico(ModificarNervioOptico solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                var nervioOpticoDB = await _context.NerviosOpticos.FirstOrDefaultAsync(x => x.Id == solicitud.Id);

                if (nervioOpticoDB == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado información en la base de datos";
                    return respuesta;
                }

                NervioOptico nervioOptico = Mapper.Map(solicitud, nervioOpticoDB);
                await _context.SaveChangesAsync();
                respuesta.Id = 1;
                respuesta.Mensaje = "Modificación satisfactoria!";
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> RegistrarNervioOptico(RegistrarNervioOptico solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                NervioOptico nervioOptico = Mapper.Map<NervioOptico>(solicitud);
                _context.Add(nervioOptico);
                await _context.SaveChangesAsync();
                respuesta.Id = 1;
                respuesta.Mensaje = "Registro satisfactorio!";
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor.";
            }

            return respuesta;
        }
    }
}
