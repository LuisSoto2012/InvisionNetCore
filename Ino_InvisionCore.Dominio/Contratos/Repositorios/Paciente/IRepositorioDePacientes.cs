using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Paciente
{
    public interface IRepositorioDePacientes
    {
        PacienteAfiliacion ListarPacientePorHcDni(PacientePorHcDni pacientePorHcDni);
        IEnumerable<PacientePorHcDni> ListarPacientesCitadosPorEspecialidadMedicoFecha(BuscarPaciente buscarPaciente);
        IEnumerable<HistorialAtenciones> ListarHistorialAtenciones(PacientePorHcDni paciente);
        IEnumerable<HistorialAtenciones> ListarHistorialHospitalizacion(PacientePorHcDni paciente);
        IEnumerable<HistorialLaboratorio> ListarHistorialLaboratorio(PacientePorHcDni paciente);
        IEnumerable<HistorialRiesgoQuirurgico> ListarHistorialRiesgoQuirurgico(PacientePorHcDni paciente);
        IEnumerable<HistorialCentroQuirurgico> ListarHistorialCentroQuirurgico(PacientePorHcDni paciente);
        IEnumerable<HistorialEmergencia> ListarHistorialEmergencia(PacientePorHcDni paciente);
        PacienteCitado ListarPacienteCitadoDelDia(PacientePorHcDni pacientePorHcDni);

        Task<PacienteAfiliacion> ListarPacientePorHcDniAsync(PacientePorHcDni pacientePorHcDni);
        Task<IEnumerable<PacientePorHcDni>> ListarPacientesCitadosPorEspecialidadMedicoFechaAsync(BuscarPaciente buscarPaciente);
        Task<IEnumerable<HistorialAtenciones>> ListarHistorialAtencionesAsync(PacientePorHcDni paciente);
        Task<IEnumerable<HistorialLaboratorio>> ListarHistorialLaboratorioAsync(PacientePorHcDni paciente);
        Task<IEnumerable<HistorialRiesgoQuirurgico>> ListarHistorialRiesgoQuirurgicoAsync(PacientePorHcDni paciente);
        Task<IEnumerable<HistorialCentroQuirurgico>> ListarHistorialCentroQuirurgicoAsync(PacientePorHcDni paciente);
        Task<IEnumerable<HistorialEmergencia>> ListarHistorialEmergenciaAsync(PacientePorHcDni paciente);
        Task<PacienteCitado> ListarPacienteCitadoDelDiaAsync(PacientePorHcDni pacientePorHcDni);
    }
}
