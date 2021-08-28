using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.ConsultasWeb;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Presentacion.Models;
using Ino_InvisionCore.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace Ino_InvisionCore.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitasWebController : ControllerBase
    {
        private readonly IServicioDeCitasWeb _servicio;
        private readonly AppSettings _appSettings;

        public CitasWebController(IServicioDeCitasWeb servicio, IOptions<AppSettings> appSettings)
        {
            _servicio = servicio;
            _appSettings = appSettings.Value;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegistrarPaciente(RegistrarPacienteDto solicitud)
        {
            var respuesta = await _servicio.RegistrarPaciente(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginModel usuarioLogin)
        {
            var usuario = usuarioLogin.NombreUsuario;
            var contrasena = Security.HashSHA1(usuarioLogin.Contrasena);

            var user = await _servicio.Login(usuario, contrasena);

            if (user == null)
                return new OkObjectResult(new { FueExitosa = false , Mensaje = "Las credenciales son incorrectas" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.IdPacienteInvision.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return new OkObjectResult(new
            {
                IdPacienteInvision = user.IdPacienteInvision,
                IdPacienteGalenos = user.IdPacienteGalenos,
                Username = user.Usuario,
                FirstName = user.Nombres,
                LastName = user.ApellidoPaterno,
                Token = tokenString,
                FueExitosa = true,
                Usuario = user,
                Mensaje = "Bienvenido a Invision"
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> RegistrarConsultaRapida (RegistrarConsultaRapida solicitud)
        {
            var respuesta = await _servicio.RegistrarConsultaRapida(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public async Task<IEnumerable<CuposProgramacionDto>> ListarCuposProgramacion([FromQuery] DateTime fecha,
            [FromQuery] int idEspecialidad)
        {
            return await _servicio.ListarCuposProgramacion(fecha, idEspecialidad);
        }

        [HttpGet]
        public async Task<string[]> ListarFechasProgramacion([FromQuery] int idMedico, [FromQuery]int idEspecialidad)
        {
            return await _servicio.ListarFechasProgramacion(idMedico, idEspecialidad);
        }
        
        [HttpPost]
        public async Task<IActionResult> RegistrarCita (RegistrarCitaWeb solicitud)
        {
            var respuesta = await _servicio.RegistrarCita(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public async Task<IEnumerable<CitaWebDto>> ListarCitasWebPorPaciente([FromQuery] int idPaciente)
        {
            return await _servicio.ListarCitasWebPorPaciente(idPaciente);
        }
        
        [HttpPost]
        [RequestSizeLimit(100_000_000)]
        //[DisableFormValueModelBinding]
        public async Task<IActionResult> SubirVouchers([FromForm]VoucherFileFormData formData)
        {
            HttpRequest httpRequest = HttpContext.Request;
            RespuestaBD respuesta = new RespuestaBD();

            if (formData.Imagen.Count > 0)
            {
                for (int i = 0; i < formData.Imagen.Count; i++)
                {
                    IFormFile postedFile = formData.Imagen[i];
                    string rutaDeRepositorio = string.Concat(_appSettings.RepositorioVouchers, "\\", formData.NumeroDocumento, "\\");
                    if (!Directory.Exists(rutaDeRepositorio)) Directory.CreateDirectory(rutaDeRepositorio);
                    string rutaCompleta = string.Concat(rutaDeRepositorio, postedFile.FileName);
                    using (var fileStream = new FileStream(rutaCompleta, FileMode.Create))
                    {
                        postedFile.CopyTo(fileStream);
                    }

                    SubirVoucherDto dto = new SubirVoucherDto
                    {
                        IdCita = formData.IdCita,
                        NumeroDocumento = formData.NumeroDocumento,
                        RutaCompleta = rutaCompleta,
                        Voucher = formData.Voucher
                    };

                    respuesta = await _servicio.SubirVouchersACita(dto);
                }
            }
            else
            {
                // NO SE ENCONTRARON ARCHIVOS
                respuesta.Id = 0;
                respuesta.Mensaje = "No se seleccionaron archivos para subir.";
            }

            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });

        }
        
        [HttpPost]
        public async Task<IActionResult> EliminarVoucher([FromBody]EliminarVoucherDto archivoEliminado)
        {
            RespuestaBD respuesta = new RespuestaBD();
            string rutaCompleta = await _servicio.EliminarVoucher(archivoEliminado.IdCita);
            if (!string.IsNullOrEmpty(rutaCompleta))
            {
                System.IO.File.Delete(rutaCompleta);
                respuesta.Id = 1;
                respuesta.Mensaje = "El archivo fue eliminado correctamente.";
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
            }
            else
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "No se envontró ningún archivo para eliminar.";
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
            }
        }
        
        [HttpGet]
        public async Task<IEnumerable<CitaWebDto>> ListarCitasWebPorFecha([FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
            return await _servicio.ListarCitasWebPorFecha(fechaDesde, fechaHasta);
        }
        
        [HttpPost]
        public async Task<IActionResult> ValidarVoucher (ValidarVoucherDto solicitud)
        {
            var respuesta = await _servicio.ValidarVoucher(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
    }
}