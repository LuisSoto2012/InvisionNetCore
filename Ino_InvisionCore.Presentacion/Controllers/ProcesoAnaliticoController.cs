using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.CalibracionDeficiente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.CalibracionDeficiente.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EmpleoReactivo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EmpleoReactivo.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoMalCalibrado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoMalCalibrado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoUPS.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.EquipoUPS.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MaterialNoCalibrado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MaterialNoCalibrado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MustraHemolizadaLipemica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.MustraHemolizadaLipemica.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PocoFrecuente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PocoFrecuente.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SueroMalReferenciado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SueroMalReferenciado.Respuestas;
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
    public class ProcesoAnaliticoController : ControllerBase
    {
        private IServicioDeProcesoAnalitico _servicioDeProcesoAnalitico;

        public ProcesoAnaliticoController(IServicioDeProcesoAnalitico servicioDeProcesoAnalitico)
        {
            _servicioDeProcesoAnalitico = servicioDeProcesoAnalitico;
        }

        [HttpPost]
        public IActionResult AgregarCalibracionDeficiente([FromBody]NuevoCalibracionDeficiente nuevoCalibracionDeficiente)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarCalibracionDeficiente(nuevoCalibracionDeficiente);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarEmpleoReactivo([FromBody]NuevoEmpleoReactivo nuevoEmpleoReactivo)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarEmpleoReactivo(nuevoEmpleoReactivo);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarEquipoMalCalibrado([FromBody]NuevoEquipoMalCalibrado nuevoEquipoMalCalibrado)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarEquipoMalCalibrado(nuevoEquipoMalCalibrado);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarEquipoUPS([FromBody]NuevoEquipoUPS nuevoEquipoUPS)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarEquipoUPS(nuevoEquipoUPS);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarMaterialNoCalibrado([FromBody]NuevoMaterialNoCalibrado nuevoMaterialNoCalibrado)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarMaterialNoCalibrado(nuevoMaterialNoCalibrado);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarMuestraHemolizadaLipemica([FromBody]NuevoMuestraHemolizadaLipemica nuevoMuestraHemolizadaLipemica)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarMuestraHemolizadaLipemica(nuevoMuestraHemolizadaLipemica);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarPocoFrecuente([FromBody]NuevoPocoFrecuente nuevoPocoFrecuente)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarPocoFrecuente(nuevoPocoFrecuente);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarSueroMalReferenciado([FromBody]NuevoSueroMalReferenciado nuevoSueroMalReferenciado)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarSueroMalReferenciado(nuevoSueroMalReferenciado);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarCalibracionDeficiente([FromBody]ActualizarCalibracionDeficiente actualizarCalibracionDeficiente)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarCalibracionDeficiente(actualizarCalibracionDeficiente);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarEmpleoReactivo([FromBody]ActualizarEmpleoReactivo actualizarEmpleoReactivo)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarEmpleoReactivo(actualizarEmpleoReactivo);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarEquipoMalCalibrado([FromBody]ActualizarEquipoMalCalibrado actualizarEquipoMalCalibrado)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarEquipoMalCalibrado(actualizarEquipoMalCalibrado);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarEquipoUPS([FromBody]ActualizarEquipoUPS actualizarEquipoUPS)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarEquipoUPS(actualizarEquipoUPS);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarMaterialNoCalibrado([FromBody]ActualizarMaterialNoCalibrado actualizarMaterialNoCalibrado)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarMaterialNoCalibrado(actualizarMaterialNoCalibrado);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarMuestraHemolizadaLipemica([FromBody]ActualizarMuestraHemolizadaLipemica actualizarMuestraHemolizadaLipemica)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarMuestraHemolizadaLipemica(actualizarMuestraHemolizadaLipemica);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarPocoFrecuente([FromBody]ActualizarPocoFrecuente actualizarPocoFrecuente)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarPocoFrecuente(actualizarPocoFrecuente);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarSueroMalReferenciado([FromBody]ActualizarSueroMalReferenciado actualizarSueroMalReferenciado)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarSueroMalReferenciado(actualizarSueroMalReferenciado);

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<CalibracionDeficienteGeneral> ListarCalibracionDeficiente([FromQuery]int? Id)
        {
            return _servicioDeProcesoAnalitico.ListarCalibracionDeficiente(Id);
        }

        [HttpGet]
        public IEnumerable<EmpleoReactivoGeneral> ListarEmpleoReactivo([FromQuery]int? Id)
        {
            return _servicioDeProcesoAnalitico.ListarEmpleoReactivo(Id);
        }

        [HttpGet]
        public IEnumerable<EquipoMalCalibradoGeneral> ListarEquipoMalCalibrado([FromQuery]int? Id)
        {
            return _servicioDeProcesoAnalitico.ListarEquipoMalCalibrado(Id);
        }

        [HttpGet]
        public IEnumerable<EquipoUPSGeneral> ListarEquipoUPS([FromQuery]int? Id)
        {
            return _servicioDeProcesoAnalitico.ListarEquipoUPS(Id);
        }

        [HttpGet]
        public IEnumerable<MaterialNoCalibradoGeneral> ListarMaterialNoCalibrado([FromQuery]int? Id)
        {
            return _servicioDeProcesoAnalitico.ListarMaterialNoCalibrado(Id);
        }

        [HttpGet]
        public IEnumerable<MuestraHemolizadaLipemicaGeneral> ListarMuestraHemolizadaLipemica([FromQuery]int? Id)
        {
            return _servicioDeProcesoAnalitico.ListarMuestraHemolizadaLipemica(Id);
        }

        [HttpGet]
        public IEnumerable<PocoFrecuenteGeneral> ListarPocoFrecuente([FromQuery]int? Id)
        {
            return _servicioDeProcesoAnalitico.ListarPocoFrecuente(Id);
        }

        [HttpGet]
        public IEnumerable<SueroMalReferenciadoGeneral> ListarSueroMalReferenciado([FromQuery]int? Id)
        {
            return _servicioDeProcesoAnalitico.ListarSueroMalReferenciado(Id);
        }
    }
}