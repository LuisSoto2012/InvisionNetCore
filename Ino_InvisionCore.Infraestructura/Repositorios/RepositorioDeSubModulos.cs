using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.SubModulo;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeSubModulos : IRepositorioDeSubModulos
    {
        private readonly InoContext Context;
        //public ILogger Log { get; set; }

        public RepositorioDeSubModulos(InoContext context)
        {
            Context = context;
        }

        public RespuestaBD Actualizar(ActualizarSubModulo peticionDeActualizacion)
        {
            //Log.Information("RepositorioDeSubModulos: Actualizar SubModulo");
            //Log.Information("   RepositorioDeSubModulos : Se desea actualizar ---> " + JsonConvert.SerializeObject(peticionDeActualizacion));

            RespuestaBD respuesta = new RespuestaBD();

            SubModulo subModuloEncontrada = Context.SubModulo.Where(x => x.IdSubModulo == peticionDeActualizacion.IdSubModulo).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(subModuloEncontrada);
            if (subModuloEncontrada != null)
            {
                SubModulo nombreEncontrado = Context.SubModulo.Where(x => x.Nombre == peticionDeActualizacion.Nombre && x.IdModulo != peticionDeActualizacion.IdModulo).FirstOrDefault();
                if (nombreEncontrado != null)
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El nombre del sub módulo ya existe.";
                    //Log.Information("   RepositorioDeSubModulos : El nombre del sub módulo ya existe.");
                }
                else
                {
                    Context.Entry(subModuloEncontrada).CurrentValues.SetValues(peticionDeActualizacion);
                    try
                    {
                        //Log.Information("   RepositorioDeSubModulos : Context.SaveChanges()");
                        Context.SaveChanges();
                        //Mensaje de respuesta
                        respuesta.Id = subModuloEncontrada.IdSubModulo;
                        respuesta.Mensaje = "Se modificó el sub módulo correctamente.";
                        //Log.Information("   RepositorioDeSubModulos : Se modificó el rol correctamente.");
                    }
                    catch (Exception ex)
                    {
                        respuesta.Id = 0;
                        respuesta.Mensaje = "Ha ocurrido un error.";
                        //Log.Error(ex.Message, "Error");
                    }
                    
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El sub módulo no existe.";
                //Log.Information("   RepositorioDeSubModulos : El sub módulo no existe.");
            }

            return respuesta;
        }

        public RespuestaBD AsignarRolSubModulo(RolSubModuloDto rolSubModuloDto)
        {
            //Log.Information("RepositorioDeSubModulos: AsignarRolSubModulo");
            //Log.Information("   RepositorioDeSubModulos : Se desea asignar ---> " + JsonConvert.SerializeObject(rolSubModuloDto));

            RespuestaBD respuesta = new RespuestaBD();

            //EDITAR
            if (rolSubModuloDto.IdRolSubModulo > 0)
            {
                //RolSubModulo rolSubModulo = Context.RolSubModulo.Find(rolSubModuloDto.IdRolSubModulo);
                RolSubModulo rolSubModulo = Context.RolSubModulo.Where(x => x.IdRolSubModulo == rolSubModuloDto.IdRolSubModulo).Include(x => x.Rol).Include(x => x.SubModulo).FirstOrDefault();
                rolSubModulo.IdUsuarioModificacion = rolSubModuloDto.IdUsuarioRegistra;
                rolSubModulo.FechaModificacion = DateTime.Now;
                Context.Entry(rolSubModulo).CurrentValues.SetValues(rolSubModuloDto);
                
                try
                {
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = rolSubModulo.IdRolSubModulo;
                    respuesta.Mensaje = "Se asignó el sub módulo al rol correctamente.";
                    //Log.Information("   RepositorioDeSubModulos : Se asignó el sub módulo al rol correctamente.");
                }
                catch (Exception ex)
                {

                    //Log.Error(ex.Message, "Error");
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Ha ocurrido un error.";
                }
            }
            //AGREGAR
            else
            {
                RolSubModulo rolSubModulo = Mapper.Map<RolSubModulo>(rolSubModuloDto);
                rolSubModulo.IdUsuarioCreacion = rolSubModuloDto.IdUsuarioRegistra;
                Context.RolSubModulo.Add(rolSubModulo);
                try
                {
                    //Log.Information("   RepositorioDeSubModulos : Context.SaveChanges()");
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = rolSubModulo.IdRolSubModulo;
                    respuesta.Mensaje = "Se asignó el sub módulo al rol correctamente.";
                    //Log.Information("   RepositorioDeSubModulos : Se asignó el sub módulo al rol correctamente.");
                }
                catch (Exception ex)
                {
                    //Log.Error(ex.Message, "Error");
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Ha ocurrido un error.";
                }
                
            }

            return respuesta;
        }

        public RespuestaBD Crear(NuevoSubModulo peticionDeCreacion)
        {
            //Log.Information("RepositorioDeSubModulos: Crear SubModulo");
            //Log.Information("   RepositorioDeSubModulos : Se desea crear ---> " + JsonConvert.SerializeObject(peticionDeCreacion));

            RespuestaBD respuesta = new RespuestaBD();

            SubModulo subModulo = Mapper.Map<SubModulo>(peticionDeCreacion);
            SubModulo moduloEncontrado = Context.SubModulo.Where(x => x.Nombre == peticionDeCreacion.Nombre).FirstOrDefault();
            if (moduloEncontrado == null)
            {
                Context.SubModulo.Add(subModulo);
                try
                {
                    //Log.Information("   RepositorioDeSubModulos : Context.SaveChanges()");
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = subModulo.IdSubModulo;
                    respuesta.Mensaje = "Se creó el sub módulo correctamente.";
                    //Log.Information("   RepositorioDeSubModulos : Se creó el sub módulo correctamente.");
                }
                catch (Exception ex)
                {
                    //Log.Error(ex.Message, "Error");
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Ha ocurrido un error.";
                }
                
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El nombre del sub módulo ya existe.";
                //Log.Information("   RepositorioDeSubModulos : El nombre del sub módulo ya existe.");
            }

            return respuesta;
        }

        public RolSubModulo EncontrarRolSubModulo(int id)
        {
            return Context.RolSubModulo.Where(x => x.IdRolSubModulo == id).FirstOrDefault();
        }

        public SubModulo EncontrarSubModulo(int Id)
        {
            return Context.SubModulo.Where(x => x.IdSubModulo == Id).FirstOrDefault();
        }

        public IEnumerable<SubModuloGeneral> Listar(int? Id)
        {
            return Context.SubModulo.Where(x => Id == null || x.IdSubModulo == Id)
                                      .OrderBy(x => x.Orden)
                                      .ToList()
                                      .Select(x => Mapper.Map<SubModuloGeneral>(x))
                                      .ToList();
        }

        public IEnumerable<RolSubModuloDto> ObtenerRolSubModulo(RolSubModuloDto rolSubModuloDto)
        {
            return Context.RolSubModulo.Where(x =>
                                        (rolSubModuloDto.IdRol == 0 || x.IdRol == rolSubModuloDto.IdRol) &&
                                        (rolSubModuloDto.IdSubModulo == 0 || x.IdSubModulo == rolSubModuloDto.IdSubModulo))
                                    .ToList()
                                    .Select(x => Mapper.Map<RolSubModuloDto>(x))
                                    .ToList();
        }

        public async Task<RespuestaBD> AsignarRolSubModuloAsync(RolSubModuloDto rolSubModuloDto)
        {
            RespuestaBD respuesta = new RespuestaBD();

            //EDITAR
            if (rolSubModuloDto.IdRolSubModulo > 0)
            {
                RolSubModulo rolSubModulo = await Context.RolSubModulo.Where(x => x.IdRolSubModulo == rolSubModuloDto.IdRolSubModulo).Include(x => x.Rol).Include(x => x.SubModulo).FirstOrDefaultAsync();
                rolSubModulo.IdUsuarioModificacion = rolSubModuloDto.IdUsuarioRegistra;
                rolSubModulo.FechaModificacion = DateTime.Now;
                Context.Entry(rolSubModulo).CurrentValues.SetValues(rolSubModuloDto);

                try
                {
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = rolSubModulo.IdRolSubModulo;
                    respuesta.Mensaje = "Se asignó el sub módulo al rol correctamente.";
                    //Log.Information("   RepositorioDeSubModulos : Se asignó el sub módulo al rol correctamente.");
                }
                catch (Exception ex)
                {

                    //Log.Error(ex.Message, "Error");
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Ha ocurrido un error.";
                }
            }
            //AGREGAR
            else
            {
                RolSubModulo rolSubModulo = Mapper.Map<RolSubModulo>(rolSubModuloDto);
                rolSubModulo.IdUsuarioCreacion = rolSubModuloDto.IdUsuarioRegistra;
                await Context.RolSubModulo.AddAsync(rolSubModulo);
                try
                {
                    //Log.Information("   RepositorioDeSubModulos : Context.SaveChanges()");
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = rolSubModulo.IdRolSubModulo;
                    respuesta.Mensaje = "Se asignó el sub módulo al rol correctamente.";
                    //Log.Information("   RepositorioDeSubModulos : Se asignó el sub módulo al rol correctamente.");
                }
                catch (Exception ex)
                {
                    //Log.Error(ex.Message, "Error");
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Ha ocurrido un error.";
                }

            }

            return respuesta;
        }

        public async Task<IEnumerable<RolSubModuloDto>> ObtenerRolSubModuloAsync(RolSubModuloDto rolSubModuloDto)
        {
            return await Context.RolSubModulo.Where(x =>
                                        (rolSubModuloDto.IdRol == 0 || x.IdRol == rolSubModuloDto.IdRol) &&
                                        (rolSubModuloDto.IdSubModulo == 0 || x.IdSubModulo == rolSubModuloDto.IdSubModulo))
                                    .Select(x => Mapper.Map<RolSubModuloDto>(x))
                                    .ToListAsync();
        }

        public async Task<SubModulo> EncontrarSubModuloAsync(int Id)
        {
            return await Context.SubModulo.Where(x => x.IdSubModulo == Id).FirstOrDefaultAsync();
        }

        public async Task<RolSubModulo> EncontrarRolSubModuloAsync(int id)
        {
            return await Context.RolSubModulo.Where(x => x.IdRolSubModulo == id).FirstOrDefaultAsync();
        }

        public async Task<RespuestaBD> CrearAsync(NuevoSubModulo peticionDeCreacion)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SubModulo subModulo = Mapper.Map<SubModulo>(peticionDeCreacion);
            SubModulo moduloEncontrado = await Context.SubModulo.Where(x => x.Nombre == peticionDeCreacion.Nombre).FirstOrDefaultAsync();
            if (moduloEncontrado == null)
            {
                await Context.SubModulo.AddAsync(subModulo);
                try
                {
                    //Log.Information("   RepositorioDeSubModulos : Context.SaveChanges()");
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = subModulo.IdSubModulo;
                    respuesta.Mensaje = "Se creó el sub módulo correctamente.";
                    //Log.Information("   RepositorioDeSubModulos : Se creó el sub módulo correctamente.");
                }
                catch (Exception ex)
                {
                    //Log.Error(ex.Message, "Error");
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Ha ocurrido un error.";
                }

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El nombre del sub módulo ya existe.";
                //Log.Information("   RepositorioDeSubModulos : El nombre del sub módulo ya existe.");
            }

            return respuesta;
        }

        public async Task<IEnumerable<SubModuloGeneral>> ListarAsync(int? Id)
        {
            return await Context.SubModulo.Where(x => Id == null || x.IdSubModulo == Id)
                                      .OrderBy(x => x.Orden)
                                      .Select(x => Mapper.Map<SubModuloGeneral>(x))
                                      .ToListAsync();
        }

        public async Task<RespuestaBD> ActualizarAsync(ActualizarSubModulo peticionDeActualizacion)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SubModulo subModuloEncontrada = await Context.SubModulo.Where(x => x.IdSubModulo == peticionDeActualizacion.IdSubModulo).FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(subModuloEncontrada);
            if (subModuloEncontrada != null)
            {
                SubModulo nombreEncontrado = await Context.SubModulo.Where(x => x.Nombre == peticionDeActualizacion.Nombre && x.IdModulo != peticionDeActualizacion.IdModulo).FirstOrDefaultAsync();
                if (nombreEncontrado != null)
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El nombre del sub módulo ya existe.";
                    //Log.Information("   RepositorioDeSubModulos : El nombre del sub módulo ya existe.");
                }
                else
                {
                    Context.Entry(subModuloEncontrada).CurrentValues.SetValues(peticionDeActualizacion);
                    try
                    {
                        //Log.Information("   RepositorioDeSubModulos : Context.SaveChanges()");
                        await Context.SaveChangesAsync();
                        //Mensaje de respuesta
                        respuesta.Id = subModuloEncontrada.IdSubModulo;
                        respuesta.Mensaje = "Se modificó el sub módulo correctamente.";
                        //Log.Information("   RepositorioDeSubModulos : Se modificó el rol correctamente.");
                    }
                    catch (Exception ex)
                    {
                        respuesta.Id = 0;
                        respuesta.Mensaje = "Ha ocurrido un error.";
                        //Log.Error(ex.Message, "Error");
                    }

                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El sub módulo no existe.";
                //Log.Information("   RepositorioDeSubModulos : El sub módulo no existe.");
            }

            return respuesta;
        }
    }
}
