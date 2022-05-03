// RepositorioDeCitasWeb.cs22:0122:01

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.CitasWeb;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.CitasWeb;
using Ino_InvisionCore.Dominio.Entidades.ConsultaWeb_ConsultaRapida;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Newtonsoft.Json;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeCitasWeb : IRepositorioDeCitasWeb
    {
        private readonly GalenPlusContext _galenosContext;
        private readonly InoContext _inoContext;
        
        public RepositorioDeCitasWeb(GalenPlusContext galenosContext, InoContext inoContext)
        {
            _galenosContext = galenosContext;
            _inoContext = inoContext;
        }
        
        public async Task<RespuestaBD> RegistrarPaciente(RegistrarPacienteDto solicitud)
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
            using (var httpClient = new HttpClient())
            {
                try
                {
                    // Validar si ya existe un paciente registrado

                    var pacienteDb = await _inoContext.PacientesCitaWeb.FirstOrDefaultAsync(x => x.NumeroDocumento == solicitud.NumeroDocumento && x.Usuario == solicitud.CorreoElectronico);
                    if (pacienteDb != null)
                    {
                        //Envio de correo con credenciales

                        MailMessage mailMessage = new MailMessage();

                        mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                        mailMessage.To.Add(pacienteDb.CorreoElectronico);
                        mailMessage.Subject = "INO CITAS EN LÍNEA - REGISTRO PACIENTE";
                        mailMessage.IsBodyHtml = false;
                        mailMessage.Body = $"Sus credenciales de usuario son: Usuario -> {pacienteDb.Usuario} Contraseña -> {pacienteDb.NumeroDocumento}";

                        client.Send(mailMessage);

                        return new RespuestaBD { Id = 0, Mensaje = "Ud ya se encuentra registrado en el sistema. Sus credenciales serán enviadas al correo que se registró anteriormente." };
                    }


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

                        if (solicitud.FechaEmision.ToString("dd/MM/yyyy") != fecEmision)
                        {
                            respuesta.Id = 0;
                            respuesta.Mensaje = "La fecha de emision ingresada no coincide con RENIEC";
                            return respuesta;
                        }
                    }
                    
                    //TODO: Validacion De si ya esta registrado
                    
                    var parametroSalida = new SqlParameter
                    {
                        ParameterName = "RegistroExitoso",
                        SqlDbType = SqlDbType.Bit,
                        Direction = System.Data.ParameterDirection.Output
                    };
                    
                    var parametroPacienteSalida = new SqlParameter
                    {
                        ParameterName = "IdPaciente",
                        SqlDbType = SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Output
                    };
                    
                    string sql = "EXEC dbo.Invision_CitasWeb_RegistrarPaciente @ApellidoPaterno,@ApellidoMaterno,@PrimerNombre," +
                                 "@FechaNacimiento,@NroDocumento,@Telefono,@DireccionDomicilio,@IdTipoSexo,@IdEstadoCivil," +
                                 "@IdDocIdentidad,@Email,@RegistroExitoso OUTPUT,@IdPaciente OUTPUT, @IdDistritoDomicilio, @IdTipoOcupacion, @IdGradoInstruccion";
                    
                    await _galenosContext.Database.ExecuteSqlCommandAsync(sql,
                        new SqlParameter("ApellidoPaterno", solicitud.ApellidoPaterno),
                        new SqlParameter("ApellidoMaterno", solicitud.ApellidoMaterno),
                        new SqlParameter("PrimerNombre", solicitud.Nombres),
                        new SqlParameter("FechaNacimiento", solicitud.FechaNacimiento),
                        new SqlParameter("NroDocumento", solicitud.NumeroDocumento),
                        new SqlParameter("Telefono", solicitud.TelefonoMovil),
                        new SqlParameter("DireccionDomicilio", solicitud.Direccion),
                        new SqlParameter("IdTipoSexo", solicitud.IdSexo),
                        new SqlParameter("IdEstadoCivil", solicitud.IdEstadoCivil),
                        new SqlParameter("IdDocIdentidad", solicitud.IdTipoDocumento),
                        new SqlParameter("Email", solicitud.CorreoElectronico),
                        parametroSalida,
                        parametroPacienteSalida,
                        new SqlParameter("IdDistritoDomicilio", solicitud.IdDistritoDomicilio),
                        new SqlParameter("IdTipoOcupacion", solicitud.IdTipoOcupacion),
                        new SqlParameter("IdGradoInstruccion", solicitud.IdGradoInstruccion));
                    var outParamValue = Convert.ToBoolean(parametroSalida.Value);
                    //if (!outParamValue)
                    //{
                    //    respuesta.Id = 0;
                    //    respuesta.Mensaje = "Registro sin éxito. El paciente ya existe.";
                    //    return respuesta;
                    //}

                    //Registrar Paciente en Invision
                    PacienteCitaWeb pacienteCitaWeb = new PacienteCitaWeb
                    {
                        IdPacienteGalenos = Convert.ToInt32(parametroPacienteSalida.Value),
                        ApellidoPaterno = solicitud.ApellidoPaterno,
                        ApellidoMaterno = solicitud.ApellidoMaterno,
                        Nombres = solicitud.Nombres,
                        FechaNacimiento = solicitud.FechaNacimiento,
                        NumeroDocumento = solicitud.NumeroDocumento,
                        TelefonoMovil = solicitud.TelefonoMovil,
                        Direccion = solicitud.Direccion,
                        IdSexo = solicitud.IdSexo,
                        IdEstadoCivil = solicitud.IdEstadoCivil,
                        IdTipoDocumento = solicitud.IdTipoDocumento,
                        CorreoElectronico = solicitud.CorreoElectronico,
                        Usuario = solicitud.CorreoElectronico,
                        Contrasena = Security.HashSHA1(solicitud.NumeroDocumento),
                        IdRol = 23,
                        IdDistritoDomicilio = solicitud.IdDistritoDomicilio,
                        IdTipoOcupacion = solicitud.IdTipoOcupacion,
                        IdGradoInstruccion = solicitud.IdGradoInstruccion
                    };

                    _inoContext.PacientesCitaWeb.Add(pacienteCitaWeb);
                    await _inoContext.SaveChangesAsync();

                    //Correo
                    using (StreamReader SourceReader = System.IO.File.OpenText("msg_reg_paciente.html"))
                    {
                        MailMessage mailMessage = new MailMessage();

                        string body = (SourceReader.ReadToEnd()).Replace("PacienteStr", $"{solicitud.Nombres} {solicitud.ApellidoPaterno} {solicitud.ApellidoMaterno}");
                        body = body.Replace("UsuarioStr", pacienteCitaWeb.Usuario);
                        body = body.Replace("ContrasenaStr", solicitud.NumeroDocumento);

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
                        mailMessage.Subject = "INO CITAS EN LÍNEA - REGISTRO PACIENTE";
                        mailMessage.IsBodyHtml = true;
                        ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                        AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                        mailMessage.AlternateViews.Add(alternate);

                        client.Send(mailMessage);
                    }
                    
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Registro exitoso! Se le enviará un correo con sus credenciales de acceso.";
                }
                catch (Exception e)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Error en el servidor.";
                }

            }

            
            return respuesta;
        }

        public async Task<PacienteCitaWebLogin> Login(string usuario, string contrasena)
        {
            
            PacienteCitaWebLogin paciente = await _inoContext.PacientesCitaWeb
                                        .Include(x => x.Rol)
                                        .Where(x => x.Usuario == usuario && x.Contrasena == contrasena && x.EsActivo == true)
                                        .Select(x => new PacienteCitaWebLogin
                                        {
                                            IdPacienteInvision = x.Id,
                                            IdPacienteGalenos = x.IdPacienteGalenos,
                                            ApellidoPaterno = x.ApellidoPaterno,
                                            Nombres = x.Nombres,
                                            Usuario = x.Usuario,
                                            NumeroDocumento = x.NumeroDocumento,
                                            FechaNacimiento = x.FechaNacimiento.ToString("yyyy-MM-dd"),
                                            Roles = new List<RolGeneral>{new RolGeneral{IdRol = x.Rol.IdRol, Nombre = x.Rol.Nombre, EsActivo = x.Rol.EsActivo}},
                                        })
                                        .FirstOrDefaultAsync();
            if (paciente != null)
            {
                // Validar si tiene sis
                paciente.EsSis = await EsSIS(paciente.NumeroDocumento);
                paciente.Modulo = ObtenerMenu(paciente).Modulo;
            }
            return paciente;
        }

        public async Task<RespuestaBD> RegistrarConsultaRapida(RegistrarConsultaRapida solicitud)
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
            
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var pacienteGalenos = await _galenosContext.Query<PacienteCitaWebView>().FromSql(
                        "dbo.Invision_CitasWeb_ObtenerDatosPaciente @IdPacienteGalenos",
                        new SqlParameter("IdPacienteGalenos", solicitud.IdPacienteGalenos)
                    ).FirstOrDefaultAsync();

                    if (pacienteGalenos != null)
                    {
                        var solicitudDia =
                            await _inoContext.SolicitudesConsultaRapida.FirstOrDefaultAsync(x =>
                                x.NumeroDocumento == pacienteGalenos.NumeroDocumento && x.FechaCreacion.Date == DateTime.Now.Date);

                        if (solicitudDia != null)
                        {
                            respuesta.Id = 0;
                            respuesta.Mensaje =
                                "Registro sin éxito. El paciente ya tiene registrado una solicitud para el día de hoy.";
                            return respuesta;
                        }
                        
                        SolicitudConsultaRapida solicitudConsultaRapida = new SolicitudConsultaRapida
                        {
                            ApellidoPaterno = pacienteGalenos.ApellidoPaterno,
                            ApellidoMaterno = pacienteGalenos.ApellidoMaterno,
                            Nombres = pacienteGalenos.Nombres,
                            IdTipoDocumento = pacienteGalenos.IdTipoDocumento,
                            NumeroDocumento = pacienteGalenos.NumeroDocumento,
                            CorreoElectronico = pacienteGalenos.CorreoElectronico,
                            TelefonoMovil = pacienteGalenos.TelefonoMovil,
                            IdEstadoCivil = pacienteGalenos.IdEstadoCivil,
                            FechaNacimiento = pacienteGalenos.FechaNacimiento,
                            IdSexo = pacienteGalenos.IdSexo,
                            IdDepartamento = pacienteGalenos.IdDepartamento,
                            IdProvincia = pacienteGalenos.IdProvincia,
                            IdDistrito = pacienteGalenos.IdDepartamento,
                            Direccion = pacienteGalenos.Direccion,
                            MotivoConsulta = solicitud.MotivoConsulta,
                            NumeroReferencia = solicitud.NumeroReferencia,
                            IdEstado = 0,
                            FechaCreacion = DateTime.Now,
                            IdUsuarioCreacion = solicitud.IdUsuarioCreacion,
                            OrigenPaciente = "CITA WEB",
                            ImagenReferencia = solicitud.RutaCompleta
                        };

                        _inoContext.SolicitudesConsultaRapida.Add(solicitudConsultaRapida);
                        await _inoContext.SaveChangesAsync();

                        
                        respuesta.Id = 1;
                        respuesta.Mensaje = "Su registro se ha registrado con éxito. El personal del instituto se comunicará a la brevedad para la validación de su hoja de referencia";
                    }
                }
                catch (Exception e)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Error en el servidor";
                }
            }
            return respuesta;
        }

        public async Task<IEnumerable<CuposProgramacionDto>> ListarCuposProgramacion(DateTime fecha, int idEspecialidad)
        {
            var cuposSql = await _galenosContext.Query<CupoProgramacionView>().FromSql(
                "dbo.Invision_CitasWeb_CuposPorProgramacionMedica @Fecha, @IdEspecialidad",
                new SqlParameter("Fecha", fecha),
                new SqlParameter("IdEspecialidad", idEspecialidad))
                .ToListAsync();

            return cuposSql.GroupBy(c => new
            {
                c.IdProgramacion,
                c.IdEspecialidad,
                c.Especialidad,
                c.IdServicio,
                c.Servicio,
                c.IdMedico,
                c.Medico
            }).Select(cf => new CuposProgramacionDto
            {
                IdProgramacion = cf.Key.IdProgramacion,
                IdEspecialidad = cf.Key.IdEspecialidad,
                Especialidad = cf.Key.Especialidad,
                IdServicio = cf.Key.IdServicio,
                Servicio = cf.Key.Servicio,
                IdMedico = cf.Key.IdMedico,
                Medico = cf.Key.Medico,
                Cupos = cf.Select(cp => new CupoDto
                {
                    HoraInicio = cp.HoraInicio,
                    HoraFin = cp.HoraFin,
                    Estado = cp.Estado
                }).ToList()
            });
        }

        public async Task<string[]> ListarFechasProgramacion(int idMedico, int idEspecialidad)
        {
            var cuposSql = await _galenosContext.Query<FechaProgramacionView>().FromSql(
                    "dbo.Invision_CitasWeb_ProgramacionMedica @IdMedico, @IdEspecialidad",
                    new SqlParameter("IdMedico", idMedico), new SqlParameter("IdEspecialidad", idEspecialidad))
                .Select(x => x.Fecha.ToString("yyyy-MM-dd"))
                .ToListAsync();

            return cuposSql.ToArray();
        }

        public async Task<RespuestaBD> RegitrarCita(RegistrarCitaWeb solicitud)
        {
            // Validar que no pueda dar dos citas mismo dia
            var citadb = await _inoContext.CitasWeb.FirstOrDefaultAsync(x => x.IdPaciente == solicitud.IdPaciente &&
                                                                                    x.FechaSolicitud.Date == DateTime.Now.Date);

            if (citadb != null)
            {
                return new RespuestaBD { Id = 0, Mensaje = "Ud ya ha solicitado una cita el día de hoy." };
            }

            string[] arrMail = new string[6] { "noreply6.inoinvision@gmail.com", "noreply5.inoinvision@gmail.com", "noreply4.inoinvision@gmail.com",
                                                    "noreply3.inoinvision@gmail.com", "noreply2.inoinvision@gmail.com", "noreply.inoinvision@gmail.com"};

            int intento = 0;
            bool exito = false;

            RespuestaBD respuesta = new RespuestaBD();
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(arrMail[0], "P@sw0rd00!");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.DeliveryFormat = SmtpDeliveryFormat.International;
            client.Port = 587;
            client.Timeout = 20000;
            
            try
            {
                await _galenosContext.Database.ExecuteSqlCommandAsync("dbo.Invision_CitasWeb_RegistrarCita @IdProgramacion,@IdPaciente,@HoraInicio,@HoraFin,@TipoComprobante,@Ruc,@Direccion,@RazonSocial",
                    new SqlParameter("IdProgramacion", solicitud.IdProgramacion),
                    new SqlParameter("IdPaciente", solicitud.IdPaciente),
                    new SqlParameter("HoraInicio", solicitud.HoraInicio),
                    new SqlParameter("HoraFin", solicitud.HoraFin),
                    new SqlParameter("TipoComprobante", solicitud.TipoComprobante.Descripcion),
                    new SqlParameter("Ruc", solicitud.Ruc),
                    new SqlParameter("Direccion", solicitud.Direccion),
                    new SqlParameter("RazonSocial", solicitud.RazonSocial));
                    
                //Obtener CitaWeb Invision
                CitaWeb citaWeb = await _inoContext.CitasWeb.FirstOrDefaultAsync(x => x.IdPaciente == solicitud.IdPaciente &&
                                                                                    x.IdProgramacion == solicitud.IdProgramacion
                                                                                    && x.HoraInicio == solicitud.HoraInicio
                                                                                    && x.HoraFin == solicitud.HoraFin);
                using (var httpClient = new HttpClient())
                {
                    if (citaWeb != null)
                    {
                        //Obtener Paciente
                        PacienteCitaWeb pacienteCitaWeb =
                            await _inoContext.PacientesCitaWeb.FirstOrDefaultAsync(x => x.IdPacienteGalenos == citaWeb.IdPaciente);
                        
                        while (!exito)
                        {
                            try
                            {
                                //Correo
                                using (StreamReader SourceReader = System.IO.File.OpenText("msg_reg_cita_pagantes.html"))
                                {
                                    MailMessage mailMessage = new MailMessage();

                                    string body = (SourceReader.ReadToEnd()).Replace("PacienteStr", $"{citaWeb.Paciente}");
                                    body = body.Replace("FechaCitaStr", citaWeb.Fecha.ToString("dd/MM/yyyy"));
                                    body = body.Replace("HoraCitaStr", citaWeb.HoraInicio);
                                    body = body.Replace("EspecialidadStr", citaWeb.Especialidad);
                                    body = body.Replace("FechaLimiteStr", citaWeb.FechaSolicitud.AddDays(1).ToString("dd/MM/yyyy"));
                                    body = body.Replace("IdCitaStr", citaWeb.IdCita.ToString());

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
                                    mailMessage.From = new MailAddress(arrMail[intento]);
                                    mailMessage.To.Add(pacienteCitaWeb.CorreoElectronico);
                                    mailMessage.Subject = "INO CITAS EN LÍNEA - REGISTRO CITA PAGANTE";
                                    mailMessage.IsBodyHtml = true;
                                    ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                                    AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                                    mailMessage.AlternateViews.Add(alternate);

                                    await client.SendMailAsync(mailMessage);

                                    exito = true;
                                }
                            }
                            catch (Exception)
                            {
                                intento++;
                                new SmtpClient("smtp.gmail.com");
                                client.UseDefaultCredentials = false;
                                client.Credentials = new NetworkCredential(arrMail[intento], "P@sw0rd00!");
                                client.EnableSsl = true;
                                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                client.DeliveryFormat = SmtpDeliveryFormat.International;
                                client.Port = 587;
                                client.Timeout = 20000;
                            }
                        }

                        
                    
                        respuesta.Id = 1;
                        respuesta.Mensaje = "Se ha registrado la cita correctamente.";
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        public async Task<IEnumerable<CitaWebDto>> ListarCitasdWebPorPaciente(int idPaciente)
        {
            return await _inoContext.CitasWeb.Where(x => x.IdPaciente == idPaciente && (x.IdEstado == 1 || x.IdEstado == 3))
                                             .OrderByDescending(x => x.Fecha)
                                            .Select(x => Mapper.Map<CitaWebDto>(x))
                                            .ToListAsync();
        }

        public async Task<RespuestaBD> SubirVouchersACita(SubirVoucherDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                //1. Buscar Cita
                CitaWeb citaWeb = await _inoContext.CitasWeb.FirstOrDefaultAsync(x => x.IdCita == solicitud.IdCita);

                if (citaWeb == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado la cita.";
                    return respuesta;
                }
                else
                {
                    //2. Actualizar Cita
                    citaWeb.Voucher = solicitud.Voucher;
                    citaWeb.ImagenVoucher = solicitud.RutaCompleta;
                    citaWeb.FechaPago = solicitud.FechaPago;
                    citaWeb.FechaSubirVoucher = DateTime.Now;
                    await _inoContext.SaveChangesAsync();
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se ha subido el voucher correctamente!";
                }
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor.";
                return respuesta;
            }
            return respuesta;
        }

        public async Task<string> EliminarVoucher(int idCita)
        {
            // Obtener Cita
            CitaWeb cita = await _inoContext.CitasWeb.FirstOrDefaultAsync(x => x.IdCita == idCita);

            if (cita == null)
                return null;
            else
            {
                // Nullear campos de Cita
                var ruta = cita.ImagenVoucher;
                cita.ImagenVoucher = null;
                await _inoContext.SaveChangesAsync();
                return ruta;
            }
        }

        public async Task<IEnumerable<CitaWebDto>> ListarCitasWebPorFecha(DateTime? fechaPagoDesde, DateTime? fechaPagoHasta, DateTime? fechaCitaDesde, DateTime? fechaCitaHasta)
        {
            if (fechaCitaDesde.HasValue && fechaCitaHasta.HasValue)
            {
                //Fecha de Cita
                return await _inoContext.CitasWeb.Where(x => x.Fecha.Date >= fechaCitaDesde.Value.Date && x.Fecha.Date <= fechaCitaHasta.Value.Date
                                                    && (x.IdEstado == 1 || x.IdEstado == 3))
                .Select(x => Mapper.Map<CitaWebDto>(x))
                .ToListAsync();
            }
            else
            {
                //Fecha de Pago
                return await _inoContext.CitasWeb.Where(x => x.FechaPago.Value.Date >= fechaPagoDesde.Value.Date && x.FechaPago.Value.Date <= fechaPagoHasta.Value.Date
                                                    && !string.IsNullOrEmpty(x.ImagenVoucher) && !x.VoucherValido.HasValue
                                                    && (x.IdEstado == 1 || x.IdEstado == 3))
                .Select(x => Mapper.Map<CitaWebDto>(x))
                .ToListAsync();
            }
            
        }

        public async Task<RespuestaBD> ValidarVoucher(ValidarVoucherDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                //1. Obtener CitaWeb
                CitaWeb cita = await _inoContext.CitasWeb.FirstOrDefaultAsync(x => x.IdCita == solicitud.IdCita);

                if (cita == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado la cita.";
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

                    //2. Actualizar Datos CitaWeb
                    cita.VoucherValido = true;
                    cita.FechaValidacionVoucher = DateTime.Now;
                    cita.IdUsuarioValidaVoucher = solicitud.IdUsuario;
                    cita.NroComprobante = solicitud.NroComprobante;
                    cita.FechaEmisionComprobante = solicitud.FechaEmisionComprobante;
                    
                    //3. Persistencia
                    await _inoContext.SaveChangesAsync();

                    //obtener paciente
                    var pacienteDb = await _inoContext.PacientesCitaWeb.FirstOrDefaultAsync(x => x.IdPacienteGalenos == cita.IdPaciente);
                    if (pacienteDb != null)
                    {
                        //Enviar correo

                        //Envio de correo con credenciales

                        using (var httpClient = new HttpClient())
                        {
                            MailMessage mailMessage = new MailMessage();

                            mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                            mailMessage.To.Add(pacienteDb.CorreoElectronico);
                            mailMessage.Subject = "INO CITAS EN LÍNEA - VALIDACIÓN DE PAGO";
                            mailMessage.IsBodyHtml = false;
                            mailMessage.Body = $"El pago de su cita para la fecha: {cita.Fecha.ToString("dd/MM/yyyy")} para la especialidad: {cita.Especialidad} ha sido validado. Acercarse en la fecha correspondiente.";

                            client.Send(mailMessage);
                        }
                    }      

                    //4. Mensage
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Voucher validado correctamente!";
                }
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }
        public async Task<RespuestaBD> RechazarVoucher(RechazarVoucherDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                //1. Obtener CitaWeb
                CitaWeb cita = await _inoContext.CitasWeb.FirstOrDefaultAsync(x => x.IdCita == solicitud.IdCita);

                if (cita == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado la cita.";
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

                    //2. Actualizar Datos CitaWeb
                    cita.IdEstado = 2;
                    cita.FechaRechazoVoucher = DateTime.Now;
                    cita.IdUsuarioRechazoVoucher = solicitud.IdUsuario;
                    cita.MotivoRechazoVoucher = solicitud.MotivoRechazo;

                    // Ejecutar SP
                    var outputParam = new SqlParameter();
                    outputParam.ParameterName = "IdResultado";
                    outputParam.DbType = DbType.Int32;
                    outputParam.Direction = ParameterDirection.Output;

                    await _galenosContext.Database.ExecuteSqlCommandAsync("dbo.Invision_EliminarCitaGalenos @IdCuentaAtencion, @IdResultado",
                    new SqlParameter("IdCuentaAtencion", cita.IdCuentaAtencion),
                    outputParam);

                    //3. Persistencia
                    await _inoContext.SaveChangesAsync();

                    //obtener paciente
                    var pacienteDb = await _inoContext.PacientesCitaWeb.FirstOrDefaultAsync(x => x.IdPacienteGalenos == cita.IdPaciente);
                    if (pacienteDb != null)
                    {
                        //Enviar correo

                        //Envio de correo con credenciales

                        using (var httpClient = new HttpClient())
                        {
                            using (StreamReader SourceReader = System.IO.File.OpenText("msg_cita_rechazada.html"))
                            {
                                MailMessage mailMessage = new MailMessage();

                                string body = (SourceReader.ReadToEnd()).Replace("PacienteStr", $"{pacienteDb.Nombres} {pacienteDb.ApellidoPaterno} {pacienteDb.ApellidoMaterno}");
                                body = body.Replace("MotivoStr", solicitud.MotivoRechazo);
          

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
                                mailMessage.To.Add(pacienteDb.CorreoElectronico);
                                mailMessage.Subject = "INO CITAS EN LÍNEA - RECHAZO DE CITA";
                                mailMessage.IsBodyHtml = true;
                                ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                                AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
                                mailMessage.AlternateViews.Add(alternate);

                                client.Send(mailMessage);
                            }
                        }
                    }

                    //4. Mensage
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Cita rechazada correctamente!";
                }
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EliminarCita(EliminarCitaDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                //1. Obtener cita
                CitaWeb cita = await _inoContext.CitasWeb.FirstOrDefaultAsync(x => x.IdCita == solicitud.IdCita);

                if (cita == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado la cita";
                }
                else
                {
                    //2. Actualizar estado cita
                    cita.IdEstado = 0;
                    cita.IdUsuarioElimina = solicitud.IdUsuario;
                    cita.FechaEliminacionCita = DateTime.Now;
                    await _inoContext.SaveChangesAsync();
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Cita eliminada correctamente!";
                }
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        private PacienteCitaWebLogin ObtenerMenu(PacienteCitaWebLogin usuarioLogin)
        {
            List<SubModuloMenu> subModulos = new List<SubModuloMenu>();

            List<ModuloMenu> modulos = new List<ModuloMenu>();
            if (!usuarioLogin.EsSis)
            {
                subModulos = (from e in _inoContext.Roles
                                                  join rsm in _inoContext.RolSubModulo on e.IdRol equals rsm.IdRol
                                                  join sm in _inoContext.SubModulo on rsm.IdSubModulo equals sm.IdSubModulo
                                                  //where e.Empleado.Any(x => x.IdEmpleado == usuarioLogin.IdEmpleado)
                                                  where e.PacientesCitaWeb.Any(p => p.Id == usuarioLogin.IdPacienteInvision)
                                                  && rsm.EsActivo == true && sm.IdSubModulo != 2065
                                                  orderby sm.Orden ascending
                                                  select new SubModuloMenu
                                                  {
                                                      IdSubModulo = sm.IdSubModulo,
                                                      IdModulo = sm.IdModulo,
                                                      SubModulo = sm.Nombre,
                                                      Ruta = sm.Ruta,
                                                      Orden = sm.Orden,
                                                      Ver = rsm.Ver,
                                                      Agregar = rsm.Agregar,
                                                      Editar = rsm.Editar,
                                                      Eliminar = rsm.Eliminar
                                                  }).ToList();

                modulos = (from e in _inoContext.Roles
                                            join rsm in _inoContext.RolSubModulo on e.IdRol equals rsm.IdRol
                                            join sm in _inoContext.SubModulo on rsm.IdSubModulo equals sm.IdSubModulo
                                            join m in _inoContext.Modulo on sm.IdModulo equals m.IdModulo
                                            //where e.Empleado.Any(x => x.IdEmpleado == usuarioLogin.IdEmpleado)
                                            where e.PacientesCitaWeb.Any(p => p.Id == usuarioLogin.IdPacienteInvision)
                                                  && rsm.EsActivo == true && sm.IdSubModulo != 2065
                                            select new ModuloMenu
                                            {
                                                IdModulo = m.IdModulo,
                                                Modulo = m.Nombre,
                                                Icono = m.Icono,
                                                Orden = m.Orden,
                                            }).Distinct().OrderBy(x => x.Orden).ToList();
            }
            else
            {
                subModulos = (from e in _inoContext.Roles
                                                  join rsm in _inoContext.RolSubModulo on e.IdRol equals rsm.IdRol
                                                  join sm in _inoContext.SubModulo on rsm.IdSubModulo equals sm.IdSubModulo
                                                  //where e.Empleado.Any(x => x.IdEmpleado == usuarioLogin.IdEmpleado)
                                                  where e.PacientesCitaWeb.Any(p => p.Id == usuarioLogin.IdPacienteInvision)
                                                  && rsm.EsActivo == true && sm.IdSubModulo != 35
                                                  orderby sm.Orden ascending
                                                  select new SubModuloMenu
                                                  {
                                                      IdSubModulo = sm.IdSubModulo,
                                                      IdModulo = sm.IdModulo,
                                                      SubModulo = sm.Nombre,
                                                      Ruta = sm.Ruta,
                                                      Orden = sm.Orden,
                                                      Ver = rsm.Ver,
                                                      Agregar = rsm.Agregar,
                                                      Editar = rsm.Editar,
                                                      Eliminar = rsm.Eliminar
                                                  }).ToList();

                modulos = (from e in _inoContext.Roles
                                            join rsm in _inoContext.RolSubModulo on e.IdRol equals rsm.IdRol
                                            join sm in _inoContext.SubModulo on rsm.IdSubModulo equals sm.IdSubModulo
                                            join m in _inoContext.Modulo on sm.IdModulo equals m.IdModulo
                                            //where e.Empleado.Any(x => x.IdEmpleado == usuarioLogin.IdEmpleado)
                                            where e.PacientesCitaWeb.Any(p => p.Id == usuarioLogin.IdPacienteInvision)
                                                  && rsm.EsActivo == true && sm.IdSubModulo != 35
                                            select new ModuloMenu
                                            {
                                                IdModulo = m.IdModulo,
                                                Modulo = m.Nombre,
                                                Icono = m.Icono,
                                                Orden = m.Orden,
                                            }).Distinct().OrderBy(x => x.Orden).ToList();
            }
            

            List<ModuloMenu> menuModulo = modulos
                .Select(x => new ModuloMenu
                {
                    IdModulo = x.IdModulo,
                    Modulo = x.Modulo,
                    Icono = x.Icono,
                    Orden = x.Orden,
                    SubModulo = subModulos.Where(y => y.IdModulo == x.IdModulo).ToList()
                }).ToList();

            usuarioLogin.Modulo = menuModulo;
            return usuarioLogin;
        }

        public async Task<bool> EsSIS(string nroDocumento)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    string responseStr = null;

                    var server = "http://invision.ino.gob.pe:8085/";
                    var url = server + "api/ConsultaWeb/";
                    var method = "BuscarAseguradoSIS?";
                    var parameters = "nroDocumento=" + nroDocumento;
                    var uri = url + method + parameters;
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        responseStr = JsonConvert.DeserializeObject<string>(apiResponse);
                    }
                    return !string.IsNullOrEmpty(responseStr);
                }
                catch (Exception)
                {
                    return false;
                }
                
            }
        }

        public async Task<IEnumerable<ComboBox>> ListarCajerosAsync()
        {
            return await _galenosContext.Query<ComboBoxView>().FromSql("dbo.Invision_CajerosCitasWebSeleccionarTodos")
                            .Select(x => Mapper.Map<ComboBox>(x))
                            .ToListAsync();
        }
    }
}
