using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Archivo;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Ino_InvisionCore.Presentacion.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RepositorioArchivosController : ControllerBase
    {
        private IServicioDeArchivos _servicioDeArchivos;
        private readonly AppSettings _appSettings;

        public RepositorioArchivosController(IServicioDeArchivos servicioDeArchivos, IOptions<AppSettings> appSettings)
        {
            _servicioDeArchivos = servicioDeArchivos;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public IActionResult SubirArchivos()
        {
            HttpRequest httpRequest = HttpContext.Request;
            RespuestaBD respuesta = new RespuestaBD();

            if (httpRequest.Form.Files.Count > 0)
            {
                for (int i=0; i < httpRequest.Form.Files.Count; i++)
                {
                    IFormFile postedFile = httpRequest.Form.Files[i];
                    string rutaDeRepositorio = string.Concat(_appSettings.RutaDeRepositorio, httpRequest.Query["HistoriaClinica"].ToString(), "\\");
                    if (!Directory.Exists(rutaDeRepositorio)) Directory.CreateDirectory(rutaDeRepositorio);
                    string rutaCompleta = string.Concat(rutaDeRepositorio, postedFile.FileName);
                    using (var fileStream = new FileStream(rutaCompleta, FileMode.Create))
                    {
                        postedFile.CopyToAsync(fileStream);
                    }

                    NuevoArchivo nuevoArchivo = new NuevoArchivo
                    {
                        TipoArchivo = httpRequest.Query["TipoArchivo"].ToString(),
                        IdEspecialidad = int.Parse(httpRequest.Query["IdEspecialidad"].ToString()),
                        IdServicio = int.Parse(httpRequest.Query["IdServicio"].ToString()),
                        HistoriaClinica = httpRequest.Query["HistoriaClinica"].ToString(),
                        Ruta = rutaDeRepositorio,
                        NombreArchivo = postedFile.FileName,
                        RutaCompleta = rutaCompleta,
                        IdUsuarioCreacion = int.Parse(httpRequest.Query["IdUsuarioCreacion"].ToString())
                    };

                    respuesta = _servicioDeArchivos.Agregar(nuevoArchivo);
                }
            }
            else
            {
                // NO SE ENCONTRARON ARCHIVOS
                respuesta.Id = 0;
                respuesta.Mensaje = "No se seleccionaron archivos para subir.";
            }

            if (respuesta.Id == 0)
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            else
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public IEnumerable<ArchivoGeneral> ListarArchivos([FromQuery]ArchivoGeneral archivoGeneral)
        {
            return _servicioDeArchivos.Listar(archivoGeneral);
        }

        [HttpPost]
        public IActionResult Eliminar([FromBody]EliminarArchivo archivoEliminado)
        {
            RespuestaBD respuesta = new RespuestaBD();
            string archivo = _servicioDeArchivos.Eliminar(archivoEliminado);
            if (archivo != "")
            {
                System.IO.File.Delete(archivo);
                respuesta.Id = 1;
                respuesta.Mensaje = "El archivo fue eliminado del repositorio correctamente.";
                return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
            }
            else
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "No se envontró ningún archivo para eliminar.";
                return new BadRequestObjectResult(new { respuesta.Id, respuesta.Mensaje });
            }
        }

        [HttpGet]
        public IEnumerable<ArchivoPorFechaYUsuario> ListarArchivoPorFechaYUsuario([FromQuery]ConsultarArchivoPor archivoPor)
        {
            return _servicioDeArchivos.ListarArchivoPorFechaYUsuario(archivoPor);
        }
    }
}