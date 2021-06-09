using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Compartido;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Aplicacion
{
    public interface IRepositorioDeAplicaciones : IMantenimientoBasico<NuevaAplicacion, ActualizarAplicacion, AplicacionGeneral>
    {
        Entidades.Aplicacion ObtenerAplicacion(int idAplicacion);
        Task<Entidades.Aplicacion> ObtenerAplicacionAsync(int idAplicacion);
    }
}
