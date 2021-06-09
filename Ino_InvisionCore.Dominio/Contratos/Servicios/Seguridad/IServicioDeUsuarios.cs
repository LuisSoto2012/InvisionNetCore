using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Seguridad
{
    public interface IServicioDeUsuarios
    {
        UsuarioLogin Login(string username, string password, int idAplicacion);
        Task<UsuarioFinger> ValidarUsuario(string usuario, string clave);
        //UsuarioLogin LoginPaciente(UsuarioPaciente usuarioPaciente);
        RespuestaBD CambioClave(UsuarioCambioClave usuarioCambioClave);
        UsuarioLogin ObtenerMenu(UsuarioLogin usuarioLogin);
        void UsuarioLogueado(int idUsuario, string ipAddress);
        void UsuarioCerrarSesion(int idUsuario);
        IEnumerable<EmpleadoGeneral> Listar(int? Id);
        RespuestaBD Crear(NuevoEmpleado peticionDeCreacion);
        RespuestaBD Actualizar(ActualizarEmpleado peticionDeActualizacion);
        EmpleadoGeneral ObtenerUsuario(int Id);
        UsuarioLogin CorroborarCredenciales(int IdUsuario);
        Task<RespuestaBD> AgregarRutaHuella(AgregarHuellaEmpleado request);
        Task<RespuestaBD> AgregarPIN(AgregarPINEmpleado request);
        Task<RespuestaBD> AgregarRutaRostro(AgregarHuellaEmpleado request);
    }

    //public interface IServicioDeUsuarios : IServicioMantenimientoBasico<NuevoEmpleado, ActualizarEmpleado, EmpleadoGeneral>
    //{
    //    UsuarioLogin Login(string username, string password, int idAplicacion);
    //    //UsuarioLogin LoginPaciente(UsuarioPaciente usuarioPaciente);
    //    RespuestaBD CambioClave(UsuarioCambioClave usuarioCambioClave);
    //    UsuarioLogin ObtenerMenu(UsuarioLogin usuarioLogin);
    //    void UsuarioLogueado(int idUsuario, string ipAddress);
    //    void UsuarioCerrarSesion(int idUsuario);

    //}
}
