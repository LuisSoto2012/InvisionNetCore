using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Seguridad;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos;
using Ino_InvisionCore.Dominio.EntidadesView;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeUsuarios : IRepositorioDeUsuarios
    {
        private readonly InoContext Context;
        //public ILogger Log { get; set; }
        private readonly AppSettings _appSettings;

        public RepositorioDeUsuarios(InoContext context, IOptions<AppSettings> appSettings)
        {
            Context = context;
            _appSettings = appSettings.Value;
        }

        public UsuarioLogin Login(string username, string password, int idAplicacion)
        {
            var condicionTrabajoList = Context.CondicionTrabajo.ToList();
            var tipoEmpleadoList = Context.TipoEmpleado.ToList();
            var tipoDocumentoList = Context.TipoDocumentoIdentidad.ToList();

            EmpleadoView empleado = Context.Empleados
                                        .Include(x => x.AplicacionEmpleados).ThenInclude(ae => ae.Aplicacion)
                                        .Include(x => x.EmpleadoRoles).ThenInclude(er => er.Rol).ThenInclude(r => r.RolSubModulos).ThenInclude(rs => rs.SubModulo).ThenInclude(s => s.Modulo)
                                        .Where(x => x.Usuario == username && x.Contrasena == password && x.EsActivo == true)
                                        .Select(x => new EmpleadoView
                                        {
                                            IdEmpleado = x.IdEmpleado,
                                            ApellidoPaterno = x.ApellidoPaterno,
                                            ApellidoMaterno = x.ApellidoMaterno,
                                            Nombres = x.Nombres,
                                            Correo = x.Correo,
                                            IdCondicionTrabajo = x.IdCondicionTrabajo,
                                            IdTipoEmpleado = x.IdTipoEmpleado,
                                            IdTipoDocumento = x.IdTipoDocumento,
                                            NumeroDocumento = x.NumeroDocumento,
                                            CodigoPlanilla = x.CodigoPlanilla,
                                            Usuario = x.Usuario,
                                            Contrasena = x.Contrasena,
                                            LoginEstado = x.LoginEstado,
                                            LoginIp = x.LoginIp,
                                            FechaNacimiento = x.FechaNacimiento,
                                            Roles = x.EmpleadoRoles.Select(er => er.Rol).ToList(),
                                            Aplicaciones = x.AplicacionEmpleados.Select(ae => ae.Aplicacion).ToList(),
                                            CondicionTrabajo = condicionTrabajoList.Where(c => c.IdCondicionTrabajo == x.IdCondicionTrabajo).FirstOrDefault(),
                                            TipoEmpleado = tipoEmpleadoList.Where(t => t.IdTipoEmpleado == x.IdTipoEmpleado).FirstOrDefault(),
                                            TipoDocumentoIdentidad = tipoDocumentoList.Where(t => t.IdTipoDocumentoIdentidad == x.IdTipoDocumento).First(),
                                            IdUsuarioCreacion = x.IdUsuarioCreacion,
                                            IdUsuarioModificacion = x.IdUsuarioModificacion,
                                            FechaCreacion = x.FechaCreacion,
                                            FechaModificacion = x.FechaModificacion,
                                            EsActivo = x.EsActivo
                                        })
                                        .FirstOrDefault();
            //Verificar si el usuario pertenece a la aplicacion
            //Aplicacion aplicacion = (empleado == null) ? null : empleado.Aplicaciones.Where(x => x.IdAplicacion == idAplicacion && x.EsActivo == true).FirstOrDefault();
            Aplicacion aplicacion = (empleado == null) ? null : empleado.Aplicaciones.Where(x => x.IdAplicacion == idAplicacion && x.EsActivo == true).FirstOrDefault();
            UsuarioLogin usuarioGeneral = (aplicacion == null) ? null : Mapper.Map<UsuarioLogin>(empleado);
            if (usuarioGeneral != null)
            {
                usuarioGeneral.Modulo = ObtenerMenu(usuarioGeneral).Modulo;
            }
            return usuarioGeneral;
        }

        public async Task<UsuarioFinger> ValidarUsuario(string usuario, string clave)
        {
            var empleado = await Context.Empleados.FirstOrDefaultAsync(x => x.Usuario == usuario && x.Contrasena == clave);

            return empleado == null ? null : new UsuarioFinger { IdUser = empleado.IdEmpleado, FirstName = empleado.Nombres, LastName = empleado.ApellidoPaterno, FingerPath = empleado.RutaHuella, IdentificationNumber = empleado.NumeroDocumento, FacePath = empleado.RutaRostro};
        }

        public RespuestaBD CambioClave(UsuarioCambioClave usuarioCambioClave)
        {
            //Log.Information("RepositorioDeEmpleado : CambioClave");
            //Log.Information("   RepositorioDeEmpleados : Se desea cambiar clave de ---> " + JsonConvert.SerializeObject(usuarioCambioClave));

            RespuestaBD respuesta = new RespuestaBD();

            usuarioCambioClave.ClaveAntigua = Security.HashSHA1(usuarioCambioClave.ClaveAntigua);
            Empleado empleado = Context.Empleados.FirstOrDefault(x => x.Usuario == usuarioCambioClave.Usuario && x.Contrasena == usuarioCambioClave.ClaveAntigua);
            //int UsuarioAdmin = Convert.ToInt32(Configuration.GetValue<string>("UsuarioAdmin"));
            int UsuarioAdmin = Convert.ToInt32(_appSettings.UsuarioAdmin);
            if (empleado != null && usuarioCambioClave.IdUsuarioModificacion == UsuarioAdmin)
            {
                empleado = Context.Empleados.FirstOrDefault(x => x.Usuario == usuarioCambioClave.Usuario);
            }
            if (empleado != null)
            {
                if (usuarioCambioClave.ClaveNueva == usuarioCambioClave.ClaveNuevaRepetida)
                {
                    empleado.Contrasena = Security.HashSHA1(usuarioCambioClave.ClaveNueva);
                    empleado.IdUsuarioModificacion = usuarioCambioClave.IdUsuarioModificacion;
                    empleado.FechaModificacion = DateTime.Now;
                    try
                    {
                        //Log.Information("   RepositorioDeEmpleados : Context.SaveChanges()");
                        Context.SaveChanges();
                        //Mensaje de respuesta
                        respuesta.Id = empleado.IdEmpleado;
                        respuesta.Mensaje = "La contraseña se cambió correctamente.";
                        //Log.Information("   RepositorioDeEmpleados : La contraseña se cambió correctamente.");
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
                    respuesta.Mensaje = "Las contraseñas nuevas son diferentes, intente nuevamente.";
                    //Log.Information("   RepositorioDeEmpleados : El nombre de usuario ya existe.");
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "La contraseña ingresada no es correcta, intente nuevamente.";
                //Log.Information("   RepositorioDeEmpleados : El nombre de usuario ya existe.");
            }

            return respuesta;
        }

        public Empleado EncontrarEmpleado(int Id)
        {
            return Context.Empleados.Find(Id);
        }

        public IEnumerable<EmpleadoGeneral> Listar(int? Id)
        {
            var condicionTrabajoList = Context.CondicionTrabajo.ToList();
            var tipoEmpleadoList = Context.TipoEmpleado.ToList();
            var tipoDocumentoList = Context.TipoDocumentoIdentidad.ToList();

            var listEmpleados = Context.Empleados.Where(x => Id == null || x.IdEmpleado == Id)
                                    .Include(x => x.AplicacionEmpleados)
                                    .ThenInclude(ae => ae.Aplicacion)
                                    .Include(x => x.CondicionTrabajo)
                                    .Include(x => x.EmpleadoRoles)
                                    .ThenInclude(er => er.Rol)
                                    .Include(x => x.TipoDocumentoIdentidad)
                                    .Include(x => x.TipoEmpleado)
                                    .Select(x => new EmpleadoView
                                    {
                                        IdEmpleado = x.IdEmpleado,
                                        ApellidoPaterno = x.ApellidoPaterno,
                                        ApellidoMaterno = x.ApellidoMaterno,
                                        Nombres = x.Nombres,
                                        Correo = x.Correo,
                                        IdCondicionTrabajo = x.IdCondicionTrabajo,
                                        IdTipoEmpleado = x.IdTipoEmpleado,
                                        IdTipoDocumento = x.IdTipoDocumento,
                                        NumeroDocumento = x.NumeroDocumento,
                                        CodigoPlanilla = x.CodigoPlanilla,
                                        Usuario = x.Usuario,
                                        Contrasena = x.Contrasena,
                                        LoginEstado = x.LoginEstado,
                                        LoginIp = x.LoginIp,
                                        FechaNacimiento = x.FechaNacimiento,
                                        Roles = x.EmpleadoRoles.Select(er => er.Rol).ToList(),
                                        Aplicaciones = x.AplicacionEmpleados.Select(ae => ae.Aplicacion).ToList(),
                                        CondicionTrabajo = condicionTrabajoList.Where(c => c.IdCondicionTrabajo == x.IdCondicionTrabajo).FirstOrDefault(),
                                        TipoEmpleado = tipoEmpleadoList.Where(t => t.IdTipoEmpleado == x.IdTipoEmpleado).FirstOrDefault(),
                                        TipoDocumentoIdentidad = tipoDocumentoList.Where(t => t.IdTipoDocumentoIdentidad == x.IdTipoDocumento).First(),
                                        IdUsuarioCreacion = x.IdUsuarioCreacion,
                                        IdUsuarioModificacion = x.IdUsuarioModificacion,
                                        FechaCreacion = x.FechaCreacion,
                                        FechaModificacion = x.FechaModificacion,
                                        EsActivo = x.EsActivo
                                    })
                                    .ToList();

            return listEmpleados.Select(x => Mapper.Map<EmpleadoGeneral>(x))
                                .ToList();
        }

        public UsuarioLogin ObtenerMenu(UsuarioLogin usuarioLogin)
        {
            List<SubModuloMenu> subModulos = (from e in Context.Roles
                                              join rsm in Context.RolSubModulo on e.IdRol equals rsm.IdRol
                                              join sm in Context.SubModulo on rsm.IdSubModulo equals sm.IdSubModulo
                                              //where e.Empleado.Any(x => x.IdEmpleado == usuarioLogin.IdEmpleado)
                                              where e.EmpleadoRoles.Any(x => x.IdEmpleado == usuarioLogin.IdEmpleado)
                                              && rsm.EsActivo == true
                                              orderby sm.Orden ascending
                                              select new SubModuloMenu
                                              {
                                                  IdSubModulo = sm.IdSubModulo,
                                                  IdModulo = sm.IdModulo,
                                                  SubModulo = sm.Nombre,
                                                  Ruta = sm.Ruta,
                                                  Orden = sm.Orden,
                                                  Ver = rsm.Ver,
                                                  Agregar = rsm.Agregar,
                                                  Editar = rsm.Editar,
                                                  Eliminar = rsm.Eliminar
                                              }).ToList();

            List<ModuloMenu> modulos = (from e in Context.Roles
                                        join rsm in Context.RolSubModulo on e.IdRol equals rsm.IdRol
                                        join sm in Context.SubModulo on rsm.IdSubModulo equals sm.IdSubModulo
                                        join m in Context.Modulo on sm.IdModulo equals m.IdModulo
                                        //where e.Empleado.Any(x => x.IdEmpleado == usuarioLogin.IdEmpleado)
                                        where e.EmpleadoRoles.Any(x => x.IdEmpleado == usuarioLogin.IdEmpleado)
                                        && rsm.EsActivo == true
                                        select new ModuloMenu
                                        {
                                            IdModulo = m.IdModulo,
                                            Modulo = m.Nombre,
                                            Icono = m.Icono,
                                            Orden = m.Orden,
                                        }).Distinct().OrderBy(x => x.Orden).ToList();

            List<ModuloMenu> menuModulo = modulos
                .Select(x => new ModuloMenu
                {
                    IdModulo = x.IdModulo,
                    Modulo = x.Modulo,
                    Icono = x.Icono,
                    Orden = x.Orden,
                    SubModulo = subModulos.Where(y => y.IdModulo == x.IdModulo).ToList()
                }).ToList();

            usuarioLogin.Modulo = menuModulo;
            return usuarioLogin;
        }

        public void UsuarioCerrarSesion(int idUsuario)
        {
            Empleado usuario = Context.Empleados.Find(idUsuario);
            usuario.LoginEstado = false;
            usuario.LoginIp = "";
            Context.SaveChanges();
        }

        public void UsuarioLogueado(int idUsuario, string ipAddress)
        {
            Empleado usuario = Context.Empleados.Find(idUsuario);
            usuario.LoginEstado = false;
            usuario.LoginIp = ipAddress;
            Context.SaveChanges();
        }

        public RespuestaBD Crear(NuevoEmpleado peticionDeCreacion)
        {
            //Log.Information("RepositorioDeEmpleado : Crear Empleado");
            //Log.Information("   RepositorioDeEmpleados : Se desea crear ---> " + JsonConvert.SerializeObject(peticionDeCreacion));

            RespuestaBD respuesta = new RespuestaBD();

            Empleado empleado = Mapper.Map<Empleado>(peticionDeCreacion);
            if (peticionDeCreacion.Roles.Count > 0)
            {
                if (peticionDeCreacion.Aplicaciones.Count > 0)
                {
                    Empleado usuarioEncontrado = Context.Empleados.Where(x => x.Usuario == peticionDeCreacion.Usuario).FirstOrDefault();
                    Empleado correoEncontrado = Context.Empleados.Where(x => x.Correo == peticionDeCreacion.Correo).FirstOrDefault();
                    Empleado documentoEncontrado = Context.Empleados.Where(x => x.NumeroDocumento == peticionDeCreacion.NumeroDocumento).FirstOrDefault();
                    Empleado codigoPlanillaEncontrado = Context.Empleados.Where(x => x.CodigoPlanilla == peticionDeCreacion.CodigoPlanilla).FirstOrDefault();
                    if (usuarioEncontrado != null)
                    {
                        //Mensaje de respuesta
                        respuesta.Id = 0;
                        respuesta.Mensaje = "El nombre de usuario ya existe.";
                        //Log.Information("   RepositorioDeEmpleados : El nombre de usuario ya existe.");
                    }
                    else if (correoEncontrado != null)
                    {
                        //Mensaje de respuesta
                        respuesta.Id = 0;
                        respuesta.Mensaje = "El correo del usuario ya existe.";
                        //Log.Information("   RepositorioDeEmpleados : El correo del usuario ya existe.");
                    }
                    else if (documentoEncontrado != null)
                    {
                        //Mensaje de respuesta
                        respuesta.Id = 0;
                        respuesta.Mensaje = "El número de documento del usuario ya existe.";
                        //Log.Information("   RepositorioDeEmpleados : El número de documento del usuario ya existe.");
                    }
                    else if (codigoPlanillaEncontrado != null)
                    {
                        //Mensaje de respuesta
                        respuesta.Id = 0;
                        respuesta.Mensaje = "El código de planilla del usuario ya existe.";
                        //Log.Information("   RepositorioDeEmpleados : El código de planilla del usuario ya existe.");
                    }
                    else
                    {
                        empleado.Contrasena = Security.HashSHA1(peticionDeCreacion.Contrasena);
                        LimpiarObjetoCrear(empleado);
                        Context.Empleados.Add(empleado);
                        List<int> idRoles = peticionDeCreacion.Roles.Select(r => r.IdRol).ToList();
                        List<Rol> roles = Context.Roles.Where(r => idRoles.Contains(r.IdRol)).ToList();
                        foreach (Rol rol in roles)
                        {
                            //empleado.Roles.Add(rol);
                            empleado.EmpleadoRoles.Add(new EmpleadoRol { Empleado = empleado, Rol = rol, IdEmpleado = empleado.IdEmpleado, IdRol = rol.IdRol});
                        }
                        List<int> idAplicaciones = peticionDeCreacion.Aplicaciones.Select(r => r.IdAplicacion).ToList();
                        List<Dominio.Entidades.Aplicacion> aplicaciones = Context.Aplicaciones.Where(a => idAplicaciones.Contains(a.IdAplicacion)).ToList();
                        foreach (Dominio.Entidades.Aplicacion aplicacion in aplicaciones)
                        {
                            //empleado.Aplicaciones.Add(aplicacion);
                            empleado.AplicacionEmpleados.Add(new AplicacionEmpleado { Aplicacion = aplicacion, Empleado = empleado, IdAplicacion = aplicacion.IdAplicacion, IdEmpleado = empleado.IdEmpleado });
                        }
                        try
                        {
                            //Log.Information("   RepositorioDeEmpleados : Context.SaveChanges()");
                            Context.SaveChanges();
                            //Mensaje de respuesta
                            respuesta.Id = empleado.IdEmpleado;
                            respuesta.Mensaje = "Se creó el empleado correctamente.";
                            //Log.Information("   RepositorioDeEmpleados : Se creó el empleado correctamente.");
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
                    respuesta.Mensaje = "No se ha seleccionado ninguna aplicación, verifique.";
                }

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "No se ha seleccionado ningún rol, verifique.";
            }

            return respuesta;
        }

        public RespuestaBD Actualizar(ActualizarEmpleado peticionDeActualizacion)
        {
            //Log.Information("RepositorioDeEmpleado : Actualizar Empleado");
            //Log.Information("   RepositorioDeEmpleados : Se desea actualizar ---> " + JsonConvert.SerializeObject(peticionDeActualizacion));

            RespuestaBD respuesta = new RespuestaBD();

            string valoresAntiguos = "";
            if (peticionDeActualizacion.Roles.Count > 0)
            {
                if (peticionDeActualizacion.Aplicaciones.Count > 0)
                {
                    Empleado usuarioEncontrado = Context.Empleados.Where(x => x.IdEmpleado == peticionDeActualizacion.IdEmpleado)
                                                                    .Include(x => x.AplicacionEmpleados)
                                                                    .ThenInclude(ae => ae.Aplicacion)
                                                                    .Include(x => x.EmpleadoRoles)
                                                                    .ThenInclude(er => er.Rol)
                                                                    .FirstOrDefault();
                    Empleado correoEncontrado = Context.Empleados.Where(x => x.Correo == peticionDeActualizacion.Correo && x.IdEmpleado != peticionDeActualizacion.IdEmpleado).FirstOrDefault();
                    Empleado documentoEncontrado = Context.Empleados.Where(x => x.NumeroDocumento == peticionDeActualizacion.NumeroDocumento && x.IdEmpleado != peticionDeActualizacion.IdEmpleado).FirstOrDefault();
                    Empleado codigoPlanillaEncontrado = Context.Empleados.Where(x => x.CodigoPlanilla == peticionDeActualizacion.CodigoPlanilla && x.IdEmpleado != peticionDeActualizacion.IdEmpleado).FirstOrDefault();
                    //valoresAntiguos = JsonConvert.SerializeObject(usuarioEncontrado);
                    if (usuarioEncontrado != null)
                    {
                        if (correoEncontrado != null)
                        {
                            //Mensaje de respuesta
                            respuesta.Id = 0;
                            respuesta.Mensaje = "El correo del usuario ya existe.";
                            //Log.Information("   RepositorioDeEmpleados : El correo del usuario ya existe.");
                        }
                        else if (documentoEncontrado != null)
                        {
                            //Mensaje de respuesta
                            respuesta.Id = 0;
                            respuesta.Mensaje = "El número de documento del usuario ya existe.";
                            //Log.Information("   RepositorioDeEmpleados : El número de documento del usuario ya existe.");
                        }
                        else if (codigoPlanillaEncontrado != null)
                        {
                            //Mensaje de respuesta
                            respuesta.Id = 0;
                            respuesta.Mensaje = "El código de planilla del usuario ya existe.";
                            //Log.Information("   RepositorioDeEmpleados : El código de planilla del usuario ya existe.");
                        }
                        else
                        {
                            usuarioEncontrado.IdCondicionTrabajo = peticionDeActualizacion.CondicionTrabajo.Id;
                            usuarioEncontrado.IdTipoEmpleado = peticionDeActualizacion.TipoEmpleado.Id;
                            usuarioEncontrado.IdTipoDocumento = peticionDeActualizacion.TipoDocumentoIdentidad.Id;
                            LimpiarObjetoActualizar(usuarioEncontrado);
                            Context.Entry(usuarioEncontrado).CurrentValues.SetValues(peticionDeActualizacion);
                            List<int> idRoles = peticionDeActualizacion.Roles.Select(r => r.IdRol).ToList();
                            List<Rol> roles = Context.Roles.Where(r => idRoles.Contains(r.IdRol)).ToList();
                            foreach (Rol rol in roles)
                            {
                                //usuarioEncontrado.Roles.Add(rol);
                                usuarioEncontrado.EmpleadoRoles.Add(new EmpleadoRol { Empleado = usuarioEncontrado, Rol = rol, IdEmpleado = usuarioEncontrado.IdEmpleado, IdRol = rol.IdRol });
                            }
                            List<int> idAplicaciones = peticionDeActualizacion.Aplicaciones.Select(r => r.IdAplicacion).ToList();
                            List<Dominio.Entidades.Aplicacion> aplicaciones = Context.Aplicaciones.Where(a => idAplicaciones.Contains(a.IdAplicacion)).ToList();
                            foreach (Dominio.Entidades.Aplicacion aplicacion in aplicaciones)
                            {
                                //usuarioEncontrado.Aplicaciones.Add(aplicacion);
                                usuarioEncontrado.AplicacionEmpleados.Add(new AplicacionEmpleado { Aplicacion = aplicacion, Empleado = usuarioEncontrado, IdAplicacion = aplicacion.IdAplicacion, IdEmpleado = usuarioEncontrado.IdEmpleado });
                            }
                            try
                            {
                                //Log.Information("   RepositorioDeEmpleados : SaveChanges()");
                                Context.SaveChanges();
                                //Mensaje de respuesta
                                respuesta.Id = usuarioEncontrado.IdEmpleado;
                                respuesta.Mensaje = "Se modificó el empleado correctamente.";
                                //Log.Information("   RepositorioDeEmpleados : Se modificó el empleado correctamente.");
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
                        respuesta.Mensaje = "El usuario no existe.";
                        //Log.Information("   RepositorioDeEmpleados : El usuario no existe.");
                    }
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha seleccionado ninguna aplicación, verifique.";
                    //Log.Information("   RepositorioDeEmpleados : No se ha seleccionado ninguna aplicación, verifique.");
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "No se ha seleccionado ningún rol, verifique.";
                //Log.Information("   RepositorioDeEmpleados : No se ha seleccionado ningún rol, verifique.");
            }

            return respuesta;
        }

        private void LimpiarObjetoCrear(Empleado empleado)
        {
            empleado.CondicionTrabajo = null;
            empleado.TipoEmpleado = null;
            empleado.TipoDocumentoIdentidad = null;
            //empleado.Aplicaciones.Clear();
            //empleado.Roles.Clear();
            empleado.AplicacionEmpleados = new List<AplicacionEmpleado>();
            empleado.EmpleadoRoles = new List<EmpleadoRol>();
        }

        private void LimpiarObjetoActualizar(Empleado empleado)
        {
            //empleado.CondicionTrabajo = null;
            //empleado.TipoEmpleado = null;
            //empleado.TipoDocumentoIdentidad = null;
            //empleado.Aplicaciones.Clear();
            //empleado.Roles.Clear();
            empleado.AplicacionEmpleados.Clear();
            empleado.EmpleadoRoles.Clear();
        }

        public EmpleadoGeneral ObtenerUsuario(int Id)
        {
            var condicionTrabajoList = Context.CondicionTrabajo.ToList();
            var tipoEmpleadoList = Context.TipoEmpleado.ToList();
            var tipoDocumentoList = Context.TipoDocumentoIdentidad.ToList();

            EmpleadoView user = Context.Empleados.Where(x => x.IdEmpleado == Id).Select(x => new EmpleadoView
            {
                IdEmpleado = x.IdEmpleado,
                ApellidoPaterno = x.ApellidoPaterno,
                ApellidoMaterno = x.ApellidoMaterno,
                Nombres = x.Nombres,
                Correo = x.Correo,
                IdCondicionTrabajo = x.IdCondicionTrabajo,
                IdTipoEmpleado = x.IdTipoEmpleado,
                IdTipoDocumento = x.IdTipoDocumento,
                NumeroDocumento = x.NumeroDocumento,
                CodigoPlanilla = x.CodigoPlanilla,
                Usuario = x.Usuario,
                Contrasena = x.Contrasena,
                LoginEstado = x.LoginEstado,
                LoginIp = x.LoginIp,
                FechaNacimiento = x.FechaNacimiento,
                Roles = x.EmpleadoRoles.Select(er => er.Rol).ToList(),
                Aplicaciones = x.AplicacionEmpleados.Select(ae => ae.Aplicacion).ToList(),
                CondicionTrabajo = condicionTrabajoList.Where(c => c.IdCondicionTrabajo == x.IdCondicionTrabajo).FirstOrDefault(),
                TipoEmpleado = tipoEmpleadoList.Where(t => t.IdTipoEmpleado == x.IdTipoEmpleado).FirstOrDefault(),
                TipoDocumentoIdentidad = tipoDocumentoList.Where(t => t.IdTipoDocumentoIdentidad == x.IdTipoDocumento).First(),
                IdUsuarioCreacion = x.IdUsuarioCreacion,
                IdUsuarioModificacion = x.IdUsuarioModificacion,
                FechaCreacion = x.FechaCreacion,
                FechaModificacion = x.FechaModificacion,
                EsActivo = x.EsActivo
            }).FirstOrDefault();

            if (user == null)
            {
                var paciente = Context.PacientesCitaWeb.FirstOrDefault(x => x.Id == Id);
                user = new EmpleadoView
                {
                    IdEmpleado = paciente.Id
                };
            }

            return Mapper.Map<EmpleadoGeneral>(user);
        }

        public UsuarioLogin CorroborarCredenciales(int IdUsuario)
        {
            Empleado usuario = Context.Empleados
                                        .Include(x => x.AplicacionEmpleados).ThenInclude(ae => ae.Aplicacion)
                                        .Include(x => x.EmpleadoRoles).ThenInclude(er => er.Rol).ThenInclude(r => r.RolSubModulos).ThenInclude(rs => rs.SubModulo).ThenInclude(s => s.Modulo)
                                        .Where(x => x.IdEmpleado == IdUsuario)
                                        .FirstOrDefault();

            IList<RolGeneral> rolesGenerales = usuario.EmpleadoRoles.Select(x => Mapper.Map<RolGeneral>(x.Rol)).ToList();
            IList<Rol> rolesUsuario = usuario.EmpleadoRoles.Select(x => x.Rol).ToList();
            UsuarioLogin usuarioLogin = Mapper.Map<UsuarioLogin>(usuario);
            usuarioLogin.Roles = rolesGenerales.ToList();
            usuarioLogin.Modulo = ObtenerMenu(usuarioLogin).Modulo;
            //usuarioLogin.ArchivoRostro = (string.IsNullOrEmpty(usuario.RutaRostro)) ? string.Empty : Convert.ToBase64String(File.ReadAllBytes(usuario.RutaRostro));
            return usuarioLogin;
        }

        public async Task<RespuestaBD> AgregarRutaHuella(AgregarHuellaEmpleado request)
        {
            RespuestaBD respuesta = new RespuestaBD();

            Empleado empleado = await Context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == request.IdEmpleado);

            if (empleado != null)
            {
                empleado.RutaHuella = request.RutaHuella;
                await Context.SaveChangesAsync();
                respuesta.Id = 1;
                respuesta.Mensaje = "Se ha registrado la ruta de la huella digital satisfactoriamente";
            }
            else
            {
                respuesta.Id = 0;
            }

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarPIN(AgregarPINEmpleado request)
        {
            RespuestaBD respuesta = new RespuestaBD();

            Empleado empleado = await Context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == request.IdEmpleado);

            if (empleado != null)
            {
                empleado.SecurityPIN = request.SecurityPIN;
                empleado.FechaPIN = DateTime.Now;
                await Context.SaveChangesAsync();
                respuesta.Id = 1;
                respuesta.Mensaje = "Se ha registrado el PIN satisfactoriamente";
            }
            else
            {
                respuesta.Id = 0;
            }

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarRutaRostro(AgregarHuellaEmpleado request)
        {
            RespuestaBD respuesta = new RespuestaBD();

            Empleado empleado = await Context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == request.IdEmpleado);

            if (empleado != null)
            {
                empleado.RutaRostro = request.RutaRostro;
                await Context.SaveChangesAsync();
                respuesta.Id = 1;
                respuesta.Mensaje = "Se ha registrado la ruta del rostro satisfactoriamente";
            }
            else
            {
                respuesta.Id = 0;
            }

            return respuesta;
        }



        //private InoContext Context;
        //private IConfiguration Configuration;

        //public RepositorioDeUsuarios(InoContext context, IConfiguration configuration)
        //{
        //    Context = context;
        //    Configuration = configuration;
        //}

        //public RespuestaBD Actualizar(ActualizarEmpleado peticionDeActualizacion)
        //{
        //    RespuestaBD respuesta = new RespuestaBD();

        //    string valoresAntiguos = "";
        //    if (peticionDeActualizacion.Roles.Count > 0)
        //    {
        //        if (peticionDeActualizacion.Aplicaciones.Count > 0)
        //        {
        //            Empleado usuarioEncontrado = Context.Empleados.Find(peticionDeActualizacion.IdEmpleado);
        //            Empleado correoEncontrado = Context.Empleados.Where(x => x.Correo == peticionDeActualizacion.Correo && x.IdEmpleado != peticionDeActualizacion.IdEmpleado).FirstOrDefault();
        //            Empleado documentoEncontrado = Context.Empleados.Where(x => x.NumeroDocumento == peticionDeActualizacion.NumeroDocumento && x.IdEmpleado != peticionDeActualizacion.IdEmpleado).FirstOrDefault();
        //            Empleado codigoPlanillaEncontrado = Context.Empleados.Where(x => x.CodigoPlanilla == peticionDeActualizacion.CodigoPlanilla && x.IdEmpleado != peticionDeActualizacion.IdEmpleado).FirstOrDefault();
        //            valoresAntiguos = JsonConvert.SerializeObject(usuarioEncontrado);
        //            if (usuarioEncontrado != null)
        //            {
        //                if (correoEncontrado != null)
        //                {
        //                    //Mensaje de respuesta
        //                    respuesta.Id = 0;
        //                    respuesta.Mensaje = "El correo del usuario ya existe.";
        //                }
        //                else if (documentoEncontrado != null)
        //                {
        //                    //Mensaje de respuesta
        //                    respuesta.Id = 0;
        //                    respuesta.Mensaje = "El número de documento del usuario ya existe.";
        //                }
        //                else if (codigoPlanillaEncontrado != null)
        //                {
        //                    //Mensaje de respuesta
        //                    respuesta.Id = 0;
        //                    respuesta.Mensaje = "El código de planilla del usuario ya existe.";
        //                }
        //                else
        //                {
        //                    usuarioEncontrado.IdCondicionTrabajo = peticionDeActualizacion.CondicionTrabajo.Id;
        //                    usuarioEncontrado.IdTipoEmpleado = peticionDeActualizacion.TipoEmpleado.Id;
        //                    usuarioEncontrado.IdTipoDocumento = peticionDeActualizacion.TipoDocumentoIdentidad.Id;
        //                    LimpiarObjeto(usuarioEncontrado);
        //                    Context.Entry(usuarioEncontrado).CurrentValues.SetValues(peticionDeActualizacion);
        //                    List<int> idRoles = peticionDeActualizacion.Roles.Select(r => r.IdRol).ToList();
        //                    List<Rol> roles = Context.Roles.Where(r => idRoles.Contains(r.IdRol)).ToList();
        //                    foreach (Rol rol in roles)
        //                    {
        //                        usuarioEncontrado.Roles.Add(rol);
        //                    }
        //                    List<int> idAplicaciones = peticionDeActualizacion.Aplicaciones.Select(r => r.IdAplicacion).ToList();
        //                    List<Dominio.Entidades.Aplicacion> aplicaciones = Context.Aplicaciones.Where(a => idAplicaciones.Contains(a.IdAplicacion)).ToList();
        //                    foreach (Dominio.Entidades.Aplicacion aplicacion in aplicaciones)
        //                    {
        //                        usuarioEncontrado.Aplicaciones.Add(aplicacion);
        //                    }
        //                    Context.SaveChanges();
        //                    //Mensaje de respuesta
        //                    respuesta.Id = usuarioEncontrado.IdEmpleado;
        //                    respuesta.Mensaje = "Se modificó el empleado correctamente.";
        //                }
        //            }
        //            else
        //            {
        //                //Mensaje de respuesta
        //                respuesta.Id = 0;
        //                respuesta.Mensaje = "El usuario no existe.";
        //            }
        //        }
        //        else
        //        {
        //            //Mensaje de respuesta
        //            respuesta.Id = 0;
        //            respuesta.Mensaje = "No se ha seleccionado ninguna aplicación, verifique.";
        //        }
        //    }
        //    else
        //    {
        //        //Mensaje de respuesta
        //        respuesta.Id = 0;
        //        respuesta.Mensaje = "No se ha seleccionado ningún rol, verifique.";
        //    }

        //    return respuesta;
        //}

        //public RespuestaBD CambioClave(UsuarioCambioClave usuarioCambioClave)
        //{
        //    RespuestaBD respuesta = new RespuestaBD();

        //    usuarioCambioClave.ClaveAntigua = Security.HashSHA1(usuarioCambioClave.ClaveAntigua);
        //    Empleado empleado = Context.Empleados.Where(x => x.Usuario == usuarioCambioClave.Usuario && x.Contrasena == usuarioCambioClave.ClaveAntigua).FirstOrDefault();
        //    int UsuarioAdmin = Convert.ToInt32(Configuration.GetValue<string>("UsuarioAdmin"));
        //    if (empleado != null && usuarioCambioClave.IdUsuarioModificacion == UsuarioAdmin)
        //    {
        //        empleado = Context.Empleados.Where(x => x.Usuario == usuarioCambioClave.Usuario).FirstOrDefault();
        //    }
        //    if (empleado != null)
        //    {
        //        if (usuarioCambioClave.ClaveNueva == usuarioCambioClave.ClaveNuevaRepetida)
        //        {
        //            empleado.Contrasena = Security.HashSHA1(usuarioCambioClave.ClaveNueva);
        //            empleado.IdUsuarioModificacion = usuarioCambioClave.IdUsuarioModificacion;
        //            empleado.FechaModificacion = DateTime.Now;
        //            Context.SaveChanges();
        //            //Mensaje de respuesta
        //            respuesta.Id = empleado.IdEmpleado;
        //            respuesta.Mensaje = "La contraseña se cambió correctamente.";
        //        }
        //        else
        //        {
        //            //Mensaje de respuesta
        //            respuesta.Id = 0;
        //            respuesta.Mensaje = "Las contraseñas nuevas son diferentes, intente nuevamente.";
        //        }
        //    }
        //    else
        //    {
        //        //Mensaje de respuesta
        //        respuesta.Id = 0;
        //        respuesta.Mensaje = "La contraseña ingresada no es correcta, intente nuevamente.";
        //    }

        //    return respuesta;
        //}

        //public RespuestaBD Crear(NuevoEmpleado peticionDeCreacion)
        //{
        //    RespuestaBD respuesta = new RespuestaBD();

        //    Empleado empleado = Mapper.Map<Empleado>(peticionDeCreacion);
        //    if (peticionDeCreacion.Roles.Count > 0)
        //    {
        //        if (peticionDeCreacion.Aplicaciones.Count > 0)
        //        {
        //            Empleado usuarioEncontrado = Context.Empleados.Where(x => x.Usuario == peticionDeCreacion.Usuario).FirstOrDefault();
        //            Empleado correoEncontrado = Context.Empleados.Where(x => x.Correo == peticionDeCreacion.Correo).FirstOrDefault();
        //            Empleado documentoEncontrado = Context.Empleados.Where(x => x.NumeroDocumento == peticionDeCreacion.NumeroDocumento).FirstOrDefault();
        //            Empleado codigoPlanillaEncontrado = Context.Empleados.Where(x => x.CodigoPlanilla == peticionDeCreacion.CodigoPlanilla).FirstOrDefault();
        //            if (usuarioEncontrado != null)
        //            {
        //                //Mensaje de respuesta
        //                respuesta.Id = 0;
        //                respuesta.Mensaje = "El nombre de usuario ya existe.";
        //            }
        //            else if (correoEncontrado != null)
        //            {
        //                //Mensaje de respuesta
        //                respuesta.Id = 0;
        //                respuesta.Mensaje = "El correo del usuario ya existe.";
        //            }
        //            else if (documentoEncontrado != null)
        //            {
        //                //Mensaje de respuesta
        //                respuesta.Id = 0;
        //                respuesta.Mensaje = "El número de documento del usuario ya existe.";
        //            }
        //            else if (codigoPlanillaEncontrado != null)
        //            {
        //                //Mensaje de respuesta
        //                respuesta.Id = 0;
        //                respuesta.Mensaje = "El código de planilla del usuario ya existe.";
        //            }
        //            else
        //            {
        //                empleado.Contrasena = Security.HashSHA1(peticionDeCreacion.Contrasena);
        //                LimpiarObjeto(empleado);
        //                Context.Empleados.Add(empleado);
        //                List<int> idRoles = peticionDeCreacion.Roles.Select(r => r.IdRol).ToList();
        //                List<Rol> roles = Context.Roles.Where(r => idRoles.Contains(r.IdRol)).ToList();
        //                foreach (Rol rol in roles)
        //                {
        //                    empleado.Roles.Add(rol);
        //                }
        //                List<int> idAplicaciones = peticionDeCreacion.Aplicaciones.Select(r => r.IdAplicacion).ToList();
        //                List<Dominio.Entidades.Aplicacion> aplicaciones = Context.Aplicaciones.Where(a => idAplicaciones.Contains(a.IdAplicacion)).ToList();
        //                foreach (Dominio.Entidades.Aplicacion aplicacion in aplicaciones)
        //                {
        //                    empleado.Aplicaciones.Add(aplicacion);
        //                }
        //                Context.SaveChanges();
        //                //Mensaje de respuesta
        //                respuesta.Id = empleado.IdEmpleado;
        //                respuesta.Mensaje = "Se creó el empleado correctamente.";

        //            }
        //        }
        //        else
        //        {
        //            //Mensaje de respuesta
        //            respuesta.Id = 0;
        //            respuesta.Mensaje = "No se ha seleccionado ninguna aplicación, verifique.";
        //        }

        //    }
        //    else
        //    {
        //        //Mensaje de respuesta
        //        respuesta.Id = 0;
        //        respuesta.Mensaje = "No se ha seleccionado ningún rol, verifique.";
        //    }

        //    return respuesta;
        //}

        //public List<EmpleadoGeneral> Listar(int? Id)
        //{
        //    return Context.Empleados.Where(x => Id == null || x.IdEmpleado == Id)
        //                           .ToList()
        //                           .Select(x => Mapper.Map<EmpleadoGeneral>(x))
        //                           .ToList();
        //}

        //public UsuarioLogin Login(string username, string password, int idAplicacion)
        //{
        //    Empleado empleado = Context.Empleados.Where(x => x.Usuario == username && x.Contrasena == password && x.EsActivo == true).FirstOrDefault();
        //    //Verificar si el usuario pertenece a la aplicacion
        //    Aplicacion aplicacion = (empleado == null) ? new Aplicacion() : empleado.Aplicaciones.Where(x => x.IdAplicacion == idAplicacion && x.EsActivo == true).FirstOrDefault();
        //    UsuarioLogin usuarioGeneral = (aplicacion == null) ? new UsuarioLogin() : Mapper.Map<UsuarioLogin>(empleado);
        //    return usuarioGeneral;
        //}

        ////public UsuarioLogin LoginPaciente(UsuarioPaciente usuarioPaciente)
        ////{
        ////    PacienteAfiliacion paciente = this._gestorDePacientes.ListarPacientePorHcDni(new PacientePorHcDni
        ////    {
        ////        NroHistoriaClinica = null,
        ////        NroDocumento = usuarioPaciente.NroDocumento,
        ////        Temporal = false
        ////    });

        ////    UsuarioLogin usuarioGeneral = null;

        ////    if (paciente != null && paciente.Correo == usuarioPaciente.Correo)
        ////    {
        ////        string[] NombreCompleto = paciente.Paciente.Split(',');
        ////        var Roles = Context.Empleados.Find(usuarioPaciente.IdEmpleado).Roles.Select(x => Mapper.Map<RolGeneral>(x)).ToList();
        ////        usuarioGeneral = new UsuarioLogin
        ////        {
        ////            IdEmpleado = usuarioPaciente.IdEmpleado,
        ////            Usuario = "",
        ////            Nombres = NombreCompleto[1].Trim(),
        ////            ApellidoPaterno = NombreCompleto[0].Split(' ')[0],
        ////            LoginEstado = false,
        ////            Roles = Roles
        ////        };
        ////    }
        ////    return usuarioGeneral;
        ////}

        //private void LimpiarObjeto(Empleado empleado)
        //{
        //    empleado.CondicionTrabajo = null;
        //    empleado.TipoEmpleado = null;
        //    empleado.TipoDocumentoIdentidad = null;
        //    empleado.Aplicaciones.Clear();
        //    empleado.Roles.Clear();
        //}

        //public UsuarioLogin ObtenerMenu(UsuarioLogin usuarioLogin)
        //{
        //    List<SubModuloMenu> subModulos = (from e in Context.Roles
        //                                      join rsm in Context.RolSubModulo on e.IdRol equals rsm.IdRol
        //                                      join sm in Context.SubModulo on rsm.IdSubModulo equals sm.IdSubModulo
        //                                      where e.Empleado.Any(x => x.IdEmpleado == usuarioLogin.IdEmpleado)
        //                                      && rsm.EsActivo == true
        //                                      orderby sm.Orden ascending
        //                                      select new SubModuloMenu
        //                                      {
        //                                          IdSubModulo = sm.IdSubModulo,
        //                                          IdModulo = sm.IdModulo,
        //                                          SubModulo = sm.Nombre,
        //                                          Ruta = sm.Ruta,
        //                                          Orden = sm.Orden,
        //                                          Ver = rsm.Ver,
        //                                          Agregar = rsm.Agregar,
        //                                          Editar = rsm.Editar,
        //                                          Eliminar = rsm.Eliminar
        //                                      }).ToList();

        //    List<ModuloMenu> modulos = (from e in Context.Roles
        //                                join rsm in Context.RolSubModulo on e.IdRol equals rsm.IdRol
        //                                join sm in Context.SubModulo on rsm.IdSubModulo equals sm.IdSubModulo
        //                                join m in Context.Modulo on sm.IdModulo equals m.IdModulo
        //                                where e.Empleado.Any(x => x.IdEmpleado == usuarioLogin.IdEmpleado)
        //                                && rsm.EsActivo == true
        //                                select new ModuloMenu
        //                                {
        //                                    IdModulo = m.IdModulo,
        //                                    Modulo = m.Nombre,
        //                                    Icono = m.Icono,
        //                                    Orden = m.Orden,
        //                                }).Distinct().OrderBy(x => x.Orden).ToList();

        //    List<ModuloMenu> menuModulo = modulos
        //        .Select(x => new ModuloMenu
        //        {
        //            IdModulo = x.IdModulo,
        //            Modulo = x.Modulo,
        //            Icono = x.Icono,
        //            Orden = x.Orden,
        //            SubModulo = subModulos.Where(y => y.IdModulo == x.IdModulo).ToList()
        //        }).ToList();

        //    usuarioLogin.Modulo = menuModulo;
        //    return usuarioLogin;
        //}

        //public void UsuarioCerrarSesion(int idUsuario)
        //{
        //    Empleado usuario = Context.Empleados.Find(idUsuario);
        //    usuario.LoginEstado = false;
        //    usuario.LoginIp = "";
        //    Context.SaveChanges();
        //}

        //public void UsuarioLogueado(int idUsuario, string ipAddress)
        //{
        //    Empleado usuario = Context.Empleados.Find(idUsuario);
        //    usuario.LoginEstado = false;
        //    usuario.LoginIp = ipAddress;
        //    Context.SaveChanges();
        //}

        //public Empleado EncontrarEmpleado(int Id)
        //{
        //    return Context.Empleados.Find(Id);
        //}
    }
}
