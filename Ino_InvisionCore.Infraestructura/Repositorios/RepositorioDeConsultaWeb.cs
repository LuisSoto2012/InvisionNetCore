using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SolicitudWeb.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.ConsultaWeb;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.ConsultaWeb;
using Ino_InvisionCore.Dominio.Entidades.ConsultaWeb_ConsultaRapida;
using Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

//using ReniecWS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
//using static ReniecWS.ServiceDNISoapClient;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeConsultaWeb : IRepositorioDeConsultaWeb
    {
        private readonly InoContext Context;
        private readonly GalenPlusContext GalenContext;

        public RepositorioDeConsultaWeb(InoContext context, GalenPlusContext galenContext)
        {
            Context = context;
            GalenContext = galenContext;
        }

        public RespuestaBD CrearSolicitudCita(RegistroSolicitudCita solicitud)
        {
            using (var httpClient = new HttpClient())
            {

                RespuestaBD respuesta = new RespuestaBD();

                try
                {
                    //1. Validacion Reniec

                    SolicitudCita solicitudCita = null;

                   

                    if (solicitud.IdTipoDocumento == 1)
                    {

                        string[] responseStr = null;

                        var server = "http://invision.ino.gob.pe:8085/";
                        var url = server + "api/ConsultaWeb/";
                        var method = "ObtenerDatosPorReniec?";
                        var parameters = "dni=" + solicitud.NumeroDocumento;
                        var uri = url + method + parameters;
                        using (var response =  httpClient.GetAsync(uri).Result)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            responseStr = JsonConvert.DeserializeObject<string[]>(apiResponse);
                        }

                        string apPaterno = responseStr[0];
                        string apMaterno = responseStr[1];

                        string nombre1 = responseStr[2];
                        string nombre2 = responseStr[3];

                        if (apPaterno == solicitud.ApellidoPaterno && apMaterno == solicitud.ApellidoMaterno)
                        {
                            if (nombre2 != null && nombre2.Length > 0)
                            {
                                if (solicitud.PrimerNombre == nombre1 && solicitud.SegundoNombre == nombre2)
                                {
                                    solicitudCita = Mapper.Map<SolicitudCita>(solicitud);

                                    Context.SolicitudesCita.Add(solicitudCita);

                                    Context.SaveChanges();

                                    respuesta.Id = 1;
                                    respuesta.Mensaje = "Se ha registrado la solicitud correctamente";
                                }
                                else
                                {
                                    respuesta.Id = 0;
                                    respuesta.Mensaje = "Los datos ingresados no coinciden con RENIEC";
                                }
                            }
                            else
                            {
                                if (solicitud.PrimerNombre == nombre1)
                                {
                                    solicitudCita = Mapper.Map<SolicitudCita>(solicitud);

                                    Context.SolicitudesCita.Add(solicitudCita);

                                    Context.SaveChanges();

                                    respuesta.Id = 1;
                                    respuesta.Mensaje = "Se ha registrado la solicitud correctamente";
                                }
                                else
                                {
                                    respuesta.Id = 0;
                                    respuesta.Mensaje = "Los datos ingresados no coinciden con RENIEC";
                                }
                            }
                        }
                        else
                        {
                            respuesta.Id = 0;
                            respuesta.Mensaje = "Los datos ingresados no coinciden con RENIEC";
                        }


                    }
                    else
                    {
                        solicitudCita = Mapper.Map<SolicitudCita>(solicitud);

                        Context.SolicitudesCita.Add(solicitudCita);

                        Context.SaveChanges();

                        respuesta.Id = 1;
                        respuesta.Mensaje = "Se ha registrado la solicitud correctamente";
                    }


                }
                catch (Exception ex)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Ha ocurrido un error";
                }

                return respuesta;

                
            }


            
        }

        public async Task<IEnumerable<SolicitudCitaDto>> ListarSolicitudCita(int idEstado, DateTime fechaSolicitud)
        {
            var list = idEstado == 1 ? await Context.SolicitudesCita.Where(x => (x.IdEstado == 1 || x.IdEstado == 3) && x.FechaCita.HasValue && x.FechaCita.Value.ToString("yyyy-MM-dd") == fechaSolicitud.ToString("yyyy-MM-dd"))
                                                .Select(x => Mapper.Map<SolicitudCitaDto>(x))
                                                .ToListAsync() :  await Context.SolicitudesCita.Where(x => x.IdEstado == idEstado && x.FechaCreacion.ToString("yyyy-MM-dd") == fechaSolicitud.ToString("yyyy-MM-dd"))
                                                .Select(x => Mapper.Map<SolicitudCitaDto>(x))
                                                .ToListAsync();

            IList<SolicitudCitaDto> result = new List<SolicitudCitaDto>();

            foreach (var e in list)
            {
                SolicitudCitaDto dto = e;
                if (e.IdEstado == 3)
                {
                    var listaDx = await ListarSolicitudDiagnosticoPor(e.IdSolicitudCita);
                    dto.ListaDiagnostico = listaDx.Select(x => new DiagnosticoDto
                    {
                        IdDiagnostico = x.IdDiagnostico,
                        Descripcion = x.Descripcion,
                        CIE10 = x.CodigoCIE10,
                        TipoDX = x.TipoDX,
                        Ojo = x.Ojo
                    }).ToList();
                    var listaMed = await ListarSolicitudMedicamentoPor(e.IdSolicitudCita);
                    dto.ListaMedicamento = listaMed.Select(x => new MedicamentoDto
                    {
                        IdMedicamento = x.IdMedicamento,
                        Nombre = x.Nombre,
                        ForFarm = x.ForFarm,
                        Cantidad = x.Cantidad,
                        Ojo = x.Ojo,
                        Indicacion = x.Indicacion
                    }).ToList();
                }
                e.ListaProcedimientos.Add(new ProcedimientoCitaDto { CodProc = e.CodProc, DesProc = e.DesProc });
                result.Add(dto);
            }

            return result;
        }

        private async Task<IEnumerable<SolicitudCitaDiagnostico>> ListarSolicitudDiagnosticoPor(int idSolicitudCita)
        {
            return await Context.SolicitudesCitaDiagnosticos.Where(x => x.IdSolicitudCita == idSolicitudCita).ToListAsync();
        }

        private async Task<IEnumerable<SolicitudCitaMedicamento>> ListarSolicitudMedicamentoPor(int idSolicitudCita)
        {
            return await Context.SolicitudesCitaMedicamentos.Where(x => x.IdSolicitudCita == idSolicitudCita).ToListAsync();
        }

        public async Task<RespuestaBD> AceptarRechazarSolicitudCita(AceptarRechazarSolicitudCita operacionCita)
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

            SolicitudCita solicitud = await Context.SolicitudesCita.FirstOrDefaultAsync(x => x.IdSolicitudCita == operacionCita.IdSolicitudCita);

            if (solicitud == null)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "La solicitud no existe";
            }
            else
            {
                if (operacionCita.IdOperacion == 1)
                {
                    

                    using (StreamReader SourceReader = System.IO.File.OpenText("respuestaSI.html"))
                    {
                        //Validar que el paciente no este asignado ya ese dia
                        SolicitudCita solAcp = await Context.SolicitudesCita.FirstOrDefaultAsync(x => x.NumeroDocumento == operacionCita.NumeroDocumento &&
                                                                                                        x.IdMedico == operacionCita.Medicos.IdMedico &&
                                                                                                        x.FechaCita.HasValue && x.FechaCita.Value.Date == operacionCita.FechaCita.Date);

                        if (solAcp != null)
                        {
                            respuesta.Id = 0;
                            respuesta.Mensaje = $"El paciente {operacionCita.Paciente} ya cuenta con una cita para la fecha seleccionada.";

                            return respuesta;
                        }

                        //Validar Hora, Medico y Fecha

                        SolicitudCita solAc = await Context.SolicitudesCita.FirstOrDefaultAsync(x => x.IdMedico == operacionCita.Medicos.IdMedico &&
                                                                                            x.HoraCita == operacionCita.HoraCita &&
                                                                                            x.IdEstado == 1 &&
                                                                                            x.FechaCita.HasValue && x.FechaCita.Value.ToString("yyyy-MM-dd") == operacionCita.FechaCita.ToString("yyyy-MM-dd"));
                        if (solAc != null)
                        {
                            respuesta.Id = 0;
                            respuesta.Mensaje = "Esta hora ya esta programada para el paciente: " + solAc.PrimerNombre + " " + solAc.ApellidoPaterno + " (DNI : " + solAc.NumeroDocumento + ")";

                            return respuesta;
                        }


                        solicitud.IdEstado = 1;
                        solicitud.IdUsuarioAcepta = operacionCita.IdUsuario;
                        solicitud.FechaAcepta = DateTime.Now;
                        solicitud.IdMedico = operacionCita.Medicos.IdMedico;
                        solicitud.IdResidente = operacionCita.Residentes.IdMedico;
                        solicitud.FechaCita = operacionCita.FechaCita;
                        solicitud.HoraCita = operacionCita.HoraCita;
                        solicitud.UrlCita = operacionCita.UrlCita;
                        respuesta.Id = 1;
                        respuesta.Mensaje = "La solicitud ha sido aceptada";


                        //MailMessage mailMessage = new MailMessage();

                        //mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                        //mailMessage.To.Add(operacionCita.CorreoElectronico);
                        //mailMessage.Subject = "INO CONSULTAS WEB - Respuesta Solicitud Cita";
                        //mailMessage.Body = (SourceReader.ReadToEnd()).Replace("(Nombre1 + Apellidopaterno)", solicitud.PrimerNombre + " "+ solicitud.ApellidoPaterno).Replace("FechaCita", operacionCita.FechaCita.ToString("yyyy-MM-dd")).Replace("HoraCita", operacionCita.HoraCita).Replace("MedicoCita", operacionCita.Medicos.Descripcion);
                        //mailMessage.IsBodyHtml = true;
                        //client.Send(mailMessage);

                        MailMessage mailMessage = new MailMessage();

                        string body = (SourceReader.ReadToEnd()).Replace("(Nombre1 + Apellidopaterno)", solicitud.PrimerNombre + " " + solicitud.ApellidoPaterno);
                        body = body.Replace("FechaCita", operacionCita.FechaCita.ToString("dd/MM/yyyy"));
                        body = body.Replace("HoraCita", operacionCita.HoraCita);
                        body = body.Replace("UrlCita", operacionCita.UrlCita);
                        AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                        byte[] reader = File.ReadAllBytes("logo_ino.jpg");
                        MemoryStream image1 = new MemoryStream(reader);

                        LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                        headerImage.ContentId = "logoIno";
                        headerImage.ContentType = new ContentType("image/jpg");
                        av.LinkedResources.Add(headerImage);

                        byte[] reader2 = File.ReadAllBytes("logo_invision.jpg");
                        MemoryStream image2 = new MemoryStream(reader2);

                        LinkedResource headerImage2 = new LinkedResource(image2, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                        headerImage2.ContentId = "logoInvision";
                        headerImage2.ContentType = new ContentType("image/jpg");
                        av.LinkedResources.Add(headerImage2);

                        byte[] reader3 = File.ReadAllBytes("slogan_telesalud.jpg");
                        MemoryStream image3 = new MemoryStream(reader3);

                        LinkedResource headerImage3 = new LinkedResource(image3, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                        headerImage3.ContentId = "sloganTelesalud";
                        headerImage3.ContentType = new ContentType("image/jpg");
                        av.LinkedResources.Add(headerImage3);


                        mailMessage.AlternateViews.Add(av);
                        mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                        mailMessage.To.Add(operacionCita.CorreoElectronico);
                        mailMessage.Subject = "INO CONSULTAS WEB - Respuesta Solicitud Cita";
                        mailMessage.IsBodyHtml = true;
                        ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                        AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                        mailMessage.AlternateViews.Add(alternate);
                        
                        client.Send(mailMessage);
                    }
                    
                }
                else
                {
                    using (StreamReader SourceReader = System.IO.File.OpenText("respuestaNO.html"))
                    {
                        solicitud.IdEstado = 2;
                        solicitud.IdUsuarioRechaza = operacionCita.IdUsuario;
                        solicitud.FechaRechaza = DateTime.Now;
                        solicitud.MotivoRechazo = operacionCita.MotivoRechazo;
                        respuesta.Id = 2;
                        respuesta.Mensaje = "La solicitud ha sido rechazada";

                        MailMessage mailMessage = new MailMessage();

                        string body = (SourceReader.ReadToEnd()).Replace("(Nombre1 + Apellidopaterno)", solicitud.PrimerNombre + " " + solicitud.ApellidoPaterno);
                        body = body.Replace("MotivoRechazo", operacionCita.MotivoRechazo);
                        AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                        byte[] reader = File.ReadAllBytes("logo_ino.jpg");
                        MemoryStream image1 = new MemoryStream(reader);

                        LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                        headerImage.ContentId = "logoIno";
                        headerImage.ContentType = new ContentType("image/jpg");
                        av.LinkedResources.Add(headerImage);

                        byte[] reader2 = File.ReadAllBytes("logo_invision.jpg");
                        MemoryStream image2 = new MemoryStream(reader2);

                        LinkedResource headerImage2 = new LinkedResource(image2, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                        headerImage2.ContentId = "logoInvision";
                        headerImage2.ContentType = new ContentType("image/jpg");
                        av.LinkedResources.Add(headerImage2);

                        byte[] reader3 = File.ReadAllBytes("slogan_telesalud.jpg");
                        MemoryStream image3 = new MemoryStream(reader3);

                        LinkedResource headerImage3 = new LinkedResource(image3, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                        headerImage3.ContentId = "sloganTelesalud";
                        headerImage3.ContentType = new ContentType("image/jpg");
                        av.LinkedResources.Add(headerImage3);


                        mailMessage.AlternateViews.Add(av);
                        mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                        mailMessage.To.Add(operacionCita.CorreoElectronico);
                        mailMessage.Subject = "INO CONSULTAS WEB - Respuesta Solicitud Cita";
                        mailMessage.IsBodyHtml = true;
                        ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                        AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                        mailMessage.AlternateViews.Add(alternate);
                        client.Send(mailMessage);
                    }

                    
                }    

                await Context.SaveChangesAsync();
            }

            return respuesta;
        }

        public async Task<RespuestaBD> AtenderSolicitudCita(AtenderSolicitudCita cita)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SolicitudCita solicitud = await Context.SolicitudesCita.FirstOrDefaultAsync(x => x.IdSolicitudCita == cita.IdSolicitudCita);

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("noreply.inoinvision@gmail.com", "P@sw0rd00!");
            client.EnableSsl = true;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.DeliveryFormat = SmtpDeliveryFormat.International;
            client.Port = 587;
            client.Timeout = 20000;

            if (solicitud == null)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "La solicitud no existe";
            }
            else
            {
                //Test Validacion PIN -- DESCOMENTAR ABAJO
                //Solicitar Clave

                //var contrasena = Security.HashSHA1(cita.Clave);
                //var emp = await Context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == cita.IdUsuarioCreacion && x.Contrasena == contrasena);

                //if (emp == null)
                //{
                //    respuesta.Id = 0;
                //    respuesta.Mensaje = "La clave ingresada no es correcta";
                //}
                //else
                //{

                //    foreach (var e in cita.ListaDiagnostico)
                //    {
                //        SolicitudCitaDiagnostico solicitudCitaDiagnostico = new SolicitudCitaDiagnostico
                //        {
                //            IdSolicitudCita = cita.IdSolicitudCita,
                //            IdDiagnostico = e.IdDiagnostico,
                //            CodigoCIE10 = e.CIE10,
                //            Descripcion = e.Descripcion,
                //            TipoDX = e.TipoDX,
                //            IdUsuarioCreacion = cita.IdUsuarioCreacion,
                //            FechaCreacion = DateTime.Now,
                //            Ojo = e.Ojo
                //        };
                //        var dx = await Context.SolicitudesCitaDiagnosticos.FirstOrDefaultAsync(x => x.IdSolicitudCita == cita.IdSolicitudCita && x.IdDiagnostico == e.IdDiagnostico && x.TipoDX == e.TipoDX);

                //        if (dx == null)
                //            Context.SolicitudesCitaDiagnosticos.Add(solicitudCitaDiagnostico);
                //    }

                //    foreach (var m in cita.ListaMedicamento)
                //    {
                //        SolicitudCitaMedicamento solicitudCitaMedicamento = new SolicitudCitaMedicamento
                //        {
                //            IdSolicitudCita = cita.IdSolicitudCita,
                //            IdMedicamento = m.IdMedicamento,
                //            Nombre = m.Nombre,
                //            ForFarm = m.ForFarm,
                //            Cantidad = m.Cantidad,
                //            Ojo = m.Ojo,
                //            Indicacion = m.Indicacion,
                //            IdUsuarioCreacion = cita.IdUsuarioCreacion,
                //            FechaCreacion = DateTime.Now
                //        };
                //        Context.SolicitudesCitaMedicamentos.Add(solicitudCitaMedicamento);
                //    }

                //    if (cita.ListaMedicamento.Count > 0)
                //    {
                //        //Envio de Correo

                //        using (StreamReader SourceReader = System.IO.File.OpenText("respuestaReceta.html"))
                //        {
                //            MailMessage mailMessage = new MailMessage();

                //            string body = (SourceReader.ReadToEnd()).Replace("(Nombre1 + Apellidopaterno)", solicitud.PrimerNombre + " " + solicitud.ApellidoPaterno);
                //            body = body.Replace("PacienteNombreCompleto", solicitud.PrimerNombre + " " + solicitud.SegundoNombre + " " + solicitud.ApellidoPaterno + " " + solicitud.SegundoNombre);
                //            //var dxStr = "";
                //            //for (int i = 0; i < cita.ListaDiagnostico.Count(); ++i)
                //            //{
                //            //    dxStr += cita.ListaDiagnostico.ElementAt(i).Descripcion;
                //            //    if (i != cita.ListaDiagnostico.Count() - 1)
                //            //        dxStr += ", ";
                //            //}
                //            body = body.Replace("DiagnosticoNomb", cita.ListaDiagnostico.ElementAt(0).Descripcion);
                //            body = body.Replace("DxCIE10", cita.ListaDiagnostico.ElementAt(0).CIE10);

                //            DateTime now = DateTime.Today;
                //            int age = now.Year - solicitud.FechaNacimiento.Year;
                //            if (solicitud.FechaNacimiento > now.AddYears(-age)) age--;

                //            body = body.Replace("PacienteEdad", age + " AÑOS");
                //            body = body.Replace("PacienteDNI", solicitud.NumeroDocumento);


                //            for (int i = 0; i < cita.ListaMedicamento.Count(); ++i)
                //            {
                //                body = body.Replace("MedNomb" + (i + 1), (i + 1) + ". " + cita.ListaMedicamento.ElementAt(i).Nombre);
                //                body = body.Replace("MedForFarm" + (i + 1), cita.ListaMedicamento.ElementAt(i).ForFarm);
                //                body = body.Replace("MedQty" + (i + 1), cita.ListaMedicamento.ElementAt(i).Cantidad.ToString());
                //                body = body.Replace("IndOD" + (i + 1), cita.ListaMedicamento.ElementAt(i).Ojo == "OD" ? cita.ListaMedicamento.ElementAt(i).Indicacion : "");
                //                body = body.Replace("IndOI" + (i + 1), cita.ListaMedicamento.ElementAt(i).Ojo == "OI" ? cita.ListaMedicamento.ElementAt(i).Indicacion : "");
                //            }

                //            if (cita.ListaMedicamento.Count() < 5)
                //            {
                //                for (int i = cita.ListaMedicamento.Count() + 1; i <= 5; ++i)
                //                {
                //                    body = body.Replace("MedNomb" + i, "");
                //                    body = body.Replace("MedForFarm" + i, "");
                //                    body = body.Replace("MedQty" + i, "");
                //                    body = body.Replace("IndOD" + i, "");
                //                    body = body.Replace("IndOI" + i, "");
                //                }
                //            }

                //            body = body.Replace("FechaEmision", DateTime.Now.ToString("dd/MM/yyyy"));
                //            body = body.Replace("FechaValidoHasta", cita.FechaValidoHasta.Value.ToString("dd/MM/yyyy"));

                //            var IdEmpleado = new SqlParameter("IdEmpleado", emp.IdEmpleado);

                //            var med = await GalenContext.Query<MedicoDatosView>().FromSql("dbo.Invision_ObtenerDatosMedico @IdEmpleado", IdEmpleado)
                //                    .FirstOrDefaultAsync();

                //            if (med != null)
                //            {
                //                body = body.Replace("DatosMedico", emp.Nombres + " " + emp.ApellidoPaterno + " " + emp.ApellidoMaterno + "\n" + "CMP:" + med.Cmp + ((med.Rne != null && med.Rne != "") ? "RNE: " + med.Rne : ""));
                //            }

                //            AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                //            byte[] reader = File.ReadAllBytes("logoReceta.jpg");
                //            MemoryStream image1 = new MemoryStream(reader);

                //            LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                //            headerImage.ContentId = "logoReceta";
                //            headerImage.ContentType = new ContentType("image/jpg");
                //            av.LinkedResources.Add(headerImage);

                //            byte[] reader2 = File.ReadAllBytes("imgFirma.jpg");
                //            MemoryStream image2 = new MemoryStream(reader2);

                //            LinkedResource headerImage2 = new LinkedResource(image2, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                //            headerImage2.ContentId = "imgFirma";
                //            headerImage2.ContentType = new ContentType("image/jpg");
                //            av.LinkedResources.Add(headerImage2);

                //            mailMessage.AlternateViews.Add(av);
                //            mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                //            mailMessage.To.Add(solicitud.CorreoElectronico);
                //            mailMessage.Subject = "INO CONSULTAS WEB - Receta Médica Estandarizada";
                //            mailMessage.IsBodyHtml = true;
                //            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                //            AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                //            mailMessage.AlternateViews.Add(alternate);

                //            client.Send(mailMessage);

                //            solicitud.FechaRecetaValidoHasta = cita.FechaValidoHasta.Value;
                //        }
                //    }

                    

                //    solicitud.IdEstado = 3;
                //    solicitud.IdUsuarioAtiende = cita.IdUsuarioCreacion;
                //    solicitud.FechaAtiende = DateTime.Now;

                //    await Context.SaveChangesAsync();

                //    respuesta.Id = 1;
                //    respuesta.Mensaje = "La solicitud ha sido atendida";
                //}



                //Test

                solicitud.IdEstado = 3;
                solicitud.IdUsuarioAtiende = cita.IdUsuarioCreacion;
                solicitud.FechaAtiende = DateTime.Now;
                solicitud.CodProc = cita.ListaProcedimientos.ElementAt(0).CodProc;
                solicitud.DesProc = cita.ListaProcedimientos.ElementAt(0).DesProc;
                solicitud.TipoConsulta = cita.TipoConsulta;

                if (!string.IsNullOrEmpty(cita.TipoConsulta))
                {
                    //Crear Consulta Rapida
                    SolicitudConsultaRapida solicitudConsultaRapida = new SolicitudConsultaRapida
                    {
                        ApellidoPaterno = solicitud.ApellidoPaterno,
                        ApellidoMaterno = solicitud.ApellidoMaterno,
                        Nombres = solicitud.PrimerNombre + (string.IsNullOrEmpty(solicitud.SegundoNombre) ? "" : " " + solicitud.SegundoNombre),
                        IdTipoDocumento = solicitud.IdTipoDocumento,
                        NumeroDocumento = solicitud.NumeroDocumento,
                        CorreoElectronico = solicitud.CorreoElectronico,
                        TelefonoMovil = solicitud.TelefonoMovil,
                        IdEstadoCivil = solicitud.IdEstadoCivil,
                        FechaNacimiento = solicitud.FechaNacimiento,
                        IdSexo = solicitud.IdSexo,
                        IdDepartamento = solicitud.IdDepartamento,
                        IdProvincia = solicitud.IdProvincia,
                        IdDistrito = solicitud.IdDistrito,
                        Direccion = solicitud.Direccion,
                        MotivoConsulta = solicitud.MotivoConsulta,
                        FechaCreacion = DateTime.Now,
                        IdEstado = 0,
                        IdUsuarioAcepta = 0,
                        IdUsuarioCreacion = cita.IdUsuarioCreacion,
                        OrigenPaciente = cita.TipoConsulta == "TCG" ? "TELEORIENTACIÓN - TELECONSULTA" : "TELEORIENTACIÓN - CONSULTA PRESENCIAL"
                    };

                    Context.SolicitudesConsultaRapida.Add(solicitudConsultaRapida);
                    await Context.SaveChangesAsync();
                }

                foreach (var e in cita.ListaDiagnostico)
                {
                    SolicitudCitaDiagnostico solicitudCitaDiagnostico = new SolicitudCitaDiagnostico
                    {
                        IdSolicitudCita = cita.IdSolicitudCita,
                        IdDiagnostico = e.IdDiagnostico,
                        CodigoCIE10 = e.CIE10,
                        Descripcion = e.Descripcion,
                        TipoDX = e.TipoDX,
                        IdUsuarioCreacion = cita.IdUsuarioCreacion,
                        FechaCreacion = DateTime.Now,
                        Ojo = e.Ojo
                    };
                    var dx = await Context.SolicitudesCitaDiagnosticos.FirstOrDefaultAsync(x => x.IdSolicitudCita == cita.IdSolicitudCita && x.IdDiagnostico == e.IdDiagnostico && x.TipoDX == e.TipoDX);

                    if (dx == null)
                        Context.SolicitudesCitaDiagnosticos.Add(solicitudCitaDiagnostico);
                }

                //foreach (var m in cita.ListaMedicamento)
                //{
                //    SolicitudCitaMedicamento solicitudCitaMedicamento = new SolicitudCitaMedicamento
                //    {
                //        IdSolicitudCita = cita.IdSolicitudCita,
                //        IdMedicamento = m.IdMedicamento,
                //        Nombre = m.Nombre,
                //        ForFarm = m.ForFarm,
                //        Cantidad = m.Cantidad,
                //        Ojo = m.Ojo,
                //        Indicacion = m.Indicacion,
                //        IdUsuarioCreacion = cita.IdUsuarioCreacion,
                //        FechaCreacion = DateTime.Now
                //    };
                //    Context.SolicitudesCitaMedicamentos.Add(solicitudCitaMedicamento);
                //}

                await Context.SaveChangesAsync();

                respuesta.Id = 1;
                respuesta.Mensaje = "La solicitud ha sido atendida";

            }

            return respuesta;
        }

        public async Task<RespuestaBD> ActualizarAtencionCita(AtenderSolicitudCita cita)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SolicitudCita solicitud = await Context.SolicitudesCita.FirstOrDefaultAsync(x => x.IdSolicitudCita == cita.IdSolicitudCita);

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("noreply.inoinvision@gmail.com", "P@sw0rd00!");
            client.EnableSsl = true;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.DeliveryFormat = SmtpDeliveryFormat.International;
            client.Port = 587;
            client.Timeout = 20000;

            if (solicitud == null)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "La solicitud no existe";
            }
            else
            {
                //Prod

                IList<SolicitudCitaDiagnostico> listaEliminar = await Context.SolicitudesCitaDiagnosticos.Where(x => x.IdSolicitudCita == cita.IdSolicitudCita).ToListAsync();

                if (listaEliminar.Count > 0)
                {
                    Context.SolicitudesCitaDiagnosticos.RemoveRange(listaEliminar);
                    await Context.SaveChangesAsync();
                }

                foreach (var e in cita.ListaDiagnostico)
                {
                    SolicitudCitaDiagnostico solicitudCitaDiagnostico = new SolicitudCitaDiagnostico
                    {
                        IdSolicitudCita = cita.IdSolicitudCita,
                        IdDiagnostico = e.IdDiagnostico,
                        CodigoCIE10 = e.CIE10,
                        Descripcion = e.Descripcion,
                        TipoDX = e.TipoDX,
                        Ojo = e.Ojo,
                        IdUsuarioCreacion = cita.IdUsuarioCreacion,
                        FechaCreacion = DateTime.Now
                    };
                    Context.SolicitudesCitaDiagnosticos.Add(solicitudCitaDiagnostico);
                }

                IList<SolicitudCitaMedicamento> listaEliminarMedicamentos = await Context.SolicitudesCitaMedicamentos.Where(x => x.IdSolicitudCita == cita.IdSolicitudCita).ToListAsync();

                if (listaEliminarMedicamentos.Count > 0)
                {
                    Context.SolicitudesCitaMedicamentos.RemoveRange(listaEliminarMedicamentos);
                    await Context.SaveChangesAsync();
                }

                //foreach (var m in cita.ListaMedicamento)
                //{
                //    SolicitudCitaMedicamento solicitudCitaMedicamento = new SolicitudCitaMedicamento
                //    {
                //        IdSolicitudCita = cita.IdSolicitudCita,
                //        IdMedicamento = m.IdMedicamento,
                //        Nombre = m.Nombre,
                //        ForFarm = m.ForFarm,
                //        Cantidad = m.Cantidad,
                //        Ojo = m.Ojo,
                //        Indicacion = m.Indicacion,
                //        IdUsuarioCreacion = cita.IdUsuarioCreacion,
                //        FechaCreacion = DateTime.Now
                //    };
                //    Context.SolicitudesCitaMedicamentos.Add(solicitudCitaMedicamento);
                //}

                //solicitud.FechaRecetaValidoHasta = cita.FechaValidoHasta.Value;
                solicitud.IdEstado = 3;
                solicitud.IdUsuarioAtiende = cita.IdUsuarioCreacion;
                solicitud.FechaAtiende = DateTime.Now;
                solicitud.CodProc = cita.ListaProcedimientos.ElementAt(0).CodProc;
                solicitud.DesProc = cita.ListaProcedimientos.ElementAt(0).DesProc;
                solicitud.TipoConsulta = cita.TipoConsulta;

                await Context.SaveChangesAsync();

                respuesta.Id = 1;
                respuesta.Mensaje = "La solicitud ha sido atendida";

                //TEST
                ////Solicitar Clave

                //var contrasena = Security.HashSHA1(cita.Clave);
                //var userLogin = await Context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == cita.IdUsuarioCreacion && x.Contrasena == contrasena);

                //if (userLogin == null)
                //{
                //    respuesta.Id = 0;
                //    respuesta.Mensaje = "La clave ingresada no es correcta";
                //}
                //else
                //{

                //    IList<SolicitudCitaDiagnostico> listaEliminar = await Context.SolicitudesCitaDiagnosticos.Where(x => x.IdSolicitudCita == cita.IdSolicitudCita).ToListAsync();

                //    if (listaEliminar.Count > 0)
                //    {
                //        Context.SolicitudesCitaDiagnosticos.RemoveRange(listaEliminar);
                //        await Context.SaveChangesAsync();
                //    }

                //    foreach (var e in cita.ListaDiagnostico)
                //    {
                //        SolicitudCitaDiagnostico solicitudCitaDiagnostico = new SolicitudCitaDiagnostico
                //        {
                //            IdSolicitudCita = cita.IdSolicitudCita,
                //            IdDiagnostico = e.IdDiagnostico,
                //            CodigoCIE10 = e.CIE10,
                //            Descripcion = e.Descripcion,
                //            TipoDX = e.TipoDX,
                //            Ojo = e.Ojo,
                //            IdUsuarioCreacion = cita.IdUsuarioCreacion,
                //            FechaCreacion = DateTime.Now
                //        };
                //        Context.SolicitudesCitaDiagnosticos.Add(solicitudCitaDiagnostico);
                //    }

                //    IList<SolicitudCitaMedicamento> listaEliminarMedicamentos = await Context.SolicitudesCitaMedicamentos.Where(x => x.IdSolicitudCita == cita.IdSolicitudCita).ToListAsync();

                //    if (listaEliminarMedicamentos.Count > 0)
                //    {
                //        Context.SolicitudesCitaMedicamentos.RemoveRange(listaEliminarMedicamentos);
                //        await Context.SaveChangesAsync();
                //    }

                //    foreach (var m in cita.ListaMedicamento)
                //    {
                //        SolicitudCitaMedicamento solicitudCitaMedicamento = new SolicitudCitaMedicamento
                //        {
                //            IdSolicitudCita = cita.IdSolicitudCita,
                //            IdMedicamento = m.IdMedicamento,
                //            Nombre = m.Nombre,
                //            ForFarm = m.ForFarm,
                //            Cantidad = m.Cantidad,
                //            Ojo = m.Ojo,
                //            Indicacion = m.Indicacion,
                //            IdUsuarioCreacion = cita.IdUsuarioCreacion,
                //            FechaCreacion = DateTime.Now
                //        };
                //        Context.SolicitudesCitaMedicamentos.Add(solicitudCitaMedicamento);
                //    }

                //    if (cita.ListaMedicamento.Count > 0)
                //    {
                //        //Envio de Correo

                //        using (StreamReader SourceReader = System.IO.File.OpenText("respuestaReceta.html"))
                //        {
                //            MailMessage mailMessage = new MailMessage();

                //            string body = (SourceReader.ReadToEnd()).Replace("(Nombre1 + Apellidopaterno)", solicitud.PrimerNombre + " " + solicitud.ApellidoPaterno);
                //            body = body.Replace("PacienteNombreCompleto", solicitud.PrimerNombre + " " + solicitud.SegundoNombre + " " + solicitud.ApellidoPaterno + " " + solicitud.SegundoNombre);
                //            //var dxStr = "";
                //            //for (int i = 0; i < cita.ListaDiagnostico.Count(); ++i)
                //            //{
                //            //    dxStr += cita.ListaDiagnostico.ElementAt(i).Descripcion;
                //            //    if (i != cita.ListaDiagnostico.Count() - 1)
                //            //        dxStr += ", ";
                //            //}
                //            body = body.Replace("DiagnosticoNomb", cita.ListaDiagnostico.ElementAt(0).Descripcion);
                //            body = body.Replace("DxCIE10", cita.ListaDiagnostico.ElementAt(0).CIE10);

                //            DateTime now = DateTime.Today;
                //            int age = now.Year - solicitud.FechaNacimiento.Year;
                //            if (solicitud.FechaNacimiento > now.AddYears(-age)) age--;

                //            body = body.Replace("PacienteEdad", age + " AÑOS");
                //            body = body.Replace("PacienteDNI", solicitud.NumeroDocumento);


                //            for (int i = 0; i < cita.ListaMedicamento.Count(); ++i)
                //            {
                //                body = body.Replace("MedNomb" + (i + 1), (i + 1) + ". " + cita.ListaMedicamento.ElementAt(i).Nombre);
                //                body = body.Replace("MedForFarm" + (i + 1), cita.ListaMedicamento.ElementAt(i).ForFarm);
                //                body = body.Replace("MedQty" + (i + 1), cita.ListaMedicamento.ElementAt(i).Cantidad.ToString());
                //                body = body.Replace("IndOD" + (i + 1), cita.ListaMedicamento.ElementAt(i).Ojo == "OD" ? cita.ListaMedicamento.ElementAt(i).Indicacion : "");
                //                body = body.Replace("IndOI" + (i + 1), cita.ListaMedicamento.ElementAt(i).Ojo == "OI" ? cita.ListaMedicamento.ElementAt(i).Indicacion : "");
                //            }

                //            if (cita.ListaMedicamento.Count() < 5)
                //            {
                //                for (int i = cita.ListaMedicamento.Count() + 1; i <= 5; ++i)
                //                {
                //                    body = body.Replace("MedNomb" + i, "");
                //                    body = body.Replace("MedForFarm" + i, "");
                //                    body = body.Replace("MedQty" + i, "");
                //                    body = body.Replace("IndOD" + i, "");
                //                    body = body.Replace("IndOI" + i, "");
                //                }
                //            }

                //            body = body.Replace("FechaEmision", DateTime.Now.ToString("dd/MM/yyyy"));
                //            body = body.Replace("FechaValidoHasta", cita.FechaValidoHasta.Value.ToString("dd/MM/yyyy"));

                //            var IdEmpleado = new SqlParameter("IdEmpleado", userLogin.IdEmpleado);

                //            var med = await GalenContext.Query<MedicoDatosView>().FromSql("dbo.Invision_ObtenerDatosMedico @IdEmpleado", IdEmpleado)
                //                    .FirstOrDefaultAsync();

                //            if (med != null)
                //            {
                //                body = body.Replace("DatosMedico", userLogin.Nombres + " " + userLogin.ApellidoPaterno + " " + userLogin.ApellidoMaterno + "\n" + "CMP:" + med.Cmp + ((med.Rne != null && med.Rne != "") ? "RNE: " + med.Rne : ""));
                //            }

                //            AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                //            byte[] reader = File.ReadAllBytes("logoReceta.jpg");
                //            MemoryStream image1 = new MemoryStream(reader);

                //            LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                //            headerImage.ContentId = "logoReceta";
                //            headerImage.ContentType = new ContentType("image/jpg");
                //            av.LinkedResources.Add(headerImage);

                //            byte[] reader2 = File.ReadAllBytes("imgFirma.jpg");
                //            MemoryStream image2 = new MemoryStream(reader2);

                //            LinkedResource headerImage2 = new LinkedResource(image2, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                //            headerImage2.ContentId = "imgFirma";
                //            headerImage2.ContentType = new ContentType("image/jpg");
                //            av.LinkedResources.Add(headerImage2);

                //            mailMessage.AlternateViews.Add(av);
                //            mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                //            mailMessage.To.Add(solicitud.CorreoElectronico);
                //            mailMessage.Subject = "INO CONSULTAS WEB - Receta Médica Estandarizada";
                //            mailMessage.IsBodyHtml = true;
                //            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                //            AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                //            mailMessage.AlternateViews.Add(alternate);

                //            client.Send(mailMessage);

                //            solicitud.FechaRecetaValidoHasta = cita.FechaValidoHasta.Value;
                //        }
                //    }

                //    solicitud.IdEstado = 3;
                //    solicitud.IdUsuarioAtiende = cita.IdUsuarioCreacion;
                //    solicitud.FechaAtiende = DateTime.Now;

                //    await Context.SaveChangesAsync();

                //    respuesta.Id = 1;
                //    respuesta.Mensaje = "La solicitud ha sido atendida";
                //}


            }

            return respuesta;
        }

        public RespuestaBD ValidarSolicitudCita(RegistroSolicitudCita solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();
            
            var solicitudHoy = Context.SolicitudesCita.FirstOrDefault(x => x.NumeroDocumento == solicitud.NumeroDocumento && x.FechaCreacion.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"));

            if (solicitudHoy != null)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Ya existe una solicitud creada";
                
            }
            else
            {
                respuesta.Id = 1;
                respuesta.Mensaje = "Solicitud valida";
            }

            return respuesta;
        }

        public async Task<CitaCuarentenaDto> ConsultarCitaCuarentena(string dni)
        {
            var Dni = new SqlParameter("DNI", dni);
            //Dni.Value = (object)dni ?? DBNull.Value;

            return await GalenContext.Query<CitaCuarentenaView>().FromSql("dbo.Invision_ObtenerCitaCuarentena @DNI", Dni)
                .Select(x => Mapper.Map<CitaCuarentenaDto>(x))
                .FirstOrDefaultAsync();
        }

        public async Task<RespuestaBD> CrearSolicitudReprogramacion(RegistroSolicitudReprogramacion solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();
            
            var solicitudCreada = await Context.SolicitudesReprogramacion.FirstOrDefaultAsync(x => x.IdCuentaAtencion == solicitud.IdCuentaAtencion);

            if (solicitudCreada != null)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya ha ingresado una solicitud";
            }
            else
            {
                SolicitudReprogramacion reprogramacion = Mapper.Map<SolicitudReprogramacion>(solicitud);

                Context.SolicitudesReprogramacion.Add(reprogramacion);

                Context.SaveChanges();

                respuesta.Id = 1;
                respuesta.Mensaje = "Se ha registrado la solicitud correctamente";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EnviarCorreoCitaCuarentena(EnviarCorreoCuarentenaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();
            
            var CuentaAtencion = new SqlParameter("IdCuentaAtencion", solicitud.IdCuentaAtencion);

            CitaCuarentenaCorreoView data = await GalenContext.Query<CitaCuarentenaCorreoView>().FromSql("dbo.Invision_ObtenerCitaCuarentenaParaCorreo @IdCuentaAtencion", CuentaAtencion)
                .FirstOrDefaultAsync();

            if (data == null)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Ha ocurrido un error";
            }
            else
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("noreply.inoinvision@gmail.com", "P@sw0rd00!");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.DeliveryFormat = SmtpDeliveryFormat.International;
                client.Port = 587;
                client.Timeout = 20000;

                using (StreamReader SourceReader = System.IO.File.OpenText("correoCitaCuarentena.html"))
                {

                    MailMessage mailMessage = new MailMessage();

                    string body = (SourceReader.ReadToEnd()).Replace("(Nombre1 + Apellidopaterno)", data.NombresPaciente + " " + data.ApellidosPaciente);
                    body = body.Replace("FechaCita", data.FechaCita.ToString("dd/MM/yyyy"));
                    body = body.Replace("HoraCita", data.HoraCita);
                    body = body.Replace("EspecialidadCita", data.Especialidad);
                    body = body.Replace("NroDocumentoIdentidad", data.NroDocumento);
                    body = body.Replace("NroCuenta", data.IdCuentaAtencion.ToString());
                    body = body.Replace("TurnoPaciente", data.Turno);
                    body = body.Replace("SeguroPaciente", data.Seguro);

                    AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                    byte[] reader = File.ReadAllBytes("banner_reprogramacion.jpg");
                    MemoryStream image1 = new MemoryStream(reader);

                    LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                    headerImage.ContentId = "bannerReprogramacion";
                    headerImage.ContentType = new ContentType("image/jpg");
                    av.LinkedResources.Add(headerImage);

                    mailMessage.AlternateViews.Add(av);
                    mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                    mailMessage.To.Add(solicitud.Correo);
                    mailMessage.Subject = "INO CONSULTAS WEB - Respuesta Reprogramación Cita";
                    mailMessage.IsBodyHtml = true;
                    ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                    AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                    mailMessage.AlternateViews.Add(alternate);

                    client.Send(mailMessage);

                    respuesta.Id = 1;
                    respuesta.Mensaje = "El correo ha sido enviado exitosamente";
                }
            }

            return respuesta;
        }

        public async Task<CitaCuarentenaCorreoDto> ObtenerDataCitaCuarentena(int idCuentaAtencion)
        {
            var CuentaAtencion = new SqlParameter("IdCuentaAtencion", idCuentaAtencion);

            return await GalenContext.Query<CitaCuarentenaCorreoView>().FromSql("dbo.Invision_ObtenerCitaCuarentenaParaCorreo @IdCuentaAtencion", CuentaAtencion)
                .Select(x => Mapper.Map<CitaCuarentenaCorreoDto>(x))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SolicitudReprogramacionCitaCuarentenaDto>> ListarSolicitudReprogramacionCitaCuarentena()
        {
            return await Context.SolicitudesReprogramacion.Where(x => x.IdEstado == 0).Select(x => Mapper.Map<SolicitudReprogramacionCitaCuarentenaDto>(x)).ToListAsync();
        }

        public async Task<ConteoCGDto> ListarTotalCG(DateTime fecha)
        {
            var Fecha = new SqlParameter("fecha", fecha);

            var list = await GalenContext.Query<ConteoCGView>().FromSql("dbo.INO_ConteoConsultoriosGenerales2 @fecha", Fecha).ToListAsync();

            return new ConteoCGDto
            {
                TotalNuevos = list.Where(x => x.Codigo == 1 || x.Codigo == 2).Sum(d => d.Conteo),
                TotalContinuadores = list.Where(x => x.Codigo == 3 || x.Codigo == 4).Sum(d => d.Conteo),
                Total = list.Where(x => x.Codigo == 1 || x.Codigo == 2 || x.Codigo == 3 || x.Codigo == 4).Sum(d => d.Conteo),
            };
        }

        public async Task<RespuestaBD> GuardarNuevaFechaReprogramacion(GuardarNuevaFechaReprogramacionDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            var solicitudDb = await Context.SolicitudesReprogramacion.FirstOrDefaultAsync(x => x.IdSolicitud == solicitud.IdSolicitud);

            if (solicitud == null)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Ha ocurrido un error. No se encuentra la solicitud";
            }
            else
            {
                solicitudDb.NuevaFechaReprogramacion = solicitud.NuevaFechaReprogramacion;
                solicitudDb.IdUsuarioReprograma = solicitud.IdUsuarioReprograma;
                solicitudDb.FechaReprogramacion = DateTime.Now;
                await Context.SaveChangesAsync();
                respuesta.Id = 1;
                respuesta.Mensaje = "Se ha guardado la fecha correctamente.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> ValidarReprogramacion(ValidarReprogramacionDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            var solicitudDb = await Context.SolicitudesReprogramacion.FirstOrDefaultAsync(x => x.IdSolicitud == solicitud.IdSolicitud);

            if (solicitud == null)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Ha ocurrido un error. No se encuentra la solicitud";
            }
            else
            {
                solicitudDb.IdEstado = 1;
                solicitudDb.IdUsuarioValida = solicitud.IdUsuarioValida;
                solicitudDb.FechaValidacion = DateTime.Now;
                await Context.SaveChangesAsync();

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("noreply.inoinvision@gmail.com", "P@sw0rd00!");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.DeliveryFormat = SmtpDeliveryFormat.International;
                client.Port = 587;
                client.Timeout = 20000;

                using (StreamReader SourceReader = System.IO.File.OpenText("correoCitaCuarentena.html"))
                {

                    MailMessage mailMessage = new MailMessage();

                    var CuentaAtencion = new SqlParameter("IdCuentaAtencion", solicitudDb.IdCuentaAtencion);

                    CitaCuarentenaCorreoView data = await GalenContext.Query<CitaCuarentenaCorreoView>().FromSql("dbo.Invision_ObtenerCitaCuarentenaParaCorreo @IdCuentaAtencion", CuentaAtencion)
                        .FirstOrDefaultAsync();

                    string body = (SourceReader.ReadToEnd()).Replace("(Nombre1 + Apellidopaterno)", data.NombresPaciente + " " + data.ApellidosPaciente);
                    body = body.Replace("FechaCita", data.FechaCita.ToString("dd/MM/yyyy"));
                    body = body.Replace("HoraCita", data.HoraCita);
                    body = body.Replace("EspecialidadCita", data.Especialidad);
                    body = body.Replace("NroDocumentoIdentidad", data.NroDocumento);
                    body = body.Replace("NroCuenta", data.IdCuentaAtencion.ToString());
                    body = body.Replace("TurnoPaciente", data.Turno);
                    body = body.Replace("SeguroPaciente", data.Seguro);

                    AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                    byte[] reader = File.ReadAllBytes("banner_reprogramacion.jpg");
                    MemoryStream image1 = new MemoryStream(reader);

                    LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                    headerImage.ContentId = "bannerReprogramacion";
                    headerImage.ContentType = new ContentType("image/jpg");
                    av.LinkedResources.Add(headerImage);

                    mailMessage.AlternateViews.Add(av);
                    mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                    mailMessage.To.Add(solicitud.Correo);
                    mailMessage.Subject = "INO CONSULTAS WEB - Respuesta Reprogramación Cita";
                    mailMessage.IsBodyHtml = true;
                    ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                    AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                    mailMessage.AlternateViews.Add(alternate);

                    client.Send(mailMessage);

                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se ha validado la reprogramación correctamente.";
                }
            }

            return respuesta;
        }



        public async Task<RespuestaBD> CrearSolicitudTeleconsulta(CrearSolicitudTeleconsultaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            var solicitudCreada = await Context.SolicitudesTeleconsulta.FirstOrDefaultAsync(x => x.IdCuentaAtencion == solicitud.IdCuentaAtencion && x.IdCita == solicitud.IdCita);

            if (solicitudCreada != null)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya ha ingresado una solicitud para la cita seleccionada.";

            }
            else
            {
                SolicitudTeleconsulta solicitudTeleconsulta = Mapper.Map<SolicitudTeleconsulta>(solicitud);

                Context.SolicitudesTeleconsulta.Add(solicitudTeleconsulta);

                Context.SaveChanges();

                // Correo Electronico - Envio de consentimiento ifnormado

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("noreply.inoinvision@gmail.com", "P@sw0rd00!");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.DeliveryFormat = SmtpDeliveryFormat.International;
                client.Port = 587;
                client.Timeout = 20000;

                using (StreamReader SourceReader = System.IO.File.OpenText("consentimientoInformado.html"))
                {
                    MailMessage mailMessage = new MailMessage();

                    string body = (SourceReader.ReadToEnd()).Replace("(Nombre1 + Apellidopaterno)", solicitud.Paciente);
                    body = body.Replace("fechaAceptacion", DateTime.Now.ToString("dd/MM/yyyy"));
                    body = body.Replace("horaAceptacion", DateTime.Now.ToString("hh:mm tt"));
                    body = body.Replace("nombrePaciente", solicitud.Paciente);
                    body = body.Replace("dniPaciente", solicitud.NroDocumento);
                    AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                    byte[] reader = File.ReadAllBytes("slogan_telesalud.jpg");
                    MemoryStream image1 = new MemoryStream(reader);

                    LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                    headerImage.ContentId = "logoIno";
                    headerImage.ContentType = new ContentType("image/jpg");
                    av.LinkedResources.Add(headerImage);

                    mailMessage.AlternateViews.Add(av);
                    mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                    mailMessage.To.Add(solicitud.CorreoElectronico);
                    mailMessage.Subject = "INO TELECONSULTA - Confirmación Consentimiento Informado";
                    mailMessage.IsBodyHtml = true;
                    ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                    AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                    mailMessage.AlternateViews.Add(alternate);

                    // Adjuntar Consentimiento Informado Pdf

                    string fileName = "CONSENTIMIENTO INFORMADO.pdf";
                    Attachment attachment = new Attachment(fileName, MediaTypeNames.Application.Octet);
                    ContentDisposition disposition = attachment.ContentDisposition;
                    disposition.CreationDate = File.GetCreationTime(fileName);
                    disposition.ModificationDate = File.GetLastWriteTime(fileName);
                    disposition.ReadDate = File.GetLastAccessTime(fileName);
                    disposition.FileName = Path.GetFileName(fileName);
                    disposition.Size = new FileInfo(fileName).Length;
                    disposition.DispositionType = DispositionTypeNames.Attachment;

                    mailMessage.Attachments.Add(attachment);

                    client.Send(mailMessage);
                }

                respuesta.Id = 1;
                respuesta.Mensaje = "¡Se ha registrado la solicitud correctamente!";
            }

            return respuesta;
        }

        public async Task<IEnumerable<CitaPostCuarentenaDto>> ListarCitasPostCuarentena(string dni)
        {
            var Dni = new SqlParameter("DNI", dni);
            //Dni.Value = (object)dni ?? DBNull.Value;

            return await GalenContext.Query<CitaPostCuarentenaView>().FromSql("dbo.Invision_Teleconsulta_ObtenerCitasPostCuarentena @DNI", Dni)
                .Select(x => Mapper.Map<CitaPostCuarentenaDto>(x))
                .ToListAsync();
        }

        public async Task<RespuestaBD> AceptarSolicitudTeleconsulta(AceptarSolicitudTeleconsultaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SolicitudTeleconsulta solicitudDb = await Context.SolicitudesTeleconsulta.FirstOrDefaultAsync(x => x.IdSolicitud == solicitud.IdSolicitud);

            if (solicitud == null)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "La solicitud no existe";
            }
            else
            {
                
                // Correo Electronico - Envio de confirmacion reprogramacion online

                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("noreply.inoinvision@gmail.com", "P@sw0rd00!");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.DeliveryFormat = SmtpDeliveryFormat.International;
                client.Port = 587;
                client.Timeout = 20000;

                using (StreamReader SourceReader = System.IO.File.OpenText("confirmacionReprogramacion.html"))
                {
                    MailMessage mailMessage = new MailMessage();

                    string body = (SourceReader.ReadToEnd()).Replace("(Nombre1 + Apellidopaterno)", solicitudDb.Paciente);
                    body = body.Replace("fechaCita", solicitudDb.FechaCita.ToString("dd/MM/yyyy"));
                    body = body.Replace("horaCita", solicitud.NuevoHoraCita);
                    body = body.Replace("nombreEspecialidad", solicitud.Especialidad);
                    body = body.Replace("dniPaciente", solicitudDb.NroDocumento);
                    body = body.Replace("nombreMedico", solicitudDb.Medico);
                    body = body.Replace("nroCuenta", solicitudDb.IdCuentaAtencion.ToString());
                    body = body.Replace("nombreTurno", solicitudDb.Turno);
                    body = body.Replace("fteFto", solicitudDb.FteFto);
                    body = body.Replace("urlConsultorio", solicitud.Url);
                    AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                    byte[] reader = File.ReadAllBytes("slogan_telesalud.jpg");
                    MemoryStream image1 = new MemoryStream(reader);

                    LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                    headerImage.ContentId = "logoIno";
                    headerImage.ContentType = new ContentType("image/jpg");
                    av.LinkedResources.Add(headerImage);

                    mailMessage.AlternateViews.Add(av);
                    mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                    mailMessage.To.Add(solicitud.CorreoElectronico);
                    mailMessage.Subject = "INO TELECONSULTA - Confirmación de Reprogramación Online";
                    mailMessage.IsBodyHtml = true;
                    ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                    AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                    mailMessage.AlternateViews.Add(alternate);
                    client.Send(mailMessage);
                }

                // Ejecutar SP

                List<CupoTeleconsulta> cuposTeleconsulta = new List<CupoTeleconsulta>();

                //cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "05:00", HoraFin = "05:10" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "05:10", HoraFin = "05:20" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "05:20", HoraFin = "05:30" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "05:30", HoraFin = "05:40" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "05:40", HoraFin = "05:50" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "05:50", HoraFin = "06:00" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "06:00", HoraFin = "06:10" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "06:10", HoraFin = "06:20" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "06:20", HoraFin = "06:30" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "06:30", HoraFin = "06:40" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "06:40", HoraFin = "06:50" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "06:50", HoraFin = "07:00" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "07:00", HoraFin = "07:10" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "07:10", HoraFin = "07:20" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "07:20", HoraFin = "07:30" });
                cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "07:30", HoraFin = "07:40" });
                //cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "07:40", HoraFin = "07:50" });
                //cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "07:50", HoraFin = "08:00" });
                //cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "08:00", HoraFin = "08:10" });
                //cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "08:10", HoraFin = "08:20" });
                //cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "08:20", HoraFin = "08:30" });
                //cuposTeleconsulta.Add(new CupoTeleconsulta { HoraInicio = "08:30", HoraFin = "08:40" });

                int nroCupo = await Context.SolicitudesTeleconsulta.CountAsync(x => x.IdEstado == 1 && x.FechaReprogramacion.HasValue && x.FechaReprogramacion.Value.ToString("yyyy-MM-dd") == solicitud.Fecha.ToString("yyyy-MM-dd") && x.Especialidad == solicitud.Especialidad && x.IdMedico == solicitud.IdMedico);

                if (nroCupo < 15)
                {
                    await GalenContext.Database.ExecuteSqlCommandAsync("dbo.INO_ReprogramacionEntreEspecialidades @idCuentaAtencion = {0}, @especialidad = {1}, @fecha = {2}, @idMedico = {3}, @horaInicio = {4}, @horaFin = {5}", 
                        solicitudDb.IdCuentaAtencion, solicitudDb.Especialidad, solicitud.Fecha, solicitudDb.IdMedico,
                        cuposTeleconsulta.ElementAt(nroCupo).HoraInicio, cuposTeleconsulta.ElementAt(nroCupo).HoraFin);

                    solicitudDb.IdEstado = 1;
                    solicitudDb.IdUsuarioAcepta = solicitud.IdUsuario;
                    solicitudDb.FechaAcepta = DateTime.Now;
                    solicitudDb.NuevoHoraCita = solicitud.NuevoHoraCita;
                    solicitudDb.Url = solicitud.Url;
                    solicitudDb.FechaReprogramacion = solicitud.Fecha;

                    await Context.SaveChangesAsync();

                    respuesta.Id = 1;
                    respuesta.Mensaje = "¡La solicitud ha sido aceptada!";
                }
                else
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No hay cupo disponible para el presente dia"; // Modificar mensaje cuando la fecha se pase como parametro
                }

            }

            return respuesta;
        }

        public async Task<IEnumerable<SolicitudTeleconsultaDto>> ListarSolicitudTeleconsulta(int idEstado, DateTime fecha)
        {
            return await Context.SolicitudesTeleconsulta.Where(x => x.IdEstado == idEstado && x.FechaCreacion.ToString("yyyy-MM-dd") == fecha.ToString("yyyy-MM-dd")).Select(x => Mapper.Map<SolicitudTeleconsultaDto>(x)).ToListAsync();
        }

        public ConsultaRENIECDto ObtenerDatosGeneralesRENIEC(string dni)
        {
            ConsultaRENIECDto dto = new ConsultaRENIECDto();

            using (var httpClient = new HttpClient())
            {
                string[] responseStr = null;

                var server = "http://invision.ino.gob.pe:8085/";
                var url = server + "api/ConsultaWeb/";
                var method = "ObtenerDatosGeneralesPorReniec?";
                var parameters = "dni=" + dni;
                var uri = url + method + parameters;
                using (var response = httpClient.GetAsync(uri).Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    responseStr = JsonConvert.DeserializeObject<string[]>(apiResponse);
                }

                if (responseStr != null)
                {
                    dto.Apellidos = responseStr[0];
                    dto.Nombres = responseStr[1];
                    dto.FechaNacimiento = responseStr[2];
                    dto.Sexo = responseStr[3];
                    dto.Direccion = responseStr[4];
                    dto.DepProv = responseStr[5];
                    dto.Distrito = responseStr[6];
                    dto.Nacionalidad = responseStr[7];
                    dto.Edad = responseStr[8];
                    dto.Dni = dni;
                }

                
            }

            return dto;
        }

        public async Task<RespuestaBD> CrearSolicitudConsultaRapida(RegistroSolicitudConsultaRapidaDto solicitud)
        {
            using (var httpClient = new HttpClient())
            {

                RespuestaBD respuesta = new RespuestaBD();

                try
                {
                    //1. Validacion Reniec

                    SolicitudConsultaRapida solicitudCita = null;



                    if (solicitud.IdTipoDocumento == 1)
                    {

                        string[] responseStr = null;

                        var server = "http://invision.ino.gob.pe:8085/";
                        var url = server + "api/ConsultaWeb/";
                        var method = "ObtenerDatosGeneralesPorReniec?";
                        var parameters = "dni=" + solicitud.NumeroDocumento;
                        var uri = url + method + parameters;
                        using (var response = httpClient.GetAsync(uri).Result)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            responseStr = JsonConvert.DeserializeObject<string[]>(apiResponse);
                        }

                        string fecEmision = responseStr[9];

                        if (solicitud.FechaEmision.ToString("dd/MM/yyyy") == fecEmision)
                        {
                            //Validar si ya tiene 1 solicitud en el dia
                            var solicitudDia = await Context.SolicitudesConsultaRapida.FirstOrDefaultAsync(x => x.NumeroDocumento == solicitud.NumeroDocumento && x.FechaCreacion.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"));

                            if (solicitudDia != null)
                            {
                                respuesta.Id = 0;
                                respuesta.Mensaje = "La persona ya cuenta con una solicitud registrada para el día de hoy.";

                                return respuesta;
                            }

                            solicitudCita = Mapper.Map<SolicitudConsultaRapida>(solicitud);

                            Context.SolicitudesConsultaRapida.Add(solicitudCita);

                            await Context.SaveChangesAsync();

                            respuesta.Id = 1;
                            respuesta.Mensaje = "Se ha registrado la solicitud correctamente";
                        }
                        else
                        {
                            respuesta.Id = 0;
                            respuesta.Mensaje = "La fecha de emision ingresada no coincide con RENIEC";
                        }


                    }
                    else
                    {
                        //Validar si ya tiene 1 solicitud en el dia
                        var solicitudDia = await Context.SolicitudesConsultaRapida.FirstOrDefaultAsync(x => x.NumeroDocumento == solicitud.NumeroDocumento && x.FechaCreacion.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"));

                        if (solicitudDia != null)
                        {
                            respuesta.Id = 0;
                            respuesta.Mensaje = "La persona ya cuenta con una solicitud registrada para el día de hoy.";

                            return respuesta;
                        }

                        solicitudCita = Mapper.Map<SolicitudConsultaRapida>(solicitud);

                        Context.SolicitudesConsultaRapida.Add(solicitudCita);

                        await Context.SaveChangesAsync();

                        respuesta.Id = 1;
                        respuesta.Mensaje = "Se ha registrado la solicitud correctamente";
                    }


                }
                catch (Exception ex)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Ha ocurrido un error";
                }

                return respuesta;


            }
        }

        public async Task<IEnumerable<ComboBox>> ListarCuposConsultaRapida(DateTime fecha, string horaInicio, string horaFin, int intervalo)
        {
            IList<ComboBox> listaIntervalos = new List<ComboBox>();

            int nSlots = Convert.ToInt32(((TimeSpan.ParseExact(horaFin, "hh\\:mm", CultureInfo.InvariantCulture) - 
                                    TimeSpan.ParseExact(horaInicio, "hh\\:mm", CultureInfo.InvariantCulture)).TotalMinutes) / 
                                    intervalo);

            var listaSolicitudes = await Context.SolicitudesConsultaRapida
                                .Where(c => c.FechaCita.HasValue && c.FechaCita.Value.ToString("yyyy-MM-dd") == fecha.ToString("yyyy-MM-dd"))
                                .Select(c => c.HoraCita)
                                .ToListAsync();

            if (nSlots > 0)
            {
                for (int i = 0; i < nSlots; ++i)
                {

                    var startH = (TimeSpan.Parse(horaInicio).Add(TimeSpan.FromMinutes(i * intervalo))).ToString(@"hh\:mm");
                    var endH = (TimeSpan.Parse(horaInicio).Add(TimeSpan.FromMinutes((i + 1) * intervalo))).ToString(@"hh\:mm");

                    if (!listaSolicitudes.Contains(startH + " - " + endH))
                    {
                        listaIntervalos.Add(new ComboBox
                        {
                            Id = i,
                            Descripcion = startH + " - " + endH
                        });
                    } 
                }
            }

            return listaIntervalos;
        }

        public async Task<IEnumerable<SolicitudConsultaRapidaDto>> ListarSolicitudConsultaRapida(DateTime fechaDesde, DateTime fechaHasta, int? idEstado)
        {
            return await Context.SolicitudesConsultaRapida.Where(x => x.FechaCreacion.Date >= fechaDesde.Date && x.FechaCreacion.Date <= fechaHasta
                                                                        && x.IdEstado == (idEstado ?? 0))
                                                          .Select(x => Mapper.Map<SolicitudConsultaRapidaDto>(x))
                                                          .ToListAsync();
        }

        public async Task<RespuestaBD> AceptarSolicitudConsultaRapida(AceptarSolicitudConsultaRapidaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("noreply.inoinvision@gmail.com", "P@sw0rd00!");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.DeliveryFormat = SmtpDeliveryFormat.International;
                client.Port = 587;
                client.Timeout = 20000;

                if (solicitud.IdOperacion == 1)
                {
                    if (solicitud.IdEstado == 1)
                    {
                        SolicitudConsultaRapida solicitudConsultaRapida = await Context.SolicitudesConsultaRapida.FirstOrDefaultAsync(x => x.IdSolicitud == solicitud.IdSolicitud);
                        if (solicitudConsultaRapida == null)
                        {
                            respuesta.Id = 0;
                            respuesta.Mensaje = "No se ha encontrado la solicitud en el sistema.";
                            return respuesta;
                        }
                        else
                        {
                            solicitudConsultaRapida.IdEstado = 1;
                            solicitudConsultaRapida.FechaAcepta = DateTime.Now;
                            solicitudConsultaRapida.IdUsuarioAcepta = solicitud.IdUsuario;

                            await Context.SaveChangesAsync();
                            respuesta.Id = 1;
                            respuesta.Mensaje = "El correo de teleconsulta ha sido enviado con éxito!";

                            using (StreamReader SourceReader = System.IO.File.OpenText("teleconsulta_consultarapida.html"))
                            {
                                MailMessage mailMessage = new MailMessage();

                                string body = (SourceReader.ReadToEnd()).Replace("NombresPaciente", $"{solicitud.Nombres}");
                                AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                                byte[] reader = File.ReadAllBytes("teleconsulta.jpg");
                                MemoryStream image1 = new MemoryStream(reader);

                                LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                                headerImage.ContentId = "logoTeleconsulta";
                                headerImage.ContentType = new ContentType("image/jpg");
                                av.LinkedResources.Add(headerImage);

                                mailMessage.AlternateViews.Add(av);
                                mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                                mailMessage.To.Add(solicitud.CorreoElectronico);
                                mailMessage.Subject = "INO TELECONSULTA - CONSULTA RÁPIDA";
                                mailMessage.IsBodyHtml = true;
                                ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                                AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                                mailMessage.AlternateViews.Add(alternate);

                                client.Send(mailMessage);
                            }

                        }
                    }
                    else
                    {
                        SolicitudConsultaRapida solicitudConsultaRapida = await Context.SolicitudesConsultaRapida.FirstOrDefaultAsync(x => x.IdSolicitud == solicitud.IdSolicitud);
                        if (solicitudConsultaRapida == null)
                        {
                            respuesta.Id = 0;
                            respuesta.Mensaje = "No se ha encontrado la solicitud en el sistema.";
                            return respuesta;
                        }
                        else
                        {
                            //Validar cupo
                            var listaSolicitudesPorDia = await Context.SolicitudesConsultaRapida.Where(x => x.IdEstado == 2 &&
                                                                                                                x.FechaCita.HasValue &&
                                                                                                                x.FechaCita.Value.ToString("yyyy-MM-dd") == solicitud.FechaCita.ToString("yyyy-MM-dd") &&
                                                                                                                x.HoraCita == solicitud.HoraCita.Descripcion &&
                                                                                                                x.IdMedico == solicitud.Medico.IdMedico)
                                                                                                .ToListAsync();
                            if (listaSolicitudesPorDia.Count > 0)
                            {
                                respuesta.Id = 0;
                                respuesta.Mensaje = "El cupo seleccionado ya ha sido asignado para otra solicitud. Elegir uno diferente";
                                return respuesta;
                            }
                            else
                            {
                                solicitudConsultaRapida.IdEstado = 2;
                                solicitudConsultaRapida.FechaAcepta = DateTime.Now;
                                solicitudConsultaRapida.IdUsuarioAcepta = solicitud.IdUsuario;
                                solicitudConsultaRapida.FechaCita = solicitud.FechaCita;
                                solicitudConsultaRapida.HoraCita = solicitud.HoraCita.Descripcion;
                                solicitudConsultaRapida.IdEspecialidad = solicitud.Especialidad.Id;
                                solicitudConsultaRapida.NombreEspecialidad = solicitud.Especialidad.Descripcion;
                                solicitudConsultaRapida.IdMedico = solicitud.Medico.IdMedico;
                                solicitudConsultaRapida.Medico = solicitud.Medico.Medico;

                                await Context.SaveChangesAsync();

                                respuesta.Id = 1;
                                respuesta.Mensaje = "El correo de su consulta presencial ha sido enviado con éxito!";

                                //Correo
                                using (StreamReader SourceReader = System.IO.File.OpenText("msg_reg_cita_sis.html"))
                                {
                                    MailMessage mailMessage = new MailMessage();

                                    string body = (SourceReader.ReadToEnd()).Replace("PacienteStr", $"{solicitudConsultaRapida.Nombres} {solicitudConsultaRapida.ApellidoPaterno}");
                                    body = body.Replace("FechaCitaStr", solicitudConsultaRapida.FechaCita.Value.ToString("dd/MM/yyyy"));
                                    body = body.Replace("HoraCitaStr", solicitudConsultaRapida.HoraCita);
                                    body = body.Replace("EspecialidadStr", solicitudConsultaRapida.NombreEspecialidad);

                                    AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                                    byte[] reader = File.ReadAllBytes("banner_cita_rapida.jpg");
                                    MemoryStream image1 = new MemoryStream(reader);

                                    LinkedResource headerImage = new LinkedResource(image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                                    headerImage.ContentId = "logoCitaWeb";
                                    headerImage.ContentType = new ContentType("image/jpg");
                                    av.LinkedResources.Add(headerImage);

                                    byte[] reader2 = File.ReadAllBytes("medico.jpg");
                                    MemoryStream image2 = new MemoryStream(reader2);

                                    LinkedResource headerImage2 = new LinkedResource(image2, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                                    headerImage2.ContentId = "medicoCitaWeb";
                                    headerImage2.ContentType = new ContentType("image/jpg");
                                    av.LinkedResources.Add(headerImage2);

                                    mailMessage.AlternateViews.Add(av);
                                    mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                                    mailMessage.To.Add(solicitud.CorreoElectronico);
                                    mailMessage.Subject = "INO CITAS EN LÍNEA - CONSULTA RAPIDA";
                                    mailMessage.IsBodyHtml = true;
                                    ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                                    AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                                    mailMessage.AlternateViews.Add(alternate);

                                    client.Send(mailMessage);
                                }
                            }



                        }
                    }
                }
                else
                {
                    SolicitudConsultaRapida solicitudConsultaRapida = await Context.SolicitudesConsultaRapida.FirstOrDefaultAsync(x => x.IdSolicitud == solicitud.IdSolicitud);
                    if (solicitudConsultaRapida == null)
                    {
                        respuesta.Id = 0;
                        respuesta.Mensaje = "No se ha encontrado la solicitud en el sistema.";
                        return respuesta;
                    }
                    else
                    {
                        solicitudConsultaRapida.MotivoRechazo = solicitud.MotivoRechazo;
                        solicitudConsultaRapida.IdUsuarioRechaza = solicitud.IdUsuario;
                        solicitudConsultaRapida.FechaRechazo = DateTime.Now;
                        solicitudConsultaRapida.IdEstado = 3; 
                        await Context.SaveChangesAsync();
                        respuesta.Id = 1;
                        respuesta.Mensaje = "La solicitud se ha rechazado de manera exitosa.";
                        return respuesta;
                    }
                }

                
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error del servidor";
            }

            return respuesta;
        }

        #region Comunes

        public async Task<IEnumerable<ComboBox>> ListarEspecialidadesPorFechaConsultaRapida(DateTime fechaCita)
        {
            var idMedico = 0;
            var idEspecialidad = 0;

            var list = await GalenContext.Query<ProgramacionMedicaFiltroView>()
                                        .FromSql("INO_ProgramacionMedicaPorFiltro @Fecha, @IdMedico, @IdEspecialidad",
                                        new SqlParameter("Fecha", fechaCita.Date),
                                        new SqlParameter("IdMedico", idMedico),
                                        new SqlParameter("IdEspecialidad", idEspecialidad))
                                        .ToListAsync();

            return list.Select(x => new ComboBox { Id = x.IdEspecialidad, Descripcion = x.Especialidad });
        }

        public async Task<IEnumerable<ComboBoxMedico>> ListarMedicosPorEspecialidadConsultaRapida(DateTime fechaCita, int idEspecialidad)
        {
            var idMedico = 0;
            var list = await GalenContext.Query<ProgramacionMedicaFiltroView>()
                                        .FromSql("INO_ProgramacionMedicaPorFiltro @Fecha, @IdMedico, @IdEspecialidad",
                                        new SqlParameter("Fecha", fechaCita.Date),
                                        new SqlParameter("IdMedico", idMedico),
                                        new SqlParameter("IdEspecialidad", idEspecialidad))
                                        .ToListAsync();

            return list.Select(x => new ComboBoxMedico { IdMedico = x.IdMedico, Medico = x.Medico, IdProgramacion = x.IdProgramacion });
        }

        public async Task<IEnumerable<ComboBox>> ListarCuposPorProgramacionConsultaRapida(int idProgramacion)
        {
            var list = await GalenContext.Query<CuposPorProgramacionView>()
                                        .FromSql("INO_ReprogramacionesCuposLibres @idProgramacion",
                                        new SqlParameter("idProgramacion", idProgramacion))
                                        .ToListAsync();

            return list.Select(x => new ComboBox { Id = (int)x.RowId, Descripcion = x.Cupo });
        }

        #endregion

    }
}
