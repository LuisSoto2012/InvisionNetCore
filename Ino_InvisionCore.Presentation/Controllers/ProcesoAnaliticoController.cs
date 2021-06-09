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
    //[ActionWorkFilter]
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
        public IActionResult AgregarCalibracionDeficiente([FromBody]NuevoCalibracionDeficiente itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarCalibracionDeficiente(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarEmpleoReactivo([FromBody]NuevoEmpleoReactivo itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarEmpleoReactivo(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarEquipoMalCalibrado([FromBody]NuevoEquipoMalCalibrado itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarEquipoMalCalibrado(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarEquipoUPS([FromBody]NuevoEquipoUPS itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarEquipoUPS(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarMaterialNoCalibrado([FromBody]NuevoMaterialNoCalibrado itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarMaterialNoCalibrado(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarMuestraHemolizadaLipemica([FromBody]NuevoMuestraHemolizadaLipemica itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarMuestraHemolizadaLipemica(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarPocoFrecuente([FromBody]NuevoPocoFrecuente itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarPocoFrecuente(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult AgregarSueroMalReferenciado([FromBody]NuevoSueroMalReferenciado itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.AgregarSueroMalReferenciado(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarCalibracionDeficiente([FromBody]ActualizarCalibracionDeficiente itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarCalibracionDeficiente(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarEmpleoReactivo([FromBody]ActualizarEmpleoReactivo itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarEmpleoReactivo(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarEquipoMalCalibrado([FromBody]ActualizarEquipoMalCalibrado itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarEquipoMalCalibrado(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarEquipoUPS([FromBody]ActualizarEquipoUPS itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarEquipoUPS(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarMaterialNoCalibrado([FromBody]ActualizarMaterialNoCalibrado itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarMaterialNoCalibrado(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarMuestraHemolizadaLipemica([FromBody]ActualizarMuestraHemolizadaLipemica itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarMuestraHemolizadaLipemica(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarPocoFrecuente([FromBody]ActualizarPocoFrecuente itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarPocoFrecuente(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public IActionResult EditarSueroMalReferenciado([FromBody]ActualizarSueroMalReferenciado itemGeneral)
        {
            var respuesta = _servicioDeProcesoAnalitico.EditarSueroMalReferenciado(itemGeneral);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<CalibracionDeficienteGeneral> ListarCalibracionDeficiente()
        {
            return _servicioDeProcesoAnalitico.ListarCalibracionDeficiente();
        }

        [HttpGet]
        public IEnumerable<EmpleoReactivoGeneral> ListarEmpleoReactivo()
        {
            return _servicioDeProcesoAnalitico.ListarEmpleoReactivo();
        }

        [HttpGet]
        public IEnumerable<EquipoMalCalibradoGeneral> ListarEquipoMalCalibrado()
        {
            return _servicioDeProcesoAnalitico.ListarEquipoMalCalibrado();
        }

        [HttpGet]
        public IEnumerable<EquipoUPSGeneral> ListarEquipoUPS()
        {
            return _servicioDeProcesoAnalitico.ListarEquipoUPS();
        }

        [HttpGet]
        public IEnumerable<MaterialNoCalibradoGeneral> ListarMaterialNoCalibrado()
        {
            return _servicioDeProcesoAnalitico.ListarMaterialNoCalibrado();
        }

        [HttpGet]
        public IEnumerable<MuestraHemolizadaLipemicaGeneral> ListarMuestraHemolizadaLipemica()
        {
            return _servicioDeProcesoAnalitico.ListarMuestraHemolizadaLipemica();
        }

        [HttpGet]
        public IEnumerable<PocoFrecuenteGeneral> ListarPocoFrecuente()
        {
            return _servicioDeProcesoAnalitico.ListarPocoFrecuente();
        }

        [HttpGet]
        public IEnumerable<SueroMalReferenciadoGeneral> ListarSueroMalReferenciado()
        {
            return _servicioDeProcesoAnalitico.ListarSueroMalReferenciado();
        }
    }
}