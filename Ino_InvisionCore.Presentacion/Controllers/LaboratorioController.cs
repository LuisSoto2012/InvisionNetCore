using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncidentesPacientes.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncidentesPacientes.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncumplimientoAnalisis.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncumplimientoAnalisis.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PruebasNoRealizadas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PruebasNoRealizadas.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RecoleccionMuestra.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RecoleccionMuestra.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.VenopunturasFallidas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.VenopunturasFallidas.Respuestas;
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
    public class LaboratorioController : ControllerBase
    {
        private IServicioDeTomaMuestra _servicioDeTomaMuestra;

        public LaboratorioController(IServicioDeTomaMuestra servicioDeTomaMuestra)
        {
            _servicioDeTomaMuestra = servicioDeTomaMuestra;
        }

        [HttpPost]
        public IActionResult AgregarIncidentesPacientes([FromBody]NuevoIncidentesPacientes nuevoIncidentesPacientes)
        {
            var respuesta = _servicioDeTomaMuestra.AgregarIncidentesPacientes(nuevoIncidentesPacientes);

            if (respuesta.Id == 0)
                return BadRequest(new { respuesta.Id, respuesta.Mensaje });
            else
                return Ok(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarIncumplimientoAnalisis([FromBody]NuevoIncumplimientoAnalisis nuevoIncumplimientoAnalisis)
        {
            var respuesta = _servicioDeTomaMuestra.AgregarIncumplimientoAnalisis(nuevoIncumplimientoAnalisis);

            if (respuesta.Id == 0)
                return BadRequest(new { respuesta.Id, respuesta.Mensaje });
            else
                return Ok(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarPruebasNoRealizadas([FromBody]NuevoPruebasNoRealizadas nuevoPruebasNoRealizadas)
        {
            var respuesta = _servicioDeTomaMuestra.AgregarPruebasNoRealizadas(nuevoPruebasNoRealizadas);

            if (respuesta.Id == 0)
                return BadRequest(new { respuesta.Id, respuesta.Mensaje });
            else
                return Ok(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarRecoleccionMuestra([FromBody]NuevoRecoleccionMuestra nuevoRecoleccionMuestra)
        {
            var respuesta = _servicioDeTomaMuestra.AgregarRecoleccionMuestra(nuevoRecoleccionMuestra);

            if (respuesta.Id == 0)
                return BadRequest(new { respuesta.Id, respuesta.Mensaje });
            else
                return Ok(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarVenopunturasFallidas([FromBody]NuevoVenopunturasFallidas nuevoVenopunturasFallidas)
        {
            var respuesta = _servicioDeTomaMuestra.AgregarVenopunturasFallidas(nuevoVenopunturasFallidas);

            if (respuesta.Id == 0)
                return BadRequest(new { respuesta.Id, respuesta.Mensaje });
            else
                return Ok(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarIncidentesPacientes([FromBody]ActualizarIncidentesPacientes actualizarIncidentesPacientes)
        {
            var respuesta = _servicioDeTomaMuestra.EditarIncidentesPacientes(actualizarIncidentesPacientes);

            if (respuesta.Id == 0)
                return BadRequest(new { respuesta.Id, respuesta.Mensaje });
            else
                return Ok(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarIncumplimientoAnalisis([FromBody]ActualizarIncumplimientoAnalisis actualizarIncumplimientoAnalisis)
        {
            var respuesta = _servicioDeTomaMuestra.EditarIncumplimientoAnalisis(actualizarIncumplimientoAnalisis);

            if (respuesta.Id == 0)
                return BadRequest(new { respuesta.Id, respuesta.Mensaje });
            else
                return Ok(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarPruebasNoRealizadas([FromBody]ActualizarPruebasNoRealizadas actualizarPruebasNoRealizadas)
        {
            var respuesta = _servicioDeTomaMuestra.EditarPruebasNoRealizadas(actualizarPruebasNoRealizadas);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarRecoleccionMuestra([FromBody]ActualizarRecoleccionMuestra actualizarRecoleccionMuestra)
        {
            var respuesta = _servicioDeTomaMuestra.EditarRecoleccionMuestra(actualizarRecoleccionMuestra);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarVenopunturasFallidas([FromBody]ActualizarVenopunturasFallidas actualizarVenopunturasFallidas)
        {
            var respuesta = _servicioDeTomaMuestra.EditarVenopunturasFallidas(actualizarVenopunturasFallidas);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<IncidentesPacientesGeneral> ListarIncidentesPacientes([FromQuery]int? Id)
        {
            return _servicioDeTomaMuestra.ListarIncidentesPacientes(Id);
        }

        [HttpGet]
        public IEnumerable<IncumplimientoAnalisisGeneral> ListarIncumplimientoAnalisis([FromQuery]int? Id)
        {
            return _servicioDeTomaMuestra.ListarIncumplimientoAnalisis(Id);
        }

        [HttpGet]
        public IEnumerable<PruebasNoRealizadasGeneral> ListarPruebasNoRealizadas([FromQuery]int? Id)
        {
            return _servicioDeTomaMuestra.ListarPruebasNoRealizadas(Id);
        }

        [HttpGet]
        public IEnumerable<RecoleccionMuestraGeneral> ListarRecoleccionMuestra([FromQuery]int? Id)
        {
            return _servicioDeTomaMuestra.ListarRecoleccionMuestra(Id);
        }

        [HttpGet]
        public IEnumerable<VenopunturasFallidasGeneral> ListarVenopunturasFallidas([FromQuery]int? Id)
        {
            return _servicioDeTomaMuestra.ListarVenopunturasFallidas(Id);
        }

    }
}