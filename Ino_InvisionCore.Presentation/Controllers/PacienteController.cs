using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Paciente;
using Ino_InvisionCore.Dominio.Contratos.Servicios.RecetaMedica;
using Ino_InvisionCore.Presentacion.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    //[ActionWorkFilter]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IServicioDePacientes _servicioDePacientes;
        private readonly IServicioDeRecetasMedicas _servicioDeRecetasMedicas;

        public PacienteController(IServicioDePacientes servicioDePacientes, IServicioDeRecetasMedicas servicioDeRecetasMedicas)
        {
            _servicioDePacientes = servicioDePacientes;
            _servicioDeRecetasMedicas = servicioDeRecetasMedicas;
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
        public IEnumerable<HistorialAtenciones> ListarHistorialHospitalizacion([FromQuery]PacientePorHcDni paciente)
        {
            return _servicioDePacientes.ListarHistorialHospitalizacion(paciente);
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

        [HttpGet]
        public IEnumerable<RecetaMedicaEstandarDTO> ListarHistorialRecetaMedicaEstandar([FromQuery]string historiaClinica)
        {
            return _servicioDeRecetasMedicas.ListarRecetaMedicaEstandar(historiaClinica);
        }

        [HttpGet]
        public RecetaMedicaEstandarImprimirDTO ImprimirRecetaMedicaEstandar([FromQuery]int idRecetaMedica)
        {
            return _servicioDeRecetasMedicas.ImprimirRecetaMedicaEstandar(idRecetaMedica);
        }
    }
}