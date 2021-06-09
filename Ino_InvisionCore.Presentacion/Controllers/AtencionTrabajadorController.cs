using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Servicios.AtencionTrabajador;
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
    public class AtencionTrabajadorController : ControllerBase
    {
        private IServicioDeAtencionesTrabajadores _servicioDeAtencionesTrabajadores;

        public AtencionTrabajadorController(IServicioDeAtencionesTrabajadores servicioDeAtencionesTrabajadores)
        {
            _servicioDeAtencionesTrabajadores = servicioDeAtencionesTrabajadores;
        }

        [HttpPost]
        public IActionResult RegistrarAtencionTrabajador([FromBody]NuevaAtencionTrabajador nuevaAtencionTrabajador)
        {
            var respuesta = _servicioDeAtencionesTrabajadores.RegistrarAtencionTrabajador(nuevaAtencionTrabajador);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}