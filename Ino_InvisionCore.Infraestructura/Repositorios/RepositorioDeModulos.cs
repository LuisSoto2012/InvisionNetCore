using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Modulo;
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
    public class RepositorioDeModulos : IRepositorioDeModulos
    {
        private readonly InoContext Context;
        //public ILogger Log { get; set; }

        public RepositorioDeModulos(InoContext context)
        {
            Context = context;
        }

        public RespuestaBD Actualizar(ActualizarModulo peticionDeActualizacion)
        {
            //Log.Information("RepositorioDeModulos: Actualizar Modulo");
            //Log.Information("   RepositorioDeModulos : Se desea actualizar ---> " + JsonConvert.SerializeObject(peticionDeActualizacion));

            RespuestaBD respuesta = new RespuestaBD();

            Modulo moduloEncontrada = Context.Modulo.Where(x => x.IdModulo == peticionDeActualizacion.IdModulo).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(moduloEncontrada);
            if (moduloEncontrada != null)
            {
                Dominio.Entidades.Modulo nombreEncontrado = Context.Modulo.Where(x => x.Nombre == peticionDeActualizacion.Nombre && x.IdModulo != peticionDeActualizacion.IdModulo).FirstOrDefault();
                if (nombreEncontrado != null)
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El nombre del módulo ya existe.";
                    //Log.Information("   RepositorioDeModulos : El nombre del módulo ya existe.");
                }
                else
                {
                    Context.Entry(moduloEncontrada).CurrentValues.SetValues(peticionDeActualizacion);
                    try
                    {
                        //Log.Information("   RepositorioDeModulos : Context.SaveChanges()");
                        Context.SaveChanges();
                        //Mensaje de respuesta
                        respuesta.Id = moduloEncontrada.IdModulo;
                        respuesta.Mensaje = "Se modificó el módulo correctamente.";
                        //Log.Information("   RepositorioDeModulos : Se modificó el módulo correctamente.");
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
                respuesta.Mensaje = "El módulo no existe.";
                //Log.Information("   RepositorioDeModulos : El módulo no existe.");
            }

            return respuesta;
        }

        public RespuestaBD Crear(NuevoModulo peticionDeCreacion)
        {
            //Log.Information("RepositorioDeModulos: Crear Modulo");
            //Log.Information("   RepositorioDeModulos : Se desea crear ---> " + JsonConvert.SerializeObject(peticionDeCreacion));

            RespuestaBD respuesta = new RespuestaBD();

            Modulo modulo = Mapper.Map<Modulo>(peticionDeCreacion);
            Modulo moduloEncontrado = Context.Modulo.Where(x => x.Nombre == peticionDeCreacion.Nombre).FirstOrDefault();
            if (moduloEncontrado == null)
            {
                Context.Modulo.Add(modulo);
                try
                {
                    //Log.Information("   RepositorioDeModulos : Context.SaveChanges()");
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = modulo.IdModulo;
                    respuesta.Mensaje = "Se creó el módulo correctamente.";
                    //Log.Information("   RepositorioDeModulos : Se creó el módulo correctamente.");
                }
                catch (Exception ex)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Ha ocurrido un error.";
                    //Log.Error(ex.Message, "Error");
                }
                
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El nombre del módulo ya existe.";
                //Log.Information("   RepositorioDeModulos : El nombre del módulo ya existe.");
            }

            return respuesta;
        }

        public Modulo EncontrarModulo(int Id)
        {
            //Log.Information("RepositorioDeModulos: EncontrarModulo");
            //Log.Information("       RepositorioDeModulos: Id = " + Id);
            Modulo modulo = Context.Modulo.Where(x => x.IdModulo == Id).FirstOrDefault();
            //Log.Information("       RepositorioDeModulos: Modulo encontrado = " + JsonConvert.SerializeObject(modulo));
            return modulo;
        }

        public IEnumerable<ModuloGeneral> Listar(int? Id)
        {
            //Log.Information("RepositorioDeModulos: Listar Modulos");
            var list = Context.Modulo.Where(x => Id == null || x.IdModulo == Id)
                                .Include(x => x.SubModulos)
                                .OrderBy(x => x.Orden)
                                .ToList()
                                .Select(x => Mapper.Map<ModuloGeneral>(x))
                                .ToList();
            //Log.Information("       RepositorioDeModulos: Numero de resultados = " + list.Count);
            return list;
        }

        public async Task<Modulo> EncontrarModuloAsync(int Id)
        {
            return await Context.Modulo.Where(x => x.IdModulo == Id).FirstOrDefaultAsync();
        }

        public async Task<RespuestaBD> CrearAsync(NuevoModulo peticionDeCreacion)
        {
            RespuestaBD respuesta = new RespuestaBD();

            Modulo modulo = Mapper.Map<Modulo>(peticionDeCreacion);
            Modulo moduloEncontrado = await Context.Modulo.Where(x => x.Nombre == peticionDeCreacion.Nombre).FirstOrDefaultAsync();
            if (moduloEncontrado == null)
            {
                await Context.Modulo.AddAsync(modulo);
                try
                {
                    //Log.Information("   RepositorioDeModulos : Context.SaveChanges()");
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = modulo.IdModulo;
                    respuesta.Mensaje = "Se creó el módulo correctamente.";
                    //Log.Information("   RepositorioDeModulos : Se creó el módulo correctamente.");
                }
                catch (Exception ex)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Ha ocurrido un error.";
                    //Log.Error(ex.Message, "Error");
                }

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El nombre del módulo ya existe.";
                //Log.Information("   RepositorioDeModulos : El nombre del módulo ya existe.");
            }

            return respuesta;
        }

        public async Task<IEnumerable<ModuloGeneral>> ListarAsync(int? Id)
        {
            return await Context.Modulo.Where(x => Id == null || x.IdModulo == Id)
                                .Include(x => x.SubModulos)
                                .OrderBy(x => x.Orden)
                                .Select(x => Mapper.Map<ModuloGeneral>(x))
                                .ToListAsync();
        }

        public async Task<RespuestaBD> ActualizarAsync(ActualizarModulo peticionDeActualizacion)
        {
            RespuestaBD respuesta = new RespuestaBD();

            Modulo moduloEncontrada = await Context.Modulo.Where(x => x.IdModulo == peticionDeActualizacion.IdModulo).FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(moduloEncontrada);
            if (moduloEncontrada != null)
            {
                Dominio.Entidades.Modulo nombreEncontrado = await Context.Modulo.Where(x => x.Nombre == peticionDeActualizacion.Nombre && x.IdModulo != peticionDeActualizacion.IdModulo).FirstOrDefaultAsync();
                if (nombreEncontrado != null)
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El nombre del módulo ya existe.";
                    //Log.Information("   RepositorioDeModulos : El nombre del módulo ya existe.");
                }
                else
                {
                    Context.Entry(moduloEncontrada).CurrentValues.SetValues(peticionDeActualizacion);
                    try
                    {
                        //Log.Information("   RepositorioDeModulos : Context.SaveChanges()");
                        await Context.SaveChangesAsync();
                        //Mensaje de respuesta
                        respuesta.Id = moduloEncontrada.IdModulo;
                        respuesta.Mensaje = "Se modificó el módulo correctamente.";
                        //Log.Information("   RepositorioDeModulos : Se modificó el módulo correctamente.");
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
                respuesta.Mensaje = "El módulo no existe.";
                //Log.Information("   RepositorioDeModulos : El módulo no existe.");
            }

            return respuesta;
        }
    }
}
