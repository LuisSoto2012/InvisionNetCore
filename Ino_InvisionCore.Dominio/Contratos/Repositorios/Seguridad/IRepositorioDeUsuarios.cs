using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Respuestas;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Seguridad
{
    /*public interface IRepositorioDeUsuarios : IMantenimientoBasico<NuevoEmpleado, ActualizarEmpleado, EmpleadoGeneral>
    {
        UsuarioLogin Login(string username, string password, int idAplicacion);
        //UsuarioLogin LoginPaciente(UsuarioPaciente usuarioPaciente);
        RespuestaBD CambioClave(UsuarioCambioClave usuarioCambioClave);
        UsuarioLogin ObtenerMenu(UsuarioLogin usuarioLogin);
        void UsuarioLogueado(int idUsuario, string ipAddress);
        void UsuarioCerrarSesion(int idUsuario);
        Empleado EncontrarEmpleado(int Id);

    }*/

    public interface IRepositorioDeUsuarios
    {
        IEnumerable<EmpleadoGeneral> Listar(int? Id);
        UsuarioLogin Login(string username, string password, int idAplicacion);
        RespuestaBD CambioClave(UsuarioCambioClave usuarioCambioClave);
        UsuarioLogin ObtenerMenu(UsuarioLogin usuarioLogin);
        void UsuarioLogueado(int idUsuario, string ipAddress);
        void UsuarioCerrarSesion(int idUsuario);
        Empleado EncontrarEmpleado(int Id);
        RespuestaBD Crear(NuevoEmpleado peticionDeCreacion);
        RespuestaBD Actualizar(ActualizarEmpleado peticionDeActualizacion);
        EmpleadoGeneral ObtenerUsuario(int Id);
        UsuarioLogin CorroborarCredenciales(int IdUsuario);
        Task<UsuarioFinger> ValidarUsuario(string usuario, string clave);
        Task<RespuestaBD> AgregarRutaHuella(AgregarHuellaEmpleado request);
        Task<RespuestaBD> AgregarPIN(AgregarPINEmpleado request);
        Task<RespuestaBD> AgregarRutaRostro(AgregarHuellaEmpleado request);
    }

}
