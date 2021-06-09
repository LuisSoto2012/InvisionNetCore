using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.ConsultaWeb;
using Ino_InvisionCore.Dominio.Contratos.Servicios.ConsultaWeb;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeConsultaWeb : IServicioDeConsultaWeb
    {
        public IRepositorioDeConsultaWeb _repositorio { get; set; }

        #region Teleorientacion y teleconsulta

        public ServicioDeConsultaWeb(IRepositorioDeConsultaWeb repositorio)
        {
            _repositorio = repositorio;
        }

        public RespuestaBD CrearSolicitudCita(RegistroSolicitudCita solicitud)
        {
            return _repositorio.CrearSolicitudCita(solicitud);
        }

        public async Task<IEnumerable<SolicitudCitaDto>> ListarSolicitudCita(int idEstado, DateTime fechaSolicitud)
        {
            return await _repositorio.ListarSolicitudCita(idEstado, fechaSolicitud);
        }

        public async Task<RespuestaBD> AceptarRechazarSolicitudCita(AceptarRechazarSolicitudCita operacionCita)
        {
            return await _repositorio.AceptarRechazarSolicitudCita(operacionCita);
        }

        public async Task<RespuestaBD> AtenderSolicitudCita(AtenderSolicitudCita cita)
        {
            return await _repositorio.AtenderSolicitudCita(cita);
        }

        public async Task<RespuestaBD> ActualizarAtencionCita(AtenderSolicitudCita cita)
        {
            return await _repositorio.ActualizarAtencionCita(cita);
        }

        public RespuestaBD ValidarSolicitudCita(RegistroSolicitudCita solicitud)
        {
            return _repositorio.ValidarSolicitudCita(solicitud);
        }

        public async Task<CitaCuarentenaDto> ConsultarCitaCuarentena(string dni)
        {
            return await _repositorio.ConsultarCitaCuarentena(dni);
        }

        public async Task<RespuestaBD> CrearSolicitudReprogramacion(RegistroSolicitudReprogramacion solicitud)
        {
            return await _repositorio.CrearSolicitudReprogramacion(solicitud);
        }

        public async Task<RespuestaBD> EnviarCorreoCitaCuarentena(EnviarCorreoCuarentenaDto solicitud)
        {
            return await _repositorio.EnviarCorreoCitaCuarentena(solicitud);
        }

        public async Task<CitaCuarentenaCorreoDto> ObtenerDataCitaCuarentena(int idCuentaAtencion)
        {
            return await _repositorio.ObtenerDataCitaCuarentena(idCuentaAtencion);
        }

        public async Task<IEnumerable<SolicitudReprogramacionCitaCuarentenaDto>> ListarSolicitudReprogramacionCitaCuarentena()
        {
            return await _repositorio.ListarSolicitudReprogramacionCitaCuarentena();
        }

        public async Task<ConteoCGDto> ListarTotalCG(DateTime fecha)
        {
            return await _repositorio.ListarTotalCG(fecha);
        }

        public async Task<RespuestaBD> GuardarNuevaFechaReprogramacion(GuardarNuevaFechaReprogramacionDto solicitud)
        {
            return await _repositorio.GuardarNuevaFechaReprogramacion(solicitud);
        }

        public async Task<RespuestaBD> ValidarReprogramacion(ValidarReprogramacionDto solicitud)
        {
            return await _repositorio.ValidarReprogramacion(solicitud);
        }

        public async Task<RespuestaBD> CrearSolicitudTeleconsulta(CrearSolicitudTeleconsultaDto solicitud)
        {
            return await _repositorio.CrearSolicitudTeleconsulta(solicitud);
        }

        public async Task<IEnumerable<CitaPostCuarentenaDto>> ListarCitasPostCuarentena(string dni)
        {
            return await _repositorio.ListarCitasPostCuarentena(dni);
        }

        public async Task<RespuestaBD> AceptarSolicitudTeleconsulta(AceptarSolicitudTeleconsultaDto solicitud)
        {
            return await _repositorio.AceptarSolicitudTeleconsulta(solicitud);
        }

        public async Task<IEnumerable<SolicitudTeleconsultaDto>> ListarSolicitudTeleconsulta(int idEstado, DateTime fecha)
        {
            return await _repositorio.ListarSolicitudTeleconsulta(idEstado, fecha);
        }

        public ConsultaRENIECDto ObtenerDatosGeneralesRENIEC(string dni)
        {
            return _repositorio.ObtenerDatosGeneralesRENIEC(dni);
        }

        #endregion

        #region Consulta Rapida

        public async Task<RespuestaBD> CrearSolicitudConsultaRapida(RegistroSolicitudConsultaRapidaDto solicitud)
        {
            return await _repositorio.CrearSolicitudConsultaRapida(solicitud);
        }

        public async Task<IEnumerable<ComboBox>> ListarCuposConsultaRapida(DateTime fecha, string horaInicio, string horaFin, int intervalo)
        {
            return await _repositorio.ListarCuposConsultaRapida(fecha, horaInicio, horaFin, intervalo);
        }

        public async Task<IEnumerable<SolicitudConsultaRapidaDto>> ListarSolicitudConsultaRapida(DateTime fechaDesde, DateTime fechaHasta, int? idEstado)
        {
            return await _repositorio.ListarSolicitudConsultaRapida(fechaDesde, fechaHasta, idEstado);
        }

        public async Task<RespuestaBD> AceptarSolicitudConsultaRapida(AceptarSolicitudConsultaRapidaDto solicitud)
        {
            return await _repositorio.AceptarSolicitudConsultaRapida(solicitud);
        }

        #endregion

        #region Comunes

        public async Task<IEnumerable<ComboBox>> ListarEspecialidadesPorFechaConsultaRapida(DateTime fechaCita)
        {
            return await _repositorio.ListarEspecialidadesPorFechaConsultaRapida(fechaCita);
        }

        public async Task<IEnumerable<ComboBoxMedico>> ListarMedicosPorEspecialidadConsultaRapida(DateTime fechaCita, int idEspecialidad)
        {
            return await _repositorio.ListarMedicosPorEspecialidadConsultaRapida(fechaCita, idEspecialidad);
        }

        public async Task<IEnumerable<ComboBox>> ListarCuposPorProgramacionConsultaRapida(int idProgramacion)
        {
            return await _repositorio.ListarCuposPorProgramacionConsultaRapida(idProgramacion);
        }

        #endregion
    }
}
