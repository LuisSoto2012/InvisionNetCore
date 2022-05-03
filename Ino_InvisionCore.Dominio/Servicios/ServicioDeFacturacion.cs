// ServicioDeFacturacion.cs18:1118:11

using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Facturacion;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Facturacion;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeFacturacion : IServicioDeFacturacion
    {
        public IRepositorioDeFacturacion _repositorio { get; set; }
        
        public ServicioDeFacturacion(IRepositorioDeFacturacion repositorio)
        {
            _repositorio = repositorio;
        }
        
        public async Task<RespuestaBD> RegistrarNotaCreditoDebito(RegistrarNotaCreditoDebitoDto solicitud)
        {
            return await _repositorio.RegistrarNotaCreditoDebito(solicitud);
        }
    }
}