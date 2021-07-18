using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Servicios.ConsultasWeb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitasWebController : ControllerBase
    {
        private readonly IServicioDeCitasWeb _servicio;

        public CitasWebController(IServicioDeCitasWeb servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPaciente(RegistrarPacienteDto solicitud)
        {
            var respuesta = await _servicio.RegistrarPaciente(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}