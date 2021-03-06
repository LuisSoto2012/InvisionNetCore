using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Atencion
{
    public interface IServicioDeAtenciones
    {
        IEnumerable<AtencionFiltro> ListarAtenciones(AtencionesPor atencionesPor);
        IEnumerable<CitadosPorFecha> ListarCitadosPorFecha(CitasPor citasPor);
        IEnumerable<CitadosPorFechaMedicoEspecialidad> ListarCitadosPorFechaMedicoEspecialidad(PacientesPor PacientesPor);
        RespuestaBD RegistrarAtencion(RegistroAtencion nuevaAtencion);
        RespuestaBD ActualizarAtencion(RegistroAtencion nuevaAtencion);
        IEnumerable<Diagnostico> ListarDiagnosticos(Diagnostico diagnostico);
        IEnumerable<ProcedimientoDto> ListarProcedimientos(ProcedimientoDto procedimiento);

        Task<RespuestaBD> AgregarRecetaRefraccion(RegistroRecetaRefraccion parametrosRegistro);
        Task<IEnumerable<RecetaRefraccionDto>> ListarRecetaRefraccion(DateTime fechaDesde, DateTime fechaHasta);
        Task<RespuestaBD> ImprimirRecetaRefraccion(ImprimirRecetaRefraccion parametros);
        Task<RespuestaBD> RegistrarEvaluacionExamen(RegistrarEvaluacionExamenDto solicitud);
        Task<IEnumerable<EvaluacionExamenDto>> ListarEvaluacionExamenPorAtencion(int idAtencion);
        Task<RespuestaBD> EliminarEvaluacionExamen(EliminarEvaluacionExamenDto solicitud);
        Task<IEnumerable<CitaPorDiaDto>> ListarCitasPorDia(int nroHistoria, string nroDocumento);
        Task<RespuestaBD> GuardarIngresoPaciente(GaurdarIngresoPacienteDto solicitud);
        Task<int> ObtenerCantidadIngresosHoy();
        Task<IEnumerable<IngresoSalidaDto>> ListarIngresosSalidasHoy();
        Task<IEnumerable<MedicoCitadosDto>> ListarMedicosProgramadosHoy();
        Task<IEnumerable<MedicoCitadosDto>> ListarMedicosProgramadosEspecialidadFecha(int idEspecialidad, DateTime fecha);
        Task<RespuestaBD> ReprogramacionMedicaPorMedico(ReprogramacionMedicaPorMedicoDto solicitud);
        Task<IEnumerable<ReprogramacionMedicaDto>> ListarReprogramacionesMedicas(DateTime fecha);
        Task<CitaGalenosTicketDto> ObtenerDatosCitaTicket(int numeroCuenta);
        Task<IEnumerable<AtencionConstanciaTop5Dto>> ListarAtencionesConstanciaTop5(string nroDocumento);

        Task<CitaPorNroCuentaDto> ObtenerCitaPorNroCuenta(int nroCuenta);
        Task<RespuestaBD> ReprogramacionMedicaPorPaciente(ReprogramacionMedicaPorPacienteDto solicitud);
        Task<IEnumerable<MedicoPorEspecialidadDto>> ListarMedicosPorEspecialidad(int idEspecialidad);
        Task<ProgramacionPorFechaEspecialidadDto> ObtenerProgramacionPorFechaEspecialidad(DateTime fecha, int especialidad, int idMedico);
        Task<IEnumerable<ReprogramacionesCuposLibresDto>> ReprogramacionesCuposLibres(int idProgramacion);

        Task<PersonalDto> BuscarEmpleado(string dni);
    }
}
