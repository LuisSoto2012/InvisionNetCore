using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Evaluacion;
using Ino_InvisionCore.Infraestructura.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EvaluacionController : ControllerBase
    {
        private IServicioDeEvaluaciones _servicio;

        public EvaluacionController(IServicioDeEvaluaciones servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPreguntaYRespuestas([FromBody]RegistrarPreguntaRespuestaDto solicitud)
        {
            var respuesta = await _servicio.RegistrarPreguntaYRespuestas(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
        
        [HttpGet]
        public async Task<IEnumerable<EvalPreguntaDto>> ListarPreguntas([FromQuery] string modulo)
        {
            return await _servicio.ListarPreguntas(modulo);
        }

        [HttpPost]
        public async Task<IActionResult> ActivarPregunta([FromBody] ActivarPreguntaDto solicitud)
        {
            var respuesta = await _servicio.ActivarPregunta(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public async Task<IActionResult> ModificarPreguntaYRespuestas([FromBody] ModificarPreguntaRespuestaDto solicitud)
        {
            var respuesta = await _servicio.ModificarPreguntaYRespuestas(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}