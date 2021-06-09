using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.ConsultaWeb
{
    public interface IServicioDeConsultaWeb
    {
        RespuestaBD CrearSolicitudCita(RegistroSolicitudCita solicitud);
        RespuestaBD ValidarSolicitudCita(RegistroSolicitudCita solicitud);
        Task<IEnumerable<SolicitudCitaDto>> ListarSolicitudCita(int idEstado, DateTime fechaSolicitud);
        Task<RespuestaBD> AceptarRechazarSolicitudCita(AceptarRechazarSolicitudCita operacionCita);
        Task<RespuestaBD> AtenderSolicitudCita(AtenderSolicitudCita cita);
        Task<RespuestaBD> ActualizarAtencionCita(AtenderSolicitudCita cita);

        Task<CitaCuarentenaDto> ConsultarCitaCuarentena(string dni);
        Task<RespuestaBD> CrearSolicitudReprogramacion(RegistroSolicitudReprogramacion solicitud);
        Task<RespuestaBD> EnviarCorreoCitaCuarentena(EnviarCorreoCuarentenaDto solicitud);
        Task<CitaCuarentenaCorreoDto> ObtenerDataCitaCuarentena(int idCuentaAtencion);
        Task<IEnumerable<SolicitudReprogramacionCitaCuarentenaDto>> ListarSolicitudReprogramacionCitaCuarentena();
        Task<ConteoCGDto> ListarTotalCG(DateTime fecha);
        Task<RespuestaBD> GuardarNuevaFechaReprogramacion(GuardarNuevaFechaReprogramacionDto solicitud);
        Task<RespuestaBD> ValidarReprogramacion(ValidarReprogramacionDto solicitud);

        Task<RespuestaBD> CrearSolicitudTeleconsulta(CrearSolicitudTeleconsultaDto solicitud);
        Task<IEnumerable<CitaPostCuarentenaDto>> ListarCitasPostCuarentena(string dni);
        Task<RespuestaBD> AceptarSolicitudTeleconsulta(AceptarSolicitudTeleconsultaDto solicitud);
        Task<IEnumerable<SolicitudTeleconsultaDto>> ListarSolicitudTeleconsulta(int idEstado, DateTime fecha);

        ConsultaRENIECDto ObtenerDatosGeneralesRENIEC(string dni);

        Task<RespuestaBD> CrearSolicitudConsultaRapida(RegistroSolicitudConsultaRapidaDto solicitud);
        Task<IEnumerable<ComboBox>> ListarCuposConsultaRapida(DateTime fecha, string horaInicio, string horaFin, int intervalo);
        Task<IEnumerable<SolicitudConsultaRapidaDto>> ListarSolicitudConsultaRapida(DateTime fechaDesde, DateTime fechaHasta, int? idEstado);
        Task<RespuestaBD> AceptarSolicitudConsultaRapida(AceptarSolicitudConsultaRapidaDto solicitud);
    }
}
