using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Comunes;
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
    public class ComunesController : ControllerBase
    {
        private IServicioDeComunes _servicioDeComunes;

        public ComunesController(IServicioDeComunes servicioDeComunes)
        {
            _servicioDeComunes = servicioDeComunes;
        }

        [HttpGet]
        public IEnumerable<ComboBox> ListarCondicionTrabajo()
        {
            return _servicioDeComunes.ListarCondicionTrabajo();
        }

        [HttpGet]
        public IEnumerable<ComboBox> ListarTipoDocumentoIdentidad()
        {
            return _servicioDeComunes.ListarTipoDocumentoIdentidad();
        }

        [HttpGet]
        public IEnumerable<ComboBox> ListarTipoEmpleado()
        {
            return _servicioDeComunes.ListarTipoEmpleado();
        }

        [HttpGet]
        public IEnumerable<ComboBox> ListarAreaLaboratorio([FromQuery]int? Id)
        {
            return _servicioDeComunes.ListarAreaLaboratorio(Id);
        }

        [HttpGet]
        public IEnumerable<ComboBox> ListarPruebaLabotario([FromQuery]string Codigo)
        {
            return _servicioDeComunes.ListarPruebaLabotario(Codigo);
        }

        [HttpGet]
        public IEnumerable<ComboBox> ListarServicioEspecialidad([FromQuery]int? Id)
        {
            return _servicioDeComunes.ListarServicioEspecialidad(Id);
        }

        [HttpGet]
        public IEnumerable<ComboBox> ListarEspecialidades()
        {
            return _servicioDeComunes.ListarEspecialidades();
        }

        [HttpGet]
        public IEnumerable<ComboBox> ListarUsuarioPorRol([FromQuery]int IdRol)
        {
            return this._servicioDeComunes.ListarUsuarioPorRol(IdRol);
        }

        [HttpGet]
        public IEnumerable<ComboBox> ListarAlmacenes()
        {
            return this._servicioDeComunes.ListarAlmacenes();
        }

        [HttpGet]
        public IEnumerable<ComboBox> ListarEscalafonDeLegajos()
        {
            return this._servicioDeComunes.ListarEscalafonDeLegajos();
        }

        [HttpGet]
        public IEnumerable<ComboBox> ListarCajeros()
        {
            return this._servicioDeComunes.ListarCajeros();
        }

        [HttpGet]
        public async Task<IEnumerable<ComboBox>> ListarEspecificaciones()
        {
            return await _servicioDeComunes.ListarEspecificaciones();
        }

        [HttpGet]
        public async Task<IEnumerable<ComboBox>> ListarBifocales()
        {
            return await _servicioDeComunes.ListarBifocales();
        }

        [HttpGet]
        public async Task<IEnumerable<ComboBox>> ListarMateriales()
        {
            return await _servicioDeComunes.ListarMateriales();
        }

        [HttpGet]
        public async Task<IEnumerable<ComboBox>> ListarMedicamentosFarmacia()
        {
            return await _servicioDeComunes.ListarMedicamentosFarmacia();
        }
    }
}