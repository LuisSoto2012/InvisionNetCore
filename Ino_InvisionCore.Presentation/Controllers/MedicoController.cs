using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Medico;
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
    public class MedicoController : ControllerBase
    {
        private IServicioDeMedicos _servicioDeMedicos;

        public MedicoController(IServicioDeMedicos servicioDeMedicos)
        {
            _servicioDeMedicos = servicioDeMedicos;
        }

        [HttpGet]
        public IEnumerable<MedicoListar> ListarMedicosTicket()
        {
            return _servicioDeMedicos.ListarMedicosTicket();
        }

        [HttpGet]
        public IEnumerable<MedicoListar> ListarMedicos([FromQuery]MedicoListar medico)
        {
            return _servicioDeMedicos.ListarMedicos(medico);
        }

        [HttpGet]
        public IEnumerable<MedicoPorEspecialidad> ListarEspecialidadPorMedico([FromQuery]MedicoListar medico)
        {
            return _servicioDeMedicos.ListarEspecialidadPorMedico(medico);
        }
    }
}