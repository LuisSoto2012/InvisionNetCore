using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Laboratorio;
using Ino_InvisionCore.Presentacion.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    [Authorize]
    [ActionWorkFilter]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndicadoresGestionController : ControllerBase
    {
        private IServicioDeIndicadoresGestion _servicioDeIndicadoresGestion;

        public IndicadoresGestionController(IServicioDeIndicadoresGestion servicioDeIndicadoresGestion)
        {
            _servicioDeIndicadoresGestion = servicioDeIndicadoresGestion;
        }

        [HttpPost]
        public IActionResult AgregarRendimientoHoraTrabajador([FromBody]NuevoRendimientoHoraTrabajador nuevoRendimientoHoraTrabajador)
        {
            var respuesta = _servicioDeIndicadoresGestion.AgregarRendimientoHoraTrabajador(nuevoRendimientoHoraTrabajador);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarRendimientoHoraTrabajador([FromBody]ActualizarRendimientoHoraTrabajador actualizarRendimientoHoraTrabajador)
        {
            var respuesta = _servicioDeIndicadoresGestion.EditarRendimientoHoraTrabajador(actualizarRendimientoHoraTrabajador);

            if (respuesta.Id == 0)
                return BadRequest(new { respuesta.Id, respuesta.Mensaje });
            else
                return Ok(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<RendimientoHoraTrabajadorGeneral> ListarRendimientoHoraTrabajador([FromQuery]int? Id)
        {
            return _servicioDeIndicadoresGestion.ListarRendimientoHoraTrabajador(Id);
        }
    }
}