using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Anestesia.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Anestesia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ino_InvisionCore.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnestesiaController : ControllerBase
    {
        private readonly IServicioDeAnestesias _servicio;

        public AnestesiaController(IServicioDeAnestesias servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarEvaluacionPreAnestesica(RegistrarEvaluacionPreAnestesica solicitud)
        {
            var respuesta = await _servicio.RegistrarEvaluacionPreAnestesica(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public async Task<IActionResult> ModificarEvaluacionPreAnestesica(ModificarEvaluacionPreAnestesica solicitud)
        {
            var respuesta = await _servicio.ModificarEvaluacionPreAnestesica(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}
