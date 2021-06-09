using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Seguridad;
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
    public class RepositorioDeRoles : IRepositorioDeRoles
    {
        private readonly InoContext Context;
        //public ILogger Log { get; set; }

        public RepositorioDeRoles(InoContext context)
        {
            Context = context;
        }

        public RespuestaBD Actualizar(ActualizarRol peticionDeActualizacion)
        {
            //Log.Information("RepositorioDeRoles: Actualizar Rol");
            //Log.Information("   RepositorioDeRoles : Se desea actualizar ---> " + JsonConvert.SerializeObject(peticionDeActualizacion));

            RespuestaBD respuesta = new RespuestaBD();

            Rol rolEncontrado = Context.Roles.Where(x => x.IdRol == peticionDeActualizacion.IdRol).FirstOrDefault();

            if (rolEncontrado != null)
            {
                Context.Entry(rolEncontrado).CurrentValues.SetValues(peticionDeActualizacion);
                try
                {
                    //Log.Information("   RepositorioDeRoles : Context.SaveChanges()");
                    Context.SaveChanges();
                    respuesta.Id = rolEncontrado.IdRol;
                    //Mensaje de respuesta
                    respuesta.Mensaje = "Se modificó el rol correctamente.";
                    //Log.Information("   RepositorioDeRoles : Se modificó el rol correctamente.");
                }
                catch (Exception ex)
                {
                    respuesta.Id = 0;
                    //Mensaje de respuesta
                    respuesta.Mensaje = "Ha ocurrido un error.";
                    //Log.Error(ex.Message, "Error");
                }
                
            }
            else
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "El rol que desea modificar no existe.";
                //Log.Information("   RepositorioDeRoles : El rol que desea modificar no existe");
            }

            return respuesta;
        }

        public RespuestaBD Crear(NuevoRol peticionDeCreacion)
        {
            //Log.Information("RepositorioDeRoles: Crear Rol");
            //Log.Information("   RepositorioDeRoles : Se desea crear ---> " + JsonConvert.SerializeObject(peticionDeCreacion));

            RespuestaBD respuesta = new RespuestaBD();

            Rol rol = Mapper.Map<Rol>(peticionDeCreacion);
            Rol rolEncontrado = Context.Roles.Where(x => x.Nombre == peticionDeCreacion.Nombre).FirstOrDefault();
            if (rolEncontrado == null)
            {
                Context.Roles.Add(rol);
                try
                {
                    //Log.Information("   RepositorioDeRoles : Context.SaveChanges()");
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = rol.IdRol;
                    respuesta.Mensaje = "Se creó el rol correctamente.";
                    //Log.Information("   RepositorioDeRoles : Se creó el rol correctamente.");
                }
                catch (Exception ex)
                {
                    respuesta.Id = 0;
                    //Mensaje de respuesta
                    respuesta.Mensaje = "Ha ocurrido un error.";
                    //Log.Error(ex.Message, "Error");
                }
                
            }
            else
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "El rol que desea crear ya existe.";
                //Log.Information("   RepositorioDeRoles : El rol que desea crear ya existe");
            }

            return respuesta;
        }

        public Rol EncontrarRol(int Id)
        {
            return Context.Roles.Where(x => x.IdRol == Id).FirstOrDefault();
        }

        public IEnumerable<RolGeneral> Listar(int? Id)
        {
            return Context.Roles.Where(x => Id == null || x.IdRol == Id)
                               .Include(x => x.EmpleadoRoles)
                               .ThenInclude(er => er.Rol)
                               .ToList()
                               .Select(x => Mapper.Map<RolGeneral>(x))
                               .ToList();
        }

        public async Task<Rol> EncontrarRolAsync(int Id)
        {
            return await Context.Roles.Where(x => x.IdRol == Id).FirstOrDefaultAsync();
        }

        public async Task<RespuestaBD> CrearAsync(NuevoRol peticionDeCreacion)
        {
            RespuestaBD respuesta = new RespuestaBD();

            Rol rol = Mapper.Map<Rol>(peticionDeCreacion);
            Rol rolEncontrado = await Context.Roles.Where(x => x.Nombre == peticionDeCreacion.Nombre).FirstOrDefaultAsync();
            if (rolEncontrado == null)
            {
                await Context.Roles.AddAsync(rol);
                try
                {
                    //Log.Information("   RepositorioDeRoles : Context.SaveChanges()");
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = rol.IdRol;
                    respuesta.Mensaje = "Se creó el rol correctamente.";
                    //Log.Information("   RepositorioDeRoles : Se creó el rol correctamente.");
                }
                catch (Exception ex)
                {
                    respuesta.Id = 0;
                    //Mensaje de respuesta
                    respuesta.Mensaje = "Ha ocurrido un error.";
                    //Log.Error(ex.Message, "Error");
                }

            }
            else
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "El rol que desea crear ya existe.";
                //Log.Information("   RepositorioDeRoles : El rol que desea crear ya existe");
            }

            return respuesta;
        }

        public async Task<IEnumerable<RolGeneral>> ListarAsync(int? Id)
        {
            return await Context.Roles.Where(x => Id == null || x.IdRol == Id)
                               .Include(x => x.EmpleadoRoles)
                               .ThenInclude(er => er.Rol)
                               .Select(x => Mapper.Map<RolGeneral>(x))
                               .ToListAsync();
        }

        public async Task<RespuestaBD> ActualizarAsync(ActualizarRol peticionDeActualizacion)
        {
            RespuestaBD respuesta = new RespuestaBD();

            Rol rolEncontrado = await Context.Roles.Where(x => x.IdRol == peticionDeActualizacion.IdRol).FirstOrDefaultAsync();

            if (rolEncontrado != null)
            {
                Context.Entry(rolEncontrado).CurrentValues.SetValues(peticionDeActualizacion);
                try
                {
                    //Log.Information("   RepositorioDeRoles : Context.SaveChanges()");
                    await Context.SaveChangesAsync();
                    respuesta.Id = rolEncontrado.IdRol;
                    //Mensaje de respuesta
                    respuesta.Mensaje = "Se modificó el rol correctamente.";
                    //Log.Information("   RepositorioDeRoles : Se modificó el rol correctamente.");
                }
                catch (Exception ex)
                {
                    respuesta.Id = 0;
                    //Mensaje de respuesta
                    respuesta.Mensaje = "Ha ocurrido un error.";
                    //Log.Error(ex.Message, "Error");
                }

            }
            else
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "El rol que desea modificar no existe.";
                //Log.Information("   RepositorioDeRoles : El rol que desea modificar no existe");
            }

            return respuesta;
        }
    }
}
