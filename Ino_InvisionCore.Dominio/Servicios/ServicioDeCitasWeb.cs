// ServicioDeConsultasWeb.cs22:2622:26

using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.CitasWeb;
using Ino_InvisionCore.Dominio.Contratos.Servicios.ConsultasWeb;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeCitasWeb : IServicioDeCitasWeb
    {
        private readonly IRepositorioDeCitasWeb _repositorio;

        public ServicioDeCitasWeb(IRepositorioDeCitasWeb repositorio)
        {
            _repositorio = repositorio;
        }
        
        public async Task<RespuestaBD> RegistrarPaciente(RegistrarPacienteDto solicitud)
        {
            return await _repositorio.RegistrarPaciente(solicitud);
        }
    }
}