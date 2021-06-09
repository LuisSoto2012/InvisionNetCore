using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Paciente
{
    public interface IServicioDePacientes
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
    }
}
