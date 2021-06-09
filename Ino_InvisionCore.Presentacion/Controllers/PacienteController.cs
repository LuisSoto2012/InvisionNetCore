using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Paciente;
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
    public class PacienteController : ControllerBase
    {
        private IServicioDePacientes _servicioDePacientes;

        public PacienteController(IServicioDePacientes servicioDePacientes)
        {
            _servicioDePacientes = servicioDePacientes;
        }

        [HttpGet]
        public IEnumerable<HistorialAtenciones> ListarHistorialAtenciones([FromQuery]PacientePorHcDni paciente)
        {
            return _servicioDePacientes.ListarHistorialAtenciones(paciente);
        }

        [HttpGet]
        public IEnumerable<HistorialCentroQuirurgico> ListarHistorialCentroQuirurgico([FromQuery]PacientePorHcDni paciente)
        {
            return _servicioDePacientes.ListarHistorialCentroQuirurgico(paciente);
        }

        [HttpGet]
        public IEnumerable<HistorialEmergencia> ListarHistorialEmergencia([FromQuery]PacientePorHcDni paciente)
        {
            return _servicioDePacientes.ListarHistorialEmergencia(paciente);
        }

        [HttpGet]
        public IEnumerable<HistorialLaboratorio> ListarHistorialLaboratorio([FromQuery]PacientePorHcDni paciente)
        {
            return _servicioDePacientes.ListarHistorialLaboratorio(paciente);
        }

        [HttpGet]
        public IEnumerable<HistorialRiesgoQuirurgico> ListarHistorialRiesgoQuirurgico([FromQuery]PacientePorHcDni paciente)
        {
            return _servicioDePacientes.ListarHistorialRiesgoQuirurgico(paciente);
        }

        [HttpGet]
        public PacienteAfiliacion ListarPacientePorHcDni([FromQuery]PacientePorHcDni paciente)
        {
            return _servicioDePacientes.ListarPacientePorHcDni(paciente);
        }

        [HttpGet]
        public IEnumerable<PacientePorHcDni> ListarPacientesCitadosPorEspecialidadMedicoFecha([FromQuery]BuscarPaciente paciente)
        {
            return _servicioDePacientes.ListarPacientesCitadosPorEspecialidadMedicoFecha(paciente);
        }
    }
}