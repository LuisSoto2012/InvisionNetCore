// RepositorioDeEvaluaciones.cs22:2922:29

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Evaluacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Evaluacion;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Evaluacion;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Microsoft.EntityFrameworkCore;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeEvaluaciones : IRepositorioDeEvaluaciones
    {
        private readonly InoContext _inoContext;

        public RepositorioDeEvaluaciones(InoContext inoContext)
        {
            _inoContext = inoContext;
        }
        
        public async Task<RespuestaBD> RegistrarPreguntaYRespuestas(RegistrarPreguntaRespuestaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                EvaluacionPregunta evaluacionPregunta = Mapper.Map<EvaluacionPregunta>(solicitud);
                _inoContext.EvaluacionPreguntas.Add(evaluacionPregunta);
                await _inoContext.SaveChangesAsync();
                respuesta.Id = 1;
                respuesta.Mensaje = "Pregunta registrada satisfactoriamente!";
            }
            catch (Exception e)
            {
                respuesta.Id = 0;;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        public async  Task<IEnumerable<EvalPreguntaDto>> ListarPreguntas(string modulo)
        {
            IList<EvalPreguntaDto> preguntas = new List<EvalPreguntaDto>();

            var dbPreguntas = await _inoContext.EvaluacionPreguntas
                                    .Where(x => x.Modulo == modulo)
                                    .ToListAsync();

            foreach (var p in dbPreguntas)
            {
                EvalPreguntaDto dto = new EvalPreguntaDto();
                dto.Id = p.Id;
                dto.Modulo = p.Modulo;
                dto.Pregunta = p.Pregunta;
                dto.Activo = p.Activo ? 1 : 0;
                dto.FechaCreacion = p.FechaCreacion.ToString("dd/MM/yyyy");
                string[] respuestas = p.Respuestas.Split("|");
                if (respuestas.Length > 0)
                {
                    dto.RptaA = respuestas.Length > 0 ? "1. " + respuestas[0].Split("^")[1] : "";
                    dto.RptaB = respuestas.Length > 1 ? "2. " + respuestas[1].Split("^")[1] : "";
                    dto.RptaC = respuestas.Length > 2 ? "3. " + respuestas[2].Split("^")[1] : "";
                    dto.RptaD = respuestas.Length > 3 ? "4. " + respuestas[3].Split("^")[1] : "";
                    dto.RptaE = respuestas.Length > 4 ? "5. " + respuestas[4].Split("^")[1] : "";
                    string respCorrecta = respuestas.ToList().Where(x => x.Contains("RESP_CORRECTA")).First();
                    string[] respSplit = respCorrecta.Split("^");
                    dto.RptaCorrecta = respSplit[0] + ". " + respSplit[1];
                    preguntas.Add(dto);
                }
            }
            return preguntas;
        }

        public async Task<RespuestaBD> ActivarPregunta(ActivarPreguntaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                //1. Obtener Pregunta de la DB
                var eval = await _inoContext.EvaluacionPreguntas.FirstOrDefaultAsync(x => x.Id == solicitud.Id);

                if (eval == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado la pregunta en la Base de Datos.";
                }
                else
                {
                    //2. Actualizar en DB
                    eval.Activo = solicitud.Activar;
                    eval.IdUsuarioModificacion = solicitud.IdUsuario;
                    eval.FechaModificacion = DateTime.Today;
                    await _inoContext.SaveChangesAsync();
                    respuesta.Id = 1;
                    respuesta.Mensaje = $"Se ha {(solicitud.Activar ? "activado" : "desactivado")} la pregunta correctamente!";
                }
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> ModificarPreguntaYRespuestas(ModificarPreguntaRespuestaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                //1. Obtener Pregunta de la DB
                EvaluacionPregunta eval = await _inoContext.EvaluacionPreguntas.FirstOrDefaultAsync(x => x.Id == solicitud.Id);

                if (eval == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado la pregunta en la Base de Datos.";
                }
                else
                {
                    //2. Actualizar
                    Mapper.Map<ModificarPreguntaRespuestaDto, EvaluacionPregunta>(solicitud, eval);
                    await _inoContext.SaveChangesAsync();
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se ha actualizado la pregunta correctamente!";
                }
                
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        public async Task EnviarLista()
        {
            string[] arrMail = new string[3] { "noreply.inoinvision@gmail.com", "noreply2.inoinvision@gmail.com", "noreply3.inoinvision@gmail.com" };
            string mailPassword = "P@sw0rd00!";

            int intento = 0;

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(arrMail[intento], "P@sw0rd00!");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.DeliveryFormat = SmtpDeliveryFormat.International;
            client.Port = 587;
            client.Timeout = 20000;

            var participantesDb = await _inoContext.EvaluacionParticipantes.Where(x => x.Id > 1090).ToListAsync();

            foreach (var p in participantesDb)
            {
                try
                {

                    using (StreamReader SourceReader = System.IO.File.OpenText("msg_reg_asistentes.html"))
                    {
                        MailMessage mailMessage = new MailMessage();

                        string body = (SourceReader.ReadToEnd()).Replace("asistNombreApellido", $"{p.Nombres} {p.ApellidoPaterno}");
                        body = body.Replace("asistNumeroDocumento", p.NumeroDocumento);
                        body = body.Replace("asistCorreoElectronico", p.CorreoElectronico);

                        AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                        byte[] reader = File.ReadAllBytes("bannerForo.jpg");
                        MemoryStream image1 = new MemoryStream(reader);

                        LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                        headerImage.ContentId = "banCongreso";
                        headerImage.ContentType = new ContentType("image/jpg");
                        av.LinkedResources.Add(headerImage);

                        byte[] reader2 = File.ReadAllBytes("medico.jpg");
                        MemoryStream image2 = new MemoryStream(reader2);

                        LinkedResource headerImage2 = new LinkedResource(image2, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                        headerImage2.ContentId = "medicoCongreso";
                        headerImage2.ContentType = new ContentType("image/jpg");
                        av.LinkedResources.Add(headerImage2);

                        mailMessage.AlternateViews.Add(av);
                        mailMessage.From = new MailAddress(arrMail[intento]);
                        mailMessage.To.Add(p.CorreoElectronico);
                        mailMessage.Subject = "INO CONGRESO - REGISTRO DE ASISTENTE";
                        mailMessage.IsBodyHtml = true;
                        ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                        AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                        mailMessage.AlternateViews.Add(alternate);

                        client.Send(mailMessage);
                    }

                }
                catch (Exception ex)
                {

                    //throw ex;
                    intento++;
                    client = new SmtpClient("smtp.gmail.com");
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(arrMail[intento], "P@sw0rd00!");
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.DeliveryFormat = SmtpDeliveryFormat.International;
                    client.Port = 587;
                    client.Timeout = 20000;
                }
            }
        }

        public async Task<RespuestaBD> RegistrarParticipante(RegistrarParticipanteDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("noreply.inoinvision@gmail.com", "P@sw0rd00!");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.DeliveryFormat = SmtpDeliveryFormat.International;
            client.Port = 587;
            client.Timeout = 20000;
            try
            {
                //Validar si existe participante

                var participanteDb = await _inoContext.EvaluacionParticipantes.FirstOrDefaultAsync(x => x.NumeroDocumento == solicitud.NumeroDocumento);

                if (participanteDb != null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = $"Ya existe un participante registrado con el documento {participanteDb.NumeroDocumento}";
                    return respuesta;
                }
                
                using (var httpClient = new HttpClient())
                {
                    EvaluacionParticipante evaluacionParticipante = Mapper.Map<EvaluacionParticipante>(solicitud);
                    _inoContext.EvaluacionParticipantes.Add(evaluacionParticipante);
                    await _inoContext.SaveChangesAsync();
                
                    //Correo
                    
                    using (StreamReader SourceReader = System.IO.File.OpenText("msg_reg_asistentes.html"))
                        {
                            MailMessage mailMessage = new MailMessage();

                            string body = (SourceReader.ReadToEnd()).Replace("asistNombreApellido", $"{solicitud.Nombres} {solicitud.ApellidoPaterno}");
                            body = body.Replace("asistNumeroDocumento", solicitud.NumeroDocumento);
                            body = body.Replace("asistCorreoElectronico", solicitud.CorreoElectronico);

                            AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                            byte[] reader = File.ReadAllBytes("bannerForo.jpg");
                            MemoryStream image1 = new MemoryStream(reader);

                            LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                            headerImage.ContentId = "banCongreso";
                            headerImage.ContentType = new ContentType("image/jpg");
                            av.LinkedResources.Add(headerImage);

                            byte[] reader2 = File.ReadAllBytes("medico.jpg");
                            MemoryStream image2 = new MemoryStream(reader2);

                            LinkedResource headerImage2 = new LinkedResource(image2, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                            headerImage2.ContentId = "medicoCongreso";
                            headerImage2.ContentType = new ContentType("image/jpg");
                            av.LinkedResources.Add(headerImage2);

                            mailMessage.AlternateViews.Add(av);
                            mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                            mailMessage.To.Add(solicitud.CorreoElectronico);
                            mailMessage.Subject = "INO CONGRESO - REGISTRO DE ASISTENTE";
                            mailMessage.IsBodyHtml = true;
                            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                            AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                            mailMessage.AlternateViews.Add(alternate);

                            client.Send(mailMessage);
                        }
                }
                
                respuesta.Id = 1;
                respuesta.Mensaje = "Participante registrado correctamente!";
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        public async Task<EvalParticipanteDto> ObtenerDatosParticipantePor(string numeroDocumento, string correoElectronico)
        {
            var participante = await _inoContext
                .EvaluacionParticipantes
                .FirstOrDefaultAsync(x => x.NumeroDocumento == numeroDocumento
                                          && x.CorreoElectronico == correoElectronico
                );

            return participante == null ? null : Mapper.Map<EvalParticipanteDto>(participante);
        }

        public async Task<IEnumerable<EvalPreguntaActivaDto>> ListarPreguntasActivas(string modulo, int idParticipante)
        {
            IList<EvalPreguntaActivaDto> preguntas = new List<EvalPreguntaActivaDto>();

            //1. Obtener preguntas respondidas por participante
            var listaPPDb = await _inoContext.EvaluacionResultados.Where(x => x.Modulo == modulo && x.IdParticipante == idParticipante)
                                        .ToListAsync();

            //2. Obtener por DB
            var listaDb = await _inoContext.EvaluacionPreguntas.Where(x => x.Activo && x.Modulo == modulo &&
                                    !listaPPDb.Select(p => p.IdPregunta).Contains(x.Id))
                .ToListAsync();

            foreach (var e in listaDb)
            {
                EvalPreguntaActivaDto dto = new EvalPreguntaActivaDto();
                dto.Id = e.Id;
                dto.Pregunta = e.Pregunta;
                string[] respuestasDb = e.Respuestas.Split("|");
                dto.Respuestas = new string[respuestasDb.Length];
                int pos = 0;
                foreach (var resp in respuestasDb)
                {
                    string[] respStr = resp.Split("^");
                    dto.Respuestas[pos++] = respStr[0] + ". " + respStr[1];
                    if (respStr[2] == "RESP_CORRECTA")
                        dto.RespuestaCorrecta = respStr[0] + ". " + respStr[1];
                }
                
                preguntas.Add(dto);
            }

            return preguntas;
        }

        public async Task<RespuestaBD> AgregarRespuestaAPregunta(AgregarRespuestaPreguntaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                //1. Obtener Pregunta de la DB
                var preguntaDb =
                    await _inoContext.EvaluacionPreguntas.FirstOrDefaultAsync(x => x.Id == solicitud.IdPregunta);

                if (preguntaDb == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado la pregunta en la base de datos";
                }
                else
                {
                    EvaluacionResultado evaluacion = new EvaluacionResultado();
                    evaluacion.IdPregunta = solicitud.IdPregunta;
                    evaluacion.Modulo = preguntaDb.Modulo;
                    evaluacion.IdParticipante = solicitud.IdParticipante;
                    evaluacion.Pregunta = preguntaDb.Pregunta;
                    evaluacion.Respuesta = solicitud.Respuesta;
                    evaluacion.IdRespuesta = solicitud.Respuesta[0].ToString();
                    //Obtener respuesta correcta
                    string respCorrectaStr = preguntaDb.Respuestas.Split("|").Where(x => x.Contains("RESP_CORRECTA")).First();
                    string[] respCorrecta = respCorrectaStr.Split("^");
                    evaluacion.RespuestaCorrecta = respCorrecta[0] + ". " + respCorrecta[1];
                    evaluacion.IdRespuestaCorrecta = respCorrecta[0];
                    evaluacion.FechaCreacion = DateTime.Now;
                    _inoContext.EvaluacionResultados.Add(evaluacion);
                    await _inoContext.SaveChangesAsync();
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Respuesta agregada correctamente!";
                }
                
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        public async Task<IEnumerable<EvalResultadoDto>> ListarResultados(int idParticipante, string modulo)
        {
            IList<EvalResultadoDto> resultados = new List<EvalResultadoDto>();
            
            //1. Obtener de DB
            var resultadosDb = await _inoContext.EvaluacionResultados.Where(x => x.IdParticipante == idParticipante
                && x.Modulo == modulo).OrderByDescending(x => x.FechaCreacion).ToListAsync();

            var pos = 0;
            foreach (var res in resultadosDb)
            {
                EvalResultadoDto dto = new EvalResultadoDto();
                dto.RowNumber = ++pos;
                dto.Pregunta = res.Pregunta;
                dto.Fecha = res.FechaCreacion;
                dto.FechaStr = res.FechaCreacion.ToString("dd/MM/yyyy HH:mm");
                dto.RptaIngresada = res.IdRespuesta;
                dto.RptaCorrecta = res.IdRespuestaCorrecta;
                resultados.Add(dto);
            }
            
            return resultados;
        }

        public async Task<IEnumerable<EvalParticipanteNumPregDto>> ListarParticipantesPorNumeroPreguntas(string modulo, DateTime fecha, int numPreg)
        {
            var listaDb = await _inoContext.Query<EvalParticipanteNumPregView>().FromSql("dbo.Invision_ListarParticipantesPorAciertos @Modulo, @Fecha, @NumPreg",
                                new SqlParameter("Modulo", modulo),
                                new SqlParameter("Fecha", fecha.Date),
                                new SqlParameter("NumPreg", numPreg))
                    .ToListAsync();

             return listaDb.Select(x => Mapper.Map<EvalParticipanteNumPregDto>(x)).ToList();
        }

        public async Task<RespuestaBD> EnviarCertificados(EnviarCertificadosDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("noreply.inoinvision@gmail.com", "P@sw0rd00!");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.DeliveryFormat = SmtpDeliveryFormat.International;
            client.Port = 587;
            client.Timeout = 20000;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    foreach (var p in solicitud.Participantes)
                    {
                        MailMessage mailMessage = new MailMessage();


                        mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                        mailMessage.To.Add(p.CorreoElectronico);
                        mailMessage.Subject = "INO CONGRESO - CERTIFICADO DE ASISTENCIA";
                        mailMessage.Body = $"Se adjunta CERTIFICADO DE ASISTENCIA de {solicitud.Modulo} del d�a {solicitud.Fecha.ToString("dd/MM/yyyy")}";

                        //Creacion Certificado
                        string pathTempCert = "";
                        string pathCert = "";
                        bool Cert1 = false;
                        bool Cert2 = false;
                        bool Cert3 = false;
                        bool Cert4 = false;
                        bool Cert5 = false;

                        if (solicitud.Fecha.ToString("yyyy-MM-dd") == "2021-09-20")
                        {
                            pathTempCert = "cert1.jpg";
                            pathCert = $"certificados\\20.09\\cert1_{p.NumeroDocumento}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.jpg";
                            Cert1 = true;
                        }
                        else if (solicitud.Fecha.ToString("yyyy-MM-dd") == "2021-09-21")
                        {
                            pathTempCert = "cert2.jpg";
                            pathCert = $"certificados\\21.09\\cert2_{p.NumeroDocumento}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.jpg";
                            Cert2 = true;
                        }
                        else if (solicitud.Fecha.ToString("yyyy-MM-dd") == "2021-09-22")
                        {
                            pathTempCert = "cert3.jpg";
                            pathCert = $"certificados\\22.09\\cert3_{p.NumeroDocumento}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.jpg";
                            Cert3 = true;
                        }
                        else if (solicitud.Fecha.ToString("yyyy-MM-dd") == "2021-09-23")
                        {
                            pathTempCert = "cert4.jpg";
                            pathCert = $"certificados\\23.09\\cert4_{p.NumeroDocumento}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.jpg";
                            Cert4 = true;
                        }
                        else if (solicitud.Fecha.ToString("yyyy-MM-dd") == "2021-09-24")
                        {
                            pathTempCert = "cert5.jpg";
                            pathCert = $"certificados\\24.09\\cert5_{p.NumeroDocumento}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.jpg";
                            Cert5 = true;
                        }

                        //PointF firstLocation = new PointF(292f, 190f);
                        PointF firstLocation = new PointF(421f, 200f);

                        string imageFilePath = pathTempCert;
                        Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file

                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            using (var sf = new StringFormat()
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center,
                            })
                            using (Font textFont = new Font("Arial Black", 27, FontStyle.Bold | FontStyle.Italic))
                            {
                                graphics.DrawString(p.Participante, textFont, Brushes.Black, firstLocation, sf);
                                // graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
                            }
                        }
                        using (MemoryStream memory = new MemoryStream())
                        {
                            using (FileStream fs = new FileStream(pathCert, FileMode.Create, FileAccess.ReadWrite))
                            {
                                bitmap.Save(memory, ImageFormat.Jpeg);//save the image file
                                byte[] bytes = memory.ToArray();
                                fs.Write(bytes, 0, bytes.Length);
                            }
                        }

                        mailMessage.Attachments.Add(new Attachment(pathCert));

                        await client.SendMailAsync(mailMessage);

                        //Insert Tabla
                        EvaluacionParticipanteCertificado eval = new EvaluacionParticipanteCertificado
                        {
                            IdParticipante = p.IdParticipante,
                            Participante = p.Participante,
                            NumeroDocumento = p.NumeroDocumento,
                            CorreoElectronico = p.CorreoElectronico,
                            Modulo = solicitud.Modulo,
                            FechaCertificado = solicitud.Fecha.Date,
                            FechaEnvio = DateTime.Now,
                            Certificado1 = Cert1,
                            Certificado2 = Cert2,
                            Certificado3 = Cert3,
                            Certificado4 = Cert4,
                            Certificado5 = Cert5
                        };

                        _inoContext.EvaluacionParticipantseCertificados.Add(eval);
                        await _inoContext.SaveChangesAsync();
                    }
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Certificados enviados correctamente!";
                }
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        public async Task<IEnumerable<EvalPartCertDto>> ListarParticipantesConCertificado(string modulo)
        {
            var listaDb = await _inoContext.Query<EvalPartCertView>().FromSql("dbo.Invision_ListarParticipantesConCertificado @Modulo",
                    new SqlParameter("Modulo", modulo))
                .Select(x => Mapper.Map<EvalPartCertDto>(x))
                .ToListAsync();

            return listaDb;
        }

        public async Task<RespuestaBD> ReenviarCertificados(IEnumerable<EvalPartCertDto> participantes)
        {
            RespuestaBD respuesta = new RespuestaBD();
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("noreply.inoinvision@gmail.com", "P@sw0rd00!");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.DeliveryFormat = SmtpDeliveryFormat.International;
            client.Port = 587;
            client.Timeout = 20000;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    foreach (var p in participantes)
                    {
                        IList<EvalCertFlagDto> listaCert = p.Certificados.Where(x => x.Enviado).ToList();
                        foreach (var cert in listaCert)
                        {
                            MailMessage mailMessage = new MailMessage();


                        mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                        mailMessage.To.Add(p.CorreoElectronico);
                        mailMessage.Subject = "INO CONGRESO - CERTIFICADO DE ASISTENCIA";
                        mailMessage.Body = $"Se adjunta CERTIFICADO DE ASISTENCIA de {p.Modulo} del d�a {cert.Fecha.ToString("dd/MM/yyyy")}";

                        //Creacion Certificado
                        string pathTempCert = "";
                        string pathCert = "";
                        bool Cert1 = false;
                        bool Cert2 = false;
                        bool Cert3 = false;
                        bool Cert4 = false;
                        bool Cert5 = false;

                        if (cert.Fecha.ToString("yyyy-MM-dd") == "2021-09-20")
                        {
                            pathTempCert = "cert1.jpg";
                            pathCert = $"certificados\\20.09\\cert1_{p.NumeroDocumento}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.jpg";
                            Cert1 = true;
                        }
                        else if (cert.Fecha.ToString("yyyy-MM-dd") == "2021-09-21")
                        {
                            pathTempCert = "cert2.jpg";
                            pathCert = $"certificados\\21.09\\cert2_{p.NumeroDocumento}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.jpg";
                            Cert2 = true;
                        }
                        else if (cert.Fecha.ToString("yyyy-MM-dd") == "2021-09-22")
                        {
                            pathTempCert = "cert3.jpg";
                            pathCert = $"certificados\\22.09\\cert3_{p.NumeroDocumento}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.jpg";
                            Cert3 = true;
                        }
                        else if (cert.Fecha.ToString("yyyy-MM-dd") == "2021-09-23")
                        {
                            pathTempCert = "cert4.jpg";
                            pathCert = $"certificados\\23.09\\cert4_{p.NumeroDocumento}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.jpg";
                            Cert4 = true;
                        }
                        else if (cert.Fecha.ToString("yyyy-MM-dd") == "2021-09-24")
                        {
                            pathTempCert = "cert5.jpg";
                            pathCert = $"certificados\\24.09\\cert5_{p.NumeroDocumento}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.jpg";
                            Cert5 = true;
                        }

                        //PointF firstLocation = new PointF(292f, 190f);
                        PointF firstLocation = new PointF(421f, 200f);

                        string imageFilePath = pathTempCert;
                        Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file

                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            using (var sf = new StringFormat()
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center,
                            })
                            using (Font textFont = new Font("Arial Black", 27, FontStyle.Bold | FontStyle.Italic))
                            {
                                graphics.DrawString($"{p.Nombres} {p.ApellidoPaterno} {p.ApellidoMaterno}", textFont, Brushes.Black, firstLocation, sf);
                                // graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
                            }
                        }
                        using (MemoryStream memory = new MemoryStream())
                        {
                            using (FileStream fs = new FileStream(pathCert, FileMode.Create, FileAccess.ReadWrite))
                            {
                                bitmap.Save(memory, ImageFormat.Jpeg);//save the image file
                                byte[] bytes = memory.ToArray();
                                fs.Write(bytes, 0, bytes.Length);
                            }
                        }

                        mailMessage.Attachments.Add(new Attachment(pathCert));

                        await client.SendMailAsync(mailMessage);

                        //Insert Tabla
                        EvaluacionParticipanteCertificado eval = new EvaluacionParticipanteCertificado
                        {
                            IdParticipante = p.Id,
                            Participante = $"{p.Nombres} {p.ApellidoPaterno} {p.ApellidoMaterno}",
                            NumeroDocumento = p.NumeroDocumento,
                            CorreoElectronico = p.CorreoElectronico,
                            Modulo = p.Modulo,
                            FechaCertificado = cert.Fecha.Date,
                            FechaEnvio = DateTime.Now,
                            Certificado1 = Cert1,
                            Certificado2 = Cert2,
                            Certificado3 = Cert3,
                            Certificado4 = Cert4,
                            Certificado5 = Cert5
                        };

                        _inoContext.EvaluacionParticipantseCertificados.Add(eval);
                        await _inoContext.SaveChangesAsync();
                        }
                    }

                    respuesta.Id = 1;
                    respuesta.Mensaje = "Certificados enviados correctamente!";
                }
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }
    }
}