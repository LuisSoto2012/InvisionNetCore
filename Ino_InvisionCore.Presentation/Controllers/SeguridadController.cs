using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Usuario.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Seguridad;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Presentacion.Filters;
using Ino_InvisionCore.Presentacion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    //[ActionWorkFilter]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private IServicioDeUsuarios _servicioDeUsuarios;
        private readonly AppSettings _appSettings;

        public SeguridadController(IServicioDeUsuarios servicioDeUsuarios, IOptions<AppSettings> appSettings)
        {
            _servicioDeUsuarios = servicioDeUsuarios;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UsuarioLoginModel usuarioLogin)
        {
            var usuario = usuarioLogin.NombreUsuario;
            var contrasena = Security.HashSHA1(usuarioLogin.Contrasena);

            var user = _servicioDeUsuarios.Login(usuario, contrasena, usuarioLogin.IdAplicacion);

            if (user == null)
                return new OkObjectResult(new { FueExitosa = false , Mensaje = "Las credenciales son incorrectas" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.IdEmpleado.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return new OkObjectResult(new
            {
                IdEmpleado = user.IdEmpleado,
                Username = user.Usuario,
                FirstName = user.Nombres,
                LastName = user.ApellidoPaterno,
                Token = tokenString,
                FueExitosa = true,
                Mensaje = "Bienvenido a Invision"
            });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<UsuarioFinger> ValidarUsuario([FromQuery]string usuario, [FromQuery]string clave)
        {
            var claveEncriptada = Security.HashSHA1(clave);
            return await _servicioDeUsuarios.ValidarUsuario(usuario, claveEncriptada);
        }

        [HttpPost]
        public RespuestaBD CambioClave([FromBody] UsuarioCambioClave usuarioCambioClave)
        {
            return _servicioDeUsuarios.CambioClave(usuarioCambioClave);
        }

        [HttpGet]
        public void UsuarioLogueado([FromQuery]int IdUsuario, [FromQuery]string IpAddress)
        {
            _servicioDeUsuarios.UsuarioLogueado(IdUsuario, IpAddress);
        }

        [HttpGet]
        public void UsuarioCerrarSesion([FromQuery]int IdUsuario)
        {
            _servicioDeUsuarios.UsuarioCerrarSesion(IdUsuario);
        }

        [HttpGet]
        public UsuarioLogin CorroborarCredenciales([FromQuery]int IdEmpleado)
        {
            return _servicioDeUsuarios.CorroborarCredenciales(IdEmpleado);
        }
    }
}