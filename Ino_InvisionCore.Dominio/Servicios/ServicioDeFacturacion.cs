// ServicioDeFacturacion.cs18:1118:11

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Facturacion;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Facturacion;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeFacturacion : IServicioDeFacturacion
    {
        private IRepositorioDeFacturacion _repositorio;
        private IMapper _mapper;
        
        public ServicioDeFacturacion(IRepositorioDeFacturacion repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        
        public async Task<RespuestaBD> RegistrarNotaCreditoDebito(RegistrarNotaCreditoDebitoDto solicitud)
        {
            return await _repositorio.RegistrarNotaCreditoDebito(solicitud);
        }

        public async Task<IEnumerable<ComprobantePagoDto>> ListarComprobantesPago(DateTime fechaDesde, DateTime fechaHasta, int idTipoDocumento)
        {
            var listaDb = await _repositorio.ListarComprobantesPago(fechaDesde, fechaHasta, idTipoDocumento);

            var lista = listaDb.Select(x => _mapper.Map<ComprobantePagoDto>(x));

            return lista;
        }

        public async Task<IEnumerable<ComboBox>> ListarTipoOperacion(int idTipoDocumento)
        {
            var listaDb = await _repositorio.ListarTipoOperacion(idTipoDocumento);

            return listaDb.Select(x => _mapper.Map<ComboBox>(x));
        }
        
        public async Task<IEnumerable<ComboBox>> ListarDistritos()
        {
            return await _repositorio.ListarDistritos();
        }

        public async Task<IEnumerable<ComprobantePagoGalenosDto>> ListarComprobantesPagoGalenos(string filtroTexto, string filtro)
        {
            var listaDb = await _repositorio.ListarComprobantesPagoGalenos(filtroTexto, filtro);

            return listaDb;
        }

        public async Task<RespuestaBD> RegistrarProveedor(RegistrarProveedorDto solicitud)
        {
            return await _repositorio.RegistrarProveedor(solicitud);
        }

        public async Task<RespuestaBD> ActualizarProveedor(ActualizarProveedorDto solicitud)
        {
            return await _repositorio.ActualizarProveedor(solicitud);
        }

        public async Task<IEnumerable<ProveedorDto>> ListarProveedores()
        {
            var listaDb = await _repositorio.ListarProveedores();

            var lista = listaDb.Select(x => _mapper.Map<ProveedorDto>(x));

            return lista;
        }

        public async Task<ProveedorDto> BuscarProveedor(string ruc, string razonSocial)
        {
            var proveedorDb = await _repositorio.BuscarProveedor(ruc, razonSocial);

            return _mapper.Map<ProveedorDto>(proveedorDb);
        }
    }
}