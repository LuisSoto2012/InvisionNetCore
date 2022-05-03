using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CallCenter.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CallCenter.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.CallCenter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CallCenterController : ControllerBase
    {
        private readonly IServicioDeCallCenter _servicio;
        
        public CallCenterController(IServicioDeCallCenter servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCitaCallCenter([FromBody]RegistrarCitaCallCenter solicitud)
        {
            var respuesta = await _servicio.RegistrarCitaCallCenter(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public async Task<IEnumerable<CitaCallCenterDto>> ListarCitaCallCenter([FromQuery]DateTime fechadesde, [FromQuery]DateTime fechaHasta)
        {
            return await _servicio.ListarCitaCallCenter(fechadesde, fechaHasta);
        }
    }
}