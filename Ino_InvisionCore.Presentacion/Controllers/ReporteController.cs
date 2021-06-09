using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Reporte.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Reporte;
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
    public class ReporteController : ControllerBase
    {
        private IServicioDeReportes _servicioDeReportes;

        public ReporteController(IServicioDeReportes servicioDeReportes)
        {
            _servicioDeReportes = servicioDeReportes;
        }

        [HttpGet]
        public IEnumerable<ReporteGeneral> Listar([FromQuery]int? Id)
        {
            return _servicioDeReportes.ListarReportes(Id);
        }
    }
}