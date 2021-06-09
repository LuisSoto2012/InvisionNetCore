using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Atencion;
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
    public class AtencionController : ControllerBase
    {
        private IServicioDeAtenciones _servicioDeAtenciones;

        public AtencionController(IServicioDeAtenciones servicioDeAtenciones)
        {
            _servicioDeAtenciones = servicioDeAtenciones;
        }

        [HttpGet]
        public IEnumerable<CitadosPorFecha> ListarCitadosPorFecha([FromQuery]CitasPor citasPor)
        {
            return _servicioDeAtenciones.ListarCitadosPorFecha(citasPor);
        }

        [HttpGet]
        public IEnumerable<CitadosPorFechaMedicoEspecialidad> ListarCitadosPorFechaMedicoEspecialidad([FromQuery]PacientesPor PacientesPor)
        {
            return _servicioDeAtenciones.ListarCitadosPorFechaMedicoEspecialidad(PacientesPor);
        }

        [HttpGet]
        public IEnumerable<AtencionFiltro> ListarAtenciones([FromQuery]AtencionesPor atencionesPor)
        {
            return _servicioDeAtenciones.ListarAtenciones(atencionesPor);
        }

        [HttpGet]
        public IEnumerable<Diagnostico> ListarDiagnosticos([FromQuery]Diagnostico diagnostico)
        {
            return _servicioDeAtenciones.ListarDiagnosticos(diagnostico);
        }

        [HttpGet]
        public IEnumerable<ProcedimientoDto> ListarProcedimientos([FromQuery]ProcedimientoDto procedimiento)
        {
            return _servicioDeAtenciones.ListarProcedimientos(procedimiento);
        }

        [HttpPost]
        public IActionResult RegistrarAtencion([FromBody]RegistroAtencion nuevaAtencion)
        {
            var respuesta = _servicioDeAtenciones.RegistrarAtencion(nuevaAtencion);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult ActualizarAtencion([FromBody]RegistroAtencion nuevaAtencion)
        {
            var respuesta = _servicioDeAtenciones.ActualizarAtencion(nuevaAtencion);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}