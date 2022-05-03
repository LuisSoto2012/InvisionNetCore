// IRepositorioDeFacturacion.cs18:1318:13

using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Facturacion
{
    public interface IRepositorioDeFacturacion
    {
        Task<RespuestaBD> RegistrarNotaCreditoDebito(RegistrarNotaCreditoDebitoDto solicitud);
    }
}