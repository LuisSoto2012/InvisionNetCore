using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Evaluacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ino_InvisionCore.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EvaluacionController : ControllerBase
    {
        private IServicioDeEvaluaciones _servicio;
        //private static pdftron.PDFNetLoader pdfNetLoader = pdftron.PDFNetLoader.Instance();

        public EvaluacionController(IServicioDeEvaluaciones servicio)
        {
            _servicio = servicio;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPreguntaYRespuestas([FromBody]RegistrarPreguntaRespuestaDto solicitud)
        {
            var respuesta = await _servicio.RegistrarPreguntaYRespuestas(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
        
        [HttpGet]
        public async Task<IEnumerable<EvalPreguntaDto>> ListarPreguntas([FromQuery] string modulo)
        {
            return await _servicio.ListarPreguntas(modulo);
        }

        [HttpPost]
        public async Task<IActionResult> ActivarPregunta([FromBody] ActivarPreguntaDto solicitud)
        {
            var respuesta = await _servicio.ActivarPregunta(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpPost]
        public async Task<IActionResult> ModificarPreguntaYRespuestas([FromBody] ModificarPreguntaRespuestaDto solicitud)
        {
            var respuesta = await _servicio.ModificarPreguntaYRespuestas(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegistrarParticipante([FromBody] RegistrarParticipanteDto solicitud)
        {
            var respuesta = await _servicio.RegistrarParticipante(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<EvalParticipanteDto> ObtenerDatosParticipantePor([FromQuery] string numeroDocumento, 
            [FromQuery] string correoElectronico)
        {
            return await _servicio.ObtenerDatosParticipantePor(numeroDocumento, correoElectronico);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<EvalPreguntaActivaDto>> ListarPreguntasActivas([FromQuery] string modulo, [FromQuery]int idParticipante)
        {
            return await _servicio.ListarPreguntasActivas(modulo, idParticipante);
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AgregarRespuestaAPregunta([FromBody] AgregarRespuestaPreguntaDto solicitud)
        {
            var respuesta = await _servicio.AgregarRespuestaAPregunta(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<EvalResultadoDto>> ListarResultados([FromQuery]int idParticipante, [FromQuery] string modulo)
        {
            return await _servicio.ListarResultados(idParticipante, modulo);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ProcesarPdf()
        {
            //_servicio.ProcesarPDF();
            //return new OkObjectResult(new { Id = 1, Mensaje = "Exito" });
            string firstText = "LUIS SOTO FLORES";
            string secondText = "World";

            //PointF firstLocation = new PointF(292f, 190f);
            PointF firstLocation = new PointF(421f, 200f);

            string imageFilePath = "c1.jpg";
            Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (var sf = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                })
                using (Font arialFont = new Font("Garamond", 26, FontStyle.Bold | FontStyle.Italic))
                {
                    graphics.DrawString(firstText, arialFont, Brushes.Black, firstLocation, sf);
                   // graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
                }
            }
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream("c1v2.jpg", FileMode.Create, FileAccess.ReadWrite))
                {
                    bitmap.Save(memory, ImageFormat.Jpeg);//save the image file
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            using (MemoryStream stream = new MemoryStream())
            {
                
                //stream.WriteTo(context.Response.OutputStream);
            }
            
            return new OkObjectResult(new { Id = 1, Mensaje = "Exito" });
        }

        [HttpGet]
        public async Task<IEnumerable<EvalParticipanteNumPregDto>> ListarParticipantesPorNumeroPreguntas([FromQuery]string modulo, [FromQuery]DateTime fecha, [FromQuery]int numPreg)
        {
            return await _servicio.ListarParticipantesPorNumeroPreguntas(modulo, fecha, numPreg);
        }

        [HttpPost]
        public async Task<IActionResult> EnviarCertificados([FromBody]EnviarCertificadosDto solicitud)
        {
            var respuesta = await _servicio.EnviarCertificados(solicitud);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }

        [HttpGet]
        public async Task<IEnumerable<EvalPartCertDto>> ListarParticipantesConCertificado([FromQuery]string modulo)
        {
            return await _servicio.ListarParticipantesConCertificado(modulo);
        }

        [HttpPost]
        public async Task<IActionResult> ReenviarCertificados([FromBody] ReenviarCertificadoDto solicitud)
        {
            var respuesta = await _servicio.ReenviarCertificados(solicitud.participantes);
            return new OkObjectResult(new { respuesta.Id, respuesta.Mensaje });
        }
        
        [AllowAnonymous]
        public async Task<IActionResult> EnviarLista()
        {
            await _servicio.EnviarLista();
            return new OkObjectResult(new { Id = 1, Mensaje = "Exito" });
        }
    }
}