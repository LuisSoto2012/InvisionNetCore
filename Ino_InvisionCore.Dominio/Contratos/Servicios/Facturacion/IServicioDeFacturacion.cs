using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Facturacion
{
    public interface IServicioDeFacturacion
    {
        Task<RespuestaBD> RegistrarNotaCreditoDebito(RegistrarNotaCreditoDebitoDto solicitud);
        Task<IEnumerable<ComprobantePagoDto>> ListarComprobantesPago(DateTime fechaDesde, DateTime fechaHasta,
            int idTipoDocumento);
        Task<IEnumerable<ComboBox>> ListarTipoOperacion();
        Task<IEnumerable<ComboBox>> ListarDistritos();
        Task<IEnumerable<ComprobantePagoGalenosDto>> ListarComprobantesPagoGalenos(string filtroTexto, string filtro);
        Task<RespuestaBD> RegistrarProveedor(RegistrarProveedorDto solicitud);
        Task<RespuestaBD> ActualizarProveedor(ActualizarProveedorDto solicitud);
        Task<IEnumerable<ProveedorDto>> ListarProveedores();
        Task<ProveedorDto> BuscarProveedor(string ruc, string razonSocial);
    }
}
