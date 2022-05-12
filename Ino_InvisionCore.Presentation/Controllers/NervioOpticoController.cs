using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.NervioOptico.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.NervioOptico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.NervioOptico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentation.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NervioOpticoController : ControllerBase
    {
        private readonly IServicioDeNervioOptico _servicio;

        public NervioOpticoController(IServicioDeNervioOptico servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarInformeNervioOptico([FromBody]RegistrarNervioOptico solicitud)
        {
            var respuesta = await _servicio.RegistrarNervioOptico(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public async Task<IActionResult> ModificarInformeNervioOptico([FromBody]ModificarNervioOptico solicitud)
        {
            var respuesta = await _servicio.ModificarNervioOptico(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public async Task<IEnumerable<NervioOpticoDto>> ListarInformeNervioOptico([FromQuery]int idAtencion)
        {
            return await _servicio.ListarNervioOptico(idAtencion);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarInformeNervioOptico([FromBody]EliminarNervioOptico solicitud)
        {
            var respuesta = await _servicio.EliminarNervioOptico(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}