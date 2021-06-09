using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Seguridad;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Seguridad;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeUsuarios : IServicioDeUsuarios
    {
        public IRepositorioDeUsuarios RepositorioDeUsuarios { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeUsuarios(IRepositorioDeUsuarios repositorioDeUsuarios, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeUsuarios = repositorioDeUsuarios;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD Actualizar(ActualizarEmpleado peticionDeActualizacion)
        {
            RespuestaBD respuesta = RepositorioDeUsuarios.Actualizar(peticionDeActualizacion);

            //if (respuesta.Id != 0)
            //{
            //    Empleado usuarioEncontrado = RepositorioDeUsuarios.EncontrarEmpleado(peticionDeActualizacion.IdEmpleado);
            //    string valoresAntiguos = JsonConvert.SerializeObject(usuarioEncontrado);
            //    // Auditoria
            //    AuditoriaGeneral auditoria = new AuditoriaGeneral
            //    {
            //        Accion = "Actualizar",
            //        NombreTabla = "Empleado",
            //        ValoresAntiguos = valoresAntiguos,
            //        ValoresNuevos = JsonConvert.SerializeObject(peticionDeActualizacion),
            //        IdUsuario = peticionDeActualizacion.IdUsuarioModificacion
            //    };
            //    ServicioDeAuditoria.AgregarAuditoria(auditoria);
            //}

            return respuesta;
        }

        public RespuestaBD CambioClave(UsuarioCambioClave usuarioCambioClave)
        {
            RespuestaBD respuesta = RepositorioDeUsuarios.CambioClave(usuarioCambioClave);

            //if (respuesta.Id != 0)
            //{
            //    // Auditoria
            //    AuditoriaGeneral auditoria = new AuditoriaGeneral
            //    {
            //        Accion = "CambioDeClave",
            //        NombreTabla = "Empleado",
            //        ValoresAntiguos = null,
            //        ValoresNuevos = JsonConvert.SerializeObject(usuarioCambioClave),
            //        IdUsuario = usuarioCambioClave.IdUsuarioModificacion
            //    };

            //    ServicioDeAuditoria.AgregarAuditoria(auditoria);
            //}

            return respuesta;
        }

        public RespuestaBD Crear(NuevoEmpleado peticionDeCreacion)
        {
            RespuestaBD respuesta = RepositorioDeUsuarios.Crear(peticionDeCreacion);

            //if (respuesta.Id != 0)
            //{
            //    // Auditoria
            //    AuditoriaGeneral auditoria = new AuditoriaGeneral
            //    {
            //        Accion = "Agregar",
            //        NombreTabla = "Empleado",
            //        ValoresAntiguos = null,
            //        ValoresNuevos = JsonConvert.SerializeObject(peticionDeCreacion),
            //        IdUsuario = peticionDeCreacion.IdUsuarioCreacion
            //    };
            //    ServicioDeAuditoria.AgregarAuditoria(auditoria);
            //}

            return respuesta;
        }

        public IEnumerable<EmpleadoGeneral> Listar(int? Id)
        {
            return RepositorioDeUsuarios.Listar(Id);
        }

        public UsuarioLogin Login(string username, string password, int idAplicacion)
        {
            return RepositorioDeUsuarios.Login(username, password, idAplicacion);
        }

        //public UsuarioLogin LoginPaciente(UsuarioPaciente usuarioPaciente)
        //{
        //    throw new NotImplementedException();
        //}

        public UsuarioLogin ObtenerMenu(UsuarioLogin usuarioLogin)
        {
            return RepositorioDeUsuarios.ObtenerMenu(usuarioLogin);
        }

        public void UsuarioCerrarSesion(int idUsuario)
        {
            RepositorioDeUsuarios.UsuarioCerrarSesion(idUsuario);
        }

        public void UsuarioLogueado(int idUsuario, string ipAddress)
        {
            RepositorioDeUsuarios.UsuarioLogueado(idUsuario, ipAddress);
        }

        public EmpleadoGeneral ObtenerUsuario(int Id)
        {
            return RepositorioDeUsuarios.ObtenerUsuario(Id);
        }

        public UsuarioLogin CorroborarCredenciales(int IdUsuario)
        {
            return RepositorioDeUsuarios.CorroborarCredenciales(IdUsuario);
        }

        public async Task<UsuarioFinger> ValidarUsuario(string usuario, string clave)
        {
            return await RepositorioDeUsuarios.ValidarUsuario(usuario, clave);
        }

        public async Task<RespuestaBD> AgregarRutaHuella(AgregarHuellaEmpleado request)
        {
            return await RepositorioDeUsuarios.AgregarRutaHuella(request);
        }

        public async Task<RespuestaBD> AgregarPIN(AgregarPINEmpleado request)
        {
            return await RepositorioDeUsuarios.AgregarPIN(request);
        }

        public async Task<RespuestaBD> AgregarRutaRostro(AgregarHuellaEmpleado request)
        {
            return await RepositorioDeUsuarios.AgregarRutaRostro(request);
        }
    }
}
