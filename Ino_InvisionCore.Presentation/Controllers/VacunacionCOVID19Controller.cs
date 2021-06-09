using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.COVID19;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VacunacionCOVID19Controller : ControllerBase
    {
        private IServicioDeVacunacionCOVID19 _servicio;

        public VacunacionCOVID19Controller(IServicioDeVacunacionCOVID19 servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ConsultaDataDto> ObtenerDatosPorDocumento([FromQuery]string numeroDocumento)
        {
            return await _servicio.ObtenerDatosPorDocumento(numeroDocumento);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarConsentimientoInformado([FromBody]GuardarCIDto solicitud)
        {
            var respuesta = await _servicio.GuardarConsentimientoInformado(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public async Task<IEnumerable<DataCIDto>> ListarConsentimientosInformados([FromQuery]DateTime fechaDesde, [FromQuery]DateTime fechaHasta, [FromQuery]bool vacunacion)
        {
            return await _servicio.ListarConsentimientosInformados(fechaDesde, fechaHasta, vacunacion);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarVacunacion([FromBody]GuardarVacDto solicitud)
        {
            var respuesta = await _servicio.GuardarVacunacion(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public async Task<IActionResult> GuardarRevocatoria([FromBody]GuardarRevocatoriaDto solicitud)
        {
            var respuesta = await _servicio.GuardarRevocatoria(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}