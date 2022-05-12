using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Laboratorio;
using Ino_InvisionCore.Presentacion.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    //[ActionWorkFilter]
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
        public IActionResult AgregarRendimientoHoraTrabajador([FromBody]NuevoRendimientoHoraTrabajador itemGeneral)
        {
            var respuesta = _servicioDeIndicadoresGestion.AgregarRendimientoHoraTrabajador(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarRendimientoHoraTrabajador([FromBody]ActualizarRendimientoHoraTrabajador itemGeneral)
        {
            var respuesta = _servicioDeIndicadoresGestion.EditarRendimientoHoraTrabajador(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<RendimientoHoraTrabajadorGeneral> ListarRendimientoHoraTrabajador()
        {
            return _servicioDeIndicadoresGestion.ListarRendimientoHoraTrabajador();
        }

        [HttpPost]
        public IActionResult AgregarExamenAtendidoPorServicio([FromBody]NuevoExamenAtendidoPorServicio itemGeneral)
        {
            var respuesta = _servicioDeIndicadoresGestion.AgregarExamenAtendidoPorServicio(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarExamenAtendidoPorServicio([FromBody]ActualizarExamenAtendidoPorServicio itemGeneral)
        {
            var respuesta = _servicioDeIndicadoresGestion.EditarExamenAtendidoPorServicio(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<ExamenAtendidoPorServicioDto> ListarExamenAtendidoPorServici()
        {
            return _servicioDeIndicadoresGestion.ListarExamenAtendidoPorServicio();
        }

        [HttpPost]
        public IActionResult AgregarExamenNoInformadoPorServicio([FromBody]NuevoExamenNoInformadoPorServicio itemGeneral)
        {
            var respuesta = _servicioDeIndicadoresGestion.AgregarExamenNoInformadoPorServicio(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarExamenNoInformadoPorServicio([FromBody]ActualizarExamenNoInformadoPorServicio itemGeneral)
        {
            var respuesta = _servicioDeIndicadoresGestion.EditarExamenNoInformadoPorServicio(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<ExamenNoInformadoPorServicioDto> ListarExamenNoInformadoPorServicio()
        {
            return _servicioDeIndicadoresGestion.ListarExamenNoInformadoPorServicio();
        }
    }
}