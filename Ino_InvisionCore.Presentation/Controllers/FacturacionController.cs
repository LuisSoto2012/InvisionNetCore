using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Facturacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FacturacionController : ControllerBase
    {
        private readonly IServicioDeFacturacion _servicio;

        public FacturacionController(IServicioDeFacturacion servicio)
        {
            _servicio = servicio;
        }
        
        [HttpGet(Name = "ListarComprobantesPago")]
        [ProducesResponseType(typeof(IEnumerable<ComprobantePagoDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ComprobantePagoDto>>> ListarComprobantesPago([FromQuery]DateTime fechaDesde, [FromQuery]DateTime fechaHasta,
                                                                        [FromQuery]int idTipoDocumento)
        {
            var lista = await _servicio.ListarComprobantesPago(fechaDesde, fechaHasta, idTipoDocumento);
            return Ok(lista);
        }
        
        [HttpPost(Name = "RegistrarNotaCreditoDebito")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarNotaCreditoDebito([FromBody]RegistrarNotaCreditoDebitoDto solicitud)
        {
            var respuesta = await _servicio.RegistrarNotaCreditoDebito(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
        
        [HttpGet(Name = "ListarTipoOperacion")]
        [ProducesResponseType(typeof(IEnumerable<ComboBox>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ComboBox>>> ListarTipoOperacion()
        {
            var lista = await _servicio.ListarTipoOperacion();
            return Ok(lista);
        }
        
        [HttpGet(Name = "ListarDistritos")]
        [ProducesResponseType(typeof(IEnumerable<ComboBox>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ComboBox>>> ListarDistritos()
        {
            var lista = await _servicio.ListarDistritos();
            return Ok(lista);
        }
        
        [HttpGet(Name = "ListarComprobantesPagoGalenos")]
        [ProducesResponseType(typeof(IEnumerable<ComprobantePagoGalenosDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ComprobantePagoGalenosDto>>> ListarComprobantesPagoGalenos([FromQuery]string filtroTexto, [FromQuery]string filtro)
        {
            var lista = await _servicio.ListarComprobantesPagoGalenos(filtroTexto, filtro);
            return Ok(lista);
        }
        
        [HttpPost(Name = "RegistrarProveedor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarProveedor([FromBody]RegistrarProveedorDto solicitud)
        {
            var respuesta = await _servicio.RegistrarProveedor(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
        
        [HttpPost(Name = "ActualizarProveedor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ActualizarProveedor([FromBody]ActualizarProveedorDto solicitud)
        {
            var respuesta = await _servicio.ActualizarProveedor(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
        
        [HttpGet(Name = "ListarProveedores")]
        [ProducesResponseType(typeof(IEnumerable<ComboBox>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ComboBox>>> ListarProveedores()
        {
            var lista = await _servicio.ListarProveedores();
            return Ok(lista);
        }
        
        [HttpGet(Name = "BuscarProveedor")]
        [ProducesResponseType(typeof(ProveedorDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProveedorDto>> BuscarProveedor([FromQuery]string ruc, [FromQuery]string razonSocial)
        {
            var proveedor = await _servicio.BuscarProveedor(ruc, razonSocial);
            return Ok(proveedor);
        }
    }
}