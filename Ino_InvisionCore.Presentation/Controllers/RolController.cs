using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Seguridad;
using Ino_InvisionCore.Presentacion.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    [Authorize]
    //[ActionWorkFilter]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IServicioDeRoles _servicioDeRoles;

        public RolController(IServicioDeRoles servicioDeRoles)
        {
            _servicioDeRoles = servicioDeRoles;
        }

        [HttpPost]
        public IActionResult Crear([FromBody]NuevoRol editedItem)
        {
            var respuesta = _servicioDeRoles.Crear(editedItem);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });

        }

        [HttpGet]
        public IEnumerable<RolGeneral> Listar([FromQuery]int? Id)
        {
            return _servicioDeRoles.Listar(Id);
        }

        [HttpPost]
        public IActionResult Actualizar([FromBody]ActualizarRol editedItem)
        {
            var respuesta = _servicioDeRoles.Actualizar(editedItem);

            if (respuesta.Id == 0)
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}