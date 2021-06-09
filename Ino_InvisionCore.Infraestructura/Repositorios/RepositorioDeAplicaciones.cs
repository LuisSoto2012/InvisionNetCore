using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Aplicacion;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeAplicaciones : IRepositorioDeAplicaciones
    {
        private InoContext Context;
        //public ILogger Log { get; set; }

        public RepositorioDeAplicaciones(InoContext context)
        {
            Context = context;
        }

        public RespuestaBD Actualizar(ActualizarAplicacion peticionDeActualizacion)
        {
            //Log.Information("RepositorioDeAplicaciones : Actualizar Aplicacion");
            //Log.Information("   RepositorioDeAplicaciones : Se desea actualizar ---> " + JsonConvert.SerializeObject(peticionDeActualizacion));
            RespuestaBD respuesta = new RespuestaBD();

            Dominio.Entidades.Aplicacion aplicacionEncontrada = Context.Aplicaciones.Where(x => x.IdAplicacion == peticionDeActualizacion.IdAplicacion).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(aplicacionEncontrada);
            if (aplicacionEncontrada != null)
            {
                Dominio.Entidades.Aplicacion nombreEncontrado = Context.Aplicaciones.Where(x => x.Nombre == peticionDeActualizacion.Nombre && x.IdAplicacion != peticionDeActualizacion.IdAplicacion).FirstOrDefault();
                if (nombreEncontrado != null)
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El nombre de la aplicación ya existe.";
                    Log.Information("   RepositorioDeAplicaciones : El nombre de la aplicación ya existe.");
                }
                else
                {
                    Context.Entry(aplicacionEncontrada).CurrentValues.SetValues(peticionDeActualizacion);
                    try
                    {
                        //Log.Information("   RepositorioDeAplicaciones : SaveChanges()");
                        Context.SaveChanges();
                        //Mensaje de respuesta
                        respuesta.Id = aplicacionEncontrada.IdAplicacion;
                        respuesta.Mensaje = "Se modificó la aplicación correctamente.";
                        //Log.Information("   RepositorioDeAplicaciones : Se modificó la aplicación correctamente.");
                    }
                    catch (Exception ex)
                    {
                        respuesta.Id = 0;
                        respuesta.Mensaje = "Ha ocurrido un error";
                        //Log.Error(ex.Message, "Error");
                    }
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "La aplicación no existe.";
                //Log.Information("   RepositorioDeAplicaciones : La aplicación no existe.");
            }

            return respuesta;
        }

        public RespuestaBD Crear(NuevaAplicacion peticionDeCreacion)
        {
            //Log.Information("RepositorioDeAplicaciones : Crear Aplicacion");
            //Log.Information("   RepositorioDeAplicaciones : Se desea crear ---> " + JsonConvert.SerializeObject(peticionDeCreacion));

            RespuestaBD respuesta = new RespuestaBD();

            Dominio.Entidades.Aplicacion aplicacion = Mapper.Map<Dominio.Entidades.Aplicacion>(peticionDeCreacion);
            Dominio.Entidades.Aplicacion aplicacionEncontrada = Context.Aplicaciones.Where(x => x.Nombre == peticionDeCreacion.Nombre).FirstOrDefault();
            if (aplicacionEncontrada == null)
            {
                Context.Aplicaciones.Add(aplicacion);
                try
                {
                    //Log.Information("   RepositorioDeAplicaciones : SaveChanges()");
                    Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    //Log.Error(ex.Message, "Error");
                }
                
                //Mensaje de respuesta
                respuesta.Id = aplicacion.IdAplicacion;
                respuesta.Mensaje = "Se creó la aplicación correctamente.";
                //Log.Information("   RepositorioDeAplicaciones : Se creó la aplicación correctamente.");

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El nombre de la aplicación ya existe.";
                //Log.Information("   RepositorioDeAplicaciones : El nombre de la aplicación ya existe.");
            }

            return respuesta;
        }

        public IEnumerable<AplicacionGeneral> Listar(int? Id)
        {
            //Log.Information("Aplicaciones - Obtener Listado de Aplicaciones");
            //Log.Information("RepositorioDeAdicionales : Listar");

            IList<AplicacionGeneral> list = new List<AplicacionGeneral>();

            try
            {
                //Log.Information("   Obteniendo listado de: InoContext");
                list = Context.Aplicaciones.Where(x => Id == null || x.IdAplicacion == Id)
                                              .ToList()
                                              .Select(x => Mapper.Map<AplicacionGeneral>(x))
                                              .ToList();

                //Log.Information("   Cantidad de Resultados: ", list.Count);
            }
            catch (Exception ex)
            {
                //Log.Error(ex.Message, "Error");
            }

            return list;
        }

        public Aplicacion ObtenerAplicacion(int idAplicacion)
        {
            //Log.Information("Aplicaciones - Obtener Aplicacion por Id");
            //Log.Information("RepositorioDeAdicionales : ObtenerAplicacion");

            Aplicacion aplicacion = null;

            try
            {
                //Log.Information("   IdAplicacion: " + idAplicacion);
                aplicacion = Context.Aplicaciones.Where(x => x.IdAplicacion == idAplicacion).FirstOrDefault();
                //Log.Information("   Aplicacion: " + JsonConvert.SerializeObject(aplicacion));
            }
            catch (Exception ex)
            {
                //Log.Error(ex.Message, "Error");
            }

            return aplicacion;
        }

        public async Task<Aplicacion> ObtenerAplicacionAsync(int idAplicacion)
        {
            return await Context.Aplicaciones.Where(x => x.IdAplicacion == idAplicacion).FirstOrDefaultAsync();
        }

        public async Task<RespuestaBD> CrearAsync(NuevaAplicacion peticionDeCreacion)
        {
            RespuestaBD respuesta = new RespuestaBD();

            Dominio.Entidades.Aplicacion aplicacion = Mapper.Map<Dominio.Entidades.Aplicacion>(peticionDeCreacion);
            Dominio.Entidades.Aplicacion aplicacionEncontrada = await Context.Aplicaciones.Where(x => x.Nombre == peticionDeCreacion.Nombre).FirstOrDefaultAsync();
            if (aplicacionEncontrada == null)
            {
                Context.Aplicaciones.Add(aplicacion);
                try
                {
                    //Log.Information("   RepositorioDeAplicaciones : SaveChanges()");
                    await Context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    //Log.Error(ex.Message, "Error");
                }

                //Mensaje de respuesta
                respuesta.Id = aplicacion.IdAplicacion;
                respuesta.Mensaje = "Se creó la aplicación correctamente.";
                //Log.Information("   RepositorioDeAplicaciones : Se creó la aplicación correctamente.");

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El nombre de la aplicación ya existe.";
                //Log.Information("   RepositorioDeAplicaciones : El nombre de la aplicación ya existe.");
            }

            return respuesta;
        }

        public async Task<IEnumerable<AplicacionGeneral>> ListarAsync(int? Id)
        {
            return await Context.Aplicaciones.Where(x => Id == null || x.IdAplicacion == Id)
                                              .Select(x => Mapper.Map<AplicacionGeneral>(x))
                                              .ToListAsync();
        }

        public async Task<RespuestaBD> ActualizarAsync(ActualizarAplicacion peticionDeActualizacion)
        {
            RespuestaBD respuesta = new RespuestaBD();

            Dominio.Entidades.Aplicacion aplicacionEncontrada = await Context.Aplicaciones
                                                                        .Where(x => x.IdAplicacion == peticionDeActualizacion.IdAplicacion)
                                                                        .FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(aplicacionEncontrada);
            if (aplicacionEncontrada != null)
            {
                Dominio.Entidades.Aplicacion nombreEncontrado = await Context.Aplicaciones
                                                                        .Where(x => x.Nombre == peticionDeActualizacion.Nombre && x.IdAplicacion != peticionDeActualizacion.IdAplicacion)
                                                                        .FirstOrDefaultAsync();
                if (nombreEncontrado != null)
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El nombre de la aplicación ya existe.";
                    Log.Information("   RepositorioDeAplicaciones : El nombre de la aplicación ya existe.");
                }
                else
                {
                    Context.Entry(aplicacionEncontrada).CurrentValues.SetValues(peticionDeActualizacion);
                    try
                    {
                        //Log.Information("   RepositorioDeAplicaciones : SaveChanges()");
                        await Context.SaveChangesAsync();
                        //Mensaje de respuesta
                        respuesta.Id = aplicacionEncontrada.IdAplicacion;
                        respuesta.Mensaje = "Se modificó la aplicación correctamente.";
                        //Log.Information("   RepositorioDeAplicaciones : Se modificó la aplicación correctamente.");
                    }
                    catch (Exception ex)
                    {
                        respuesta.Id = 0;
                        respuesta.Mensaje = "Ha ocurrido un error";
                        //Log.Error(ex.Message, "Error");
                    }
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "La aplicación no existe.";
                //Log.Information("   RepositorioDeAplicaciones : La aplicación no existe.");
            }

            return respuesta;
        }
    }
}
