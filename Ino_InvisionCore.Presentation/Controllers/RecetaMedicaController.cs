using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.RecetaMedica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentation.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecetaMedicaController : ControllerBase
    {
        private IServicioDeRecetasMedicas _servicioDeRecetasMedicas;

        public RecetaMedicaController(IServicioDeRecetasMedicas servicioDeRecetasMedicas)
        {
            _servicioDeRecetasMedicas = servicioDeRecetasMedicas;
        }

        [HttpPost]
        public IActionResult AgregarRecetaMedicaEstandar([FromBody]NuevaRecetaMedicaEstandar parametros)
        {
            var respuesta = _servicioDeRecetasMedicas.AgregarRecetaMedicaEstandar(parametros);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public async Task<IActionResult> ModificarRecetaMedicaEstandar([FromBody]ModificarRecetaMedicaEstandarDto dto)
        {
            var respuesta = await _servicioDeRecetasMedicas.ModificarRecetaMedicaEstandar(dto);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<MedicamentoGeneral> ListarMedicamentos([FromQuery] bool sisFlag)
        {
            return _servicioDeRecetasMedicas.ListarMedicamentos(sisFlag);
        }

        [HttpGet]
        public async Task<RecetaMedicaEstandarDTO> ObtenerRecetaMedicaPorAtencion([FromQuery]int idAtencion)
        {
            return await _servicioDeRecetasMedicas.ObtenerRecetaMedicaPorAtencion(idAtencion);
        }


        [HttpGet]
        public async Task<IEnumerable<RecetaMedicaPorDocDto>> ListarRecetasPorDocumento([FromQuery]string numeroDocumento)
        {
            return await _servicioDeRecetasMedicas.ListarRecetasPorDocumento(numeroDocumento);
        }

    }
}
