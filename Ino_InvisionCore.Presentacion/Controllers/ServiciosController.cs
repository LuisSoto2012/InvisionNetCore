using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Servicios.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Servicios;
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
    public class ServiciosController : ControllerBase
    {
        private IServicioDeServicios _servicioDeServicios;

        public ServiciosController(IServicioDeServicios servicioDeServicios)
        {
            _servicioDeServicios = servicioDeServicios;
        }

        [HttpGet]
        public IEnumerable<ServicioPorEspecialidad> ListarServicioPorEspecialidad([FromQuery]MedicoPorEspecialidad especialidad)
        {
            return _servicioDeServicios.ListarServicioPorEspecialidad(especialidad);
        }

    }
}