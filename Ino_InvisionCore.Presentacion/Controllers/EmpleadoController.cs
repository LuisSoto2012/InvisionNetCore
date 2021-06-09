using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Seguridad;
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
    public class EmpleadoController : ControllerBase
    {
        private readonly IServicioDeUsuarios _servicioDeUsuarios;

        public EmpleadoController(IServicioDeUsuarios servicioDeUsuarios)
        {
            _servicioDeUsuarios = servicioDeUsuarios;
        }

        [HttpPost]
        public IActionResult Crear([FromBody]NuevoEmpleado Empleado)
        {
            var respuesta = _servicioDeUsuarios.Crear(Empleado);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<EmpleadoGeneral> Listar([FromQuery]int? Id)
        {
            return _servicioDeUsuarios.Listar(Id);
        }

        [HttpPost]
        public IActionResult Actualizar([FromBody]ActualizarEmpleado Empleado)
        {
            var respuesta = _servicioDeUsuarios.Actualizar(Empleado);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}