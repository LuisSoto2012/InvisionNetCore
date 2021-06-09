using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Atencion;
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
    public class AtencionController : ControllerBase
    {
        private IServicioDeAtenciones _servicioDeAtenciones;

        public AtencionController(IServicioDeAtenciones servicioDeAtenciones)
        {
            _servicioDeAtenciones = servicioDeAtenciones;
        }

        [HttpGet]
        public IEnumerable<CitadosPorFecha> ListarCitadosPorFecha([FromQuery]CitasPor parametrosCitados)
        {
            return _servicioDeAtenciones.ListarCitadosPorFecha(parametrosCitados);
        }

        [HttpGet]
        public IEnumerable<CitadosPorFechaMedicoEspecialidad> ListarCitadosPorFechaMedicoEspecialidad([FromQuery]PacientesPor parametrosCitadosLista)
        {
            return _servicioDeAtenciones.ListarCitadosPorFechaMedicoEspecialidad(parametrosCitadosLista);
        }

        [HttpGet]
        public IEnumerable<AtencionFiltro> ListarAtenciones([FromQuery]AtencionesPor parametros)
        {
            return _servicioDeAtenciones.ListarAtenciones(parametros);
        }

        [HttpGet]
        public IEnumerable<Diagnostico> ListarDiagnosticos([FromQuery]Diagnostico parametrosBusqueda)
        {
            return _servicioDeAtenciones.ListarDiagnosticos(parametrosBusqueda);
        }

        [HttpGet]
        public IEnumerable<ProcedimientoDto> ListarProcedimientos([FromQuery]ProcedimientoDto parametrosBusquedaProc)
        {
            return _servicioDeAtenciones.ListarProcedimientos(parametrosBusquedaProc);
        }

        [HttpPost]
        public IActionResult RegistrarAtencion([FromBody]RegistroAtencion parametrosRegistro)
        {
            var respuesta = _servicioDeAtenciones.RegistrarAtencion(parametrosRegistro);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult ActualizarAtencion([FromBody]RegistroAtencion parametrosRegistro)
        {
            var respuesta = _servicioDeAtenciones.ActualizarAtencion(parametrosRegistro);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        #region Receta Refraccion

        [HttpPost]
        public async Task<IActionResult> AgregarRecetaRefraccion([FromBody]RegistroRecetaRefraccion parametrosRegistro)
        {
            var respuesta = await _servicioDeAtenciones.AgregarRecetaRefraccion(parametrosRegistro);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public async Task<IEnumerable<RecetaRefraccionDto>> ListarRecetaRefraccion([FromQuery]DateTime fecha)
        {
            return await _servicioDeAtenciones.ListarRecetaRefraccion(fecha);
        }

        [HttpPost]
        public async Task<IActionResult> ImprimirRecetaRefraccion([FromBody]ImprimirRecetaRefraccion parametros)
        {
            var respuesta = await _servicioDeAtenciones.ImprimirRecetaRefraccion(parametros);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }



        #endregion

        [HttpPost]
        public async Task<IActionResult> RegistrarEvaluacionExamen([FromBody]RegistrarEvaluacionExamenDto solicitud)
        {
            var respuesta = await _servicioDeAtenciones.RegistrarEvaluacionExamen(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public async Task<IEnumerable<EvaluacionExamenDto>> ListarEvaluacionExamenPorAtencion([FromQuery]int idAtencion)
        {
            return await _servicioDeAtenciones.ListarEvaluacionExamenPorAtencion(idAtencion);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarEvaluacionExamen([FromBody]EliminarEvaluacionExamenDto solicitud)
        {
            var respuesta = await _servicioDeAtenciones.EliminarEvaluacionExamen(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}