using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.OrdenMedica;
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
    public class OrdenMedicaController : ControllerBase
    {
        IServicioDeOrdenesMedicas _servicioDeOrdenesMedicas;

        public OrdenMedicaController(IServicioDeOrdenesMedicas servicioDeOrdenesMedicas)
        {
            _servicioDeOrdenesMedicas = servicioDeOrdenesMedicas;
        }

        [HttpPost]
        public IActionResult AgregarOrdenMedica([FromBody]NuevaOrdenMedica nuevaOrdenMedica)
        {
            var respuesta = _servicioDeOrdenesMedicas.AgregarOrdenMedica(nuevaOrdenMedica);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });

        }

        [HttpGet]
        public IEnumerable<OrdenMedicaGeneral> ListarOrdenesMedicas([FromQuery]int? IdUsuario, [FromQuery]int? IdOrdenMedica, [FromQuery]int? idAtencion)
        {
            return _servicioDeOrdenesMedicas.ListarOrdenesMedicas(IdUsuario, IdOrdenMedica, idAtencion);
        }

        [HttpGet]
        public async Task<IEnumerable<OrdenMedicaGeneral>> ListarOrdenesMedicasPorDocumento([FromQuery]string numeroDocumento)
        {
            return await _servicioDeOrdenesMedicas.ListarOrdenesMedicasPorDocumento(numeroDocumento);
        }

        [HttpGet]
        public IEnumerable<TipoOrdenMedicaGeneral> ListarTipoOrdenMedica([FromQuery]int? Id)
        {
            return _servicioDeOrdenesMedicas.ListarTipoOrdenMedica(Id);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarOrdenMedica([FromBody]EliminarOrdenMedica eliminarOrdenMedica)
        {
            var respuesta = await _servicioDeOrdenesMedicas.EliminarOrdenMedica(eliminarOrdenMedica.IdOrdenMedica);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });

        }
    }
}