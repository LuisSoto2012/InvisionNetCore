using System.Collections.Generic;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Adicional;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Presentacion.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    [Authorize]
    //[ActionWorkFilter]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdicionalesController : ControllerBase
    {
        private IServicioDeAdicionales _servicioDeAdicionales;

        public AdicionalesController(IServicioDeAdicionales servicioDeAdicionales)
        {
            _servicioDeAdicionales = servicioDeAdicionales;
        }

        [HttpGet(Name = "Adicionales por Filtors")]
        public IEnumerable<Adicionales> ConsultaExternaAdicionalesPorMedicoListar([FromQuery]BuscarPaciente paciente)
        {
            return _servicioDeAdicionales.ConsultaExternaAdicionalesPorMedicoListar(paciente);
        }
        
        [HttpGet(Name = "Adicionales por HC")]
        public async Task<IEnumerable<Adicionales>> ConsultaExternaAdicionalesPorMedicoListarPorHc([FromQuery]string hc)
        {
            return await _servicioDeAdicionales.ConsultaExternaAdicionalesPorMedicoListar(hc);
        }

        [HttpPost]
        public int ConsultaExternaAdicionalesPorMedicoRegistrar([FromBody]NuevoAdicional nuevaAdicional)
        {
            return _servicioDeAdicionales.ConsultaExternaAdicionalesPorMedicoRegistrar(nuevaAdicional);
        }

        [HttpPost]
        public async Task<RespuestaBD> ConsultaExternaAdicionalesPorMedicoEliminar(
            [FromBody] NuevoAdicional nuevoAdicional)
        {
            return await _servicioDeAdicionales.ConsultaExternaAdicionalesPorMedicoEliminar(nuevoAdicional.IdAdicional);
        }
    }
}