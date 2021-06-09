using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Paciente;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Paciente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDePacientes : IServicioDePacientes
    {
        public IRepositorioDePacientes RepositorioDePacientes { get; set; }

        public ServicioDePacientes(IRepositorioDePacientes repositorioDePacientes)
        {
            RepositorioDePacientes = repositorioDePacientes;
        }

        public IEnumerable<HistorialAtenciones> ListarHistorialAtenciones(PacientePorHcDni paciente)
        {
            return RepositorioDePacientes.ListarHistorialAtenciones(paciente);
        }

        public IEnumerable<HistorialCentroQuirurgico> ListarHistorialCentroQuirurgico(PacientePorHcDni paciente)
        {
            return RepositorioDePacientes.ListarHistorialCentroQuirurgico(paciente);
        }

        public IEnumerable<HistorialEmergencia> ListarHistorialEmergencia(PacientePorHcDni paciente)
        {
            return RepositorioDePacientes.ListarHistorialEmergencia(paciente);
        }

        public IEnumerable<HistorialLaboratorio> ListarHistorialLaboratorio(PacientePorHcDni paciente)
        {
            return RepositorioDePacientes.ListarHistorialLaboratorio(paciente);
        }

        public IEnumerable<HistorialRiesgoQuirurgico> ListarHistorialRiesgoQuirurgico(PacientePorHcDni paciente)
        {
            return RepositorioDePacientes.ListarHistorialRiesgoQuirurgico(paciente);
        }

        public PacienteCitado ListarPacienteCitadoDelDia(PacientePorHcDni pacientePorHcDni)
        {
            return RepositorioDePacientes.ListarPacienteCitadoDelDia(pacientePorHcDni);
        }

        public PacienteAfiliacion ListarPacientePorHcDni(PacientePorHcDni pacientePorHcDni)
        {
            return RepositorioDePacientes.ListarPacientePorHcDni(pacientePorHcDni);
        }

        public IEnumerable<PacientePorHcDni> ListarPacientesCitadosPorEspecialidadMedicoFecha(BuscarPaciente buscarPaciente)
        {
            return RepositorioDePacientes.ListarPacientesCitadosPorEspecialidadMedicoFecha(buscarPaciente);
        }

        public IEnumerable<HistorialAtenciones> ListarHistorialHospitalizacion(PacientePorHcDni paciente)
        {
            return RepositorioDePacientes.ListarHistorialHospitalizacion(paciente);
        }
    }
}
