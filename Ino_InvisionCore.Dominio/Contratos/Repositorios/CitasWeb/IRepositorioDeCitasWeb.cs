// IRepositorioDeCitasWeb.cs21:5121:51

using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.CitasWeb
{
    public interface IRepositorioDeCitasWeb
    {
        Task<RespuestaBD> RegistrarPaciente(RegistrarPacienteDto solicitud);
        Task<PacienteCitaWebLogin> Login(string usuario, string contrasena);
    }
}