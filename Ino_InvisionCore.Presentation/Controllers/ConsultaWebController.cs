using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.ConsultaWeb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConsultaWebController : ControllerBase
    {
        private IServicioDeConsultaWeb _servicio;

        public ConsultaWebController(IServicioDeConsultaWeb servicio)
        {
            _servicio = servicio;
        }

        #region Teleorientacion y Teleconsulta

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CrearSolicitudCita([FromBody] RegistroSolicitudCita solicitud)
        {
            var respuesta = _servicio.CrearSolicitudCita(solicitud);


            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ValidarSolicitudCita([FromBody] RegistroSolicitudCita solicitud)
        {
            var respuesta = _servicio.ValidarSolicitudCita(solicitud);


            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });

        }

        [HttpGet]
        public async Task<IEnumerable<SolicitudCitaDto>> ListarSolicitudCita([FromQuery] int idEstado, [FromQuery] DateTime fechaSolicitud)
        {
            return await _servicio.ListarSolicitudCita(idEstado, fechaSolicitud);
        }

        [HttpPost]
        public async Task<IActionResult> AceptarRechazarSolicitudCita([FromBody] AceptarRechazarSolicitudCita operacionCita)
        {
            var respuesta = await _servicio.AceptarRechazarSolicitudCita(operacionCita);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public async Task<IActionResult> AtenderSolicitudCita([FromBody] AtenderSolicitudCita cita)
        {
            var respuesta = await _servicio.AtenderSolicitudCita(cita);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarAtencionCita([FromBody] AtenderSolicitudCita cita)
        {
            var respuesta = await _servicio.ActualizarAtencionCita(cita);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<CitaCuarentenaDto> ConsultarCitaCuarentena([FromQuery] string dni)
        {
            return await _servicio.ConsultarCitaCuarentena(dni);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CrearSolicitudReprogramacion([FromBody] RegistroSolicitudReprogramacion solicitud)
        {
            var respuesta = await _servicio.CrearSolicitudReprogramacion(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> EnviarCorreoCitaCuarentena([FromBody] EnviarCorreoCuarentenaDto solicitud)
        {
            var respuesta = await _servicio.EnviarCorreoCitaCuarentena(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<CitaCuarentenaCorreoDto> ObtenerDataCitaCuarentena([FromQuery] int idCuentaAtencion)
        {
            return await _servicio.ObtenerDataCitaCuarentena(idCuentaAtencion);
        }

        [HttpGet]
        public async Task<IEnumerable<SolicitudReprogramacionCitaCuarentenaDto>> ListarSolicitudReprogramacionCitaCuarentena()
        {
            return await _servicio.ListarSolicitudReprogramacionCitaCuarentena();
        }

        [HttpGet]
        public async Task<ConteoCGDto> ListarTotalCG([FromQuery] DateTime fecha)
        {
            return await _servicio.ListarTotalCG(fecha);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarNuevaFechaReprogramacion([FromBody] GuardarNuevaFechaReprogramacionDto solicitud)
        {
            var respuesta = await _servicio.GuardarNuevaFechaReprogramacion(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public async Task<IActionResult> ValidarReprogramacion([FromBody] ValidarReprogramacionDto solicitud)
        {
            var respuesta = await _servicio.ValidarReprogramacion(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        //TeleConsulta
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CrearSolicitudTeleconsulta([FromBody] CrearSolicitudTeleconsultaDto solicitud)
        {
            var respuesta = await _servicio.CrearSolicitudTeleconsulta(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<CitaPostCuarentenaDto>> ListarCitasPostCuarentena([FromQuery] string dni)
        {
            return await _servicio.ListarCitasPostCuarentena(dni);
        }

        [HttpGet]
        public async Task<IEnumerable<SolicitudTeleconsultaDto>> ListarSolicitudTeleconsulta([FromQuery] int idEstado, [FromQuery] DateTime fechaSolicitud)
        {
            return await _servicio.ListarSolicitudTeleconsulta(idEstado, fechaSolicitud);
        }

        [HttpPost]
        public async Task<IActionResult> AceptarSolicitudTeleconsulta([FromBody] AceptarSolicitudTeleconsultaDto solicitud)
        {
            var respuesta = await _servicio.AceptarSolicitudTeleconsulta(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        //RENIEC
        [AllowAnonymous]
        [HttpGet]
        public ConsultaRENIECDto BuscarRENIEC([FromQuery] string dni)
        {
            return _servicio.ObtenerDatosGeneralesRENIEC(dni);
        }

        #endregion

        #region Consulta Rapida
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CrearSolicitudConsultaRapida([FromBody]RegistroSolicitudConsultaRapidaDto solicitud)
        {
            var respuesta = await _servicio.CrearSolicitudConsultaRapida(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public async Task<IEnumerable<ComboBox>> ListarCuposConsultaRapida([FromQuery]DateTime fecha, [FromQuery]string horaInicio, [FromQuery]string horaFin, [FromQuery]int intervalo)
        {
            return await _servicio.ListarCuposConsultaRapida(fecha, horaInicio, horaFin, intervalo);
        }

        [HttpGet]
        public async Task<IEnumerable<SolicitudConsultaRapidaDto>> ListarSolicitudConsultaRapida([FromQuery]DateTime fechaDesde, [FromQuery]DateTime fechaHasta, [FromQuery]int? idEstado)
        {
            return await _servicio.ListarSolicitudConsultaRapida(fechaDesde, fechaHasta, idEstado);
        }

        [HttpPost]
        public async Task<IActionResult> AceptarSolicitudConsultaRapida([FromBody]AceptarSolicitudConsultaRapidaDto solicitud)
        {
            var respuesta = await _servicio.AceptarSolicitudConsultaRapida(solicitud);

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        #endregion

        #region Comunes

        [HttpGet]
        public async Task<IEnumerable<ComboBox>> ListarEspecialidadesPorFechaConsultaRapida([FromQuery]DateTime fechaCita)
        {
            return await _servicio.ListarEspecialidadesPorFechaConsultaRapida(fechaCita);
        }

        [HttpGet]
        public async Task<IEnumerable<ComboBoxMedico>> ListarMedicosPorEspecialidadConsultaRapida([FromQuery] DateTime fechaCita, [FromQuery]int idEspecialidad)
        {
            return await _servicio.ListarMedicosPorEspecialidadConsultaRapida(fechaCita, idEspecialidad);
        }

        [HttpGet]
        public async Task<IEnumerable<ComboBox>> ListarCuposPorProgramacionConsultaRapida([FromQuery]int idProgramacion)
        {
            return await _servicio.ListarCuposPorProgramacionConsultaRapida(idProgramacion);
        }

        #endregion
    }
}