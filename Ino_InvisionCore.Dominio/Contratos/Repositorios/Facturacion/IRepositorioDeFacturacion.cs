// IRepositorioDeFacturacion.cs18:1318:13

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Facturacion;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Facturacion
{
    public interface IRepositorioDeFacturacion
    {
        Task<RespuestaBD> RegistrarNotaCreditoDebito(RegistrarNotaCreditoDebitoDto solicitud);
        Task<IEnumerable<FactComprobantesPago>> ListarComprobantesPago(DateTime fechaDesde, DateTime fechaHasta,
            int idTipoDocumento);

        Task<IEnumerable<FactTipoOperacion>> ListarTipoOperacion(int idTipoDocumento);
        Task<IEnumerable<ComboBox>> ListarDistritos();
        Task<IEnumerable<ComprobantePagoGalenosDto>> ListarComprobantesPagoGalenos(string filtroTexto, string filtro);
        Task<RespuestaBD> RegistrarProveedor(RegistrarProveedorDto solicitud);
        Task<RespuestaBD> ActualizarProveedor(ActualizarProveedorDto solicitud);
        Task<Proveedores> ObtenerProveedorPorId(int idProveedor);
        Task<IEnumerable<Proveedores>> ListarProveedores();
        Task<Proveedores> BuscarProveedor(string ruc, string razonSocial);
    }
}