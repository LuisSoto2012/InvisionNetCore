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

        public async Task<IEnumerable<ComboBox>> ListarTipoOperacion()
        {
            var listaDb = await _repositorio.ListarTipoOperacion();

            return listaDb.Select(x => _mapper.Map<ComboBox>(x));
        }
    }
}