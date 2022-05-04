using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones;
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
        
        [HttpPost(Name = "RegistrarNotaCreditoDebito")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarNotaCreditoDebito([FromBody]RegistrarNotaCreditoDebitoDto solicitud)
        {
            var respuesta = await _servicio.RegistrarNotaCreditoDebito(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}