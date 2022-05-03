using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ino_InvisionCore.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FacturacionController : ControllerBase
    {
        private readonly IServicioDeFacturacion _servicio;

        public FacturacionController(IServicioDeFacturacion servicio)
        {
            _servicio = servicio;
        }
    }
}