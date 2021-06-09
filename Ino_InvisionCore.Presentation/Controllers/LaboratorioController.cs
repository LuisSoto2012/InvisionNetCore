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
    //[ActionWorkFilter]
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
        public IActionResult AgregarIncidentesPacientes([FromBody]NuevoIncidentesPacientes editedItemMuestra)
        {
            var respuesta = _servicioDeTomaMuestra.AgregarIncidentesPacientes(editedItemMuestra);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarIncumplimientoAnalisis([FromBody]NuevoIncumplimientoAnalisis editedItemMuestra)
        {
            var respuesta = _servicioDeTomaMuestra.AgregarIncumplimientoAnalisis(editedItemMuestra);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarPruebasNoRealizadas([FromBody]NuevoPruebasNoRealizadas editedItemMuestra)
        {
            var respuesta = _servicioDeTomaMuestra.AgregarPruebasNoRealizadas(editedItemMuestra);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarRecoleccionMuestra([FromBody]NuevoRecoleccionMuestra editedItemMuestra)
        {
            var respuesta = _servicioDeTomaMuestra.AgregarRecoleccionMuestra(editedItemMuestra);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarVenopunturasFallidas([FromBody]NuevoVenopunturasFallidas editedItemMuestra)
        {
            var respuesta = _servicioDeTomaMuestra.AgregarVenopunturasFallidas(editedItemMuestra);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarIncidentesPacientes([FromBody]ActualizarIncidentesPacientes editedItemMuestra)
        {
            var respuesta = _servicioDeTomaMuestra.EditarIncidentesPacientes(editedItemMuestra);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarIncumplimientoAnalisis([FromBody]ActualizarIncumplimientoAnalisis editedItemMuestra)
        {
            var respuesta = _servicioDeTomaMuestra.EditarIncumplimientoAnalisis(editedItemMuestra);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarPruebasNoRealizadas([FromBody]ActualizarPruebasNoRealizadas editedItemMuestra)
        {
            var respuesta = _servicioDeTomaMuestra.EditarPruebasNoRealizadas(editedItemMuestra);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarRecoleccionMuestra([FromBody]ActualizarRecoleccionMuestra editedItemMuestra)
        {
            var respuesta = _servicioDeTomaMuestra.EditarRecoleccionMuestra(editedItemMuestra);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarVenopunturasFallidas([FromBody]ActualizarVenopunturasFallidas editedItemMuestra)
        {
            var respuesta = _servicioDeTomaMuestra.EditarVenopunturasFallidas(editedItemMuestra);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<IncidentesPacientesGeneral> ListarIncidentesPacientes()
        {
            return _servicioDeTomaMuestra.ListarIncidentesPacientes();
        }

        [HttpGet]
        public IEnumerable<IncumplimientoAnalisisGeneral> ListarIncumplimientoAnalisis()
        {
            return _servicioDeTomaMuestra.ListarIncumplimientoAnalisis();
        }

        [HttpGet]
        public IEnumerable<PruebasNoRealizadasGeneral> ListarPruebasNoRealizadas()
        {
            return _servicioDeTomaMuestra.ListarPruebasNoRealizadas();
        }

        [HttpGet]
        public IEnumerable<RecoleccionMuestraGeneral> ListarRecoleccionMuestra()
        {
            return _servicioDeTomaMuestra.ListarRecoleccionMuestra();
        }

        [HttpGet]
        public IEnumerable<VenopunturasFallidasGeneral> ListarVenopunturasFallidas()
        {
            return _servicioDeTomaMuestra.ListarVenopunturasFallidas();
        }

    }
}