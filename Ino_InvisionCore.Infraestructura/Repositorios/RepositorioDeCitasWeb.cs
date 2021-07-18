// RepositorioDeCitasWeb.cs22:0122:01

using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.CitasWeb;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Mail;
using Newtonsoft.Json;

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
                    
                    await _galenosContext.Database.ExecuteSqlCommandAsync("dbo.Invision_CitasWeb_RegistrarPaciente @ApellidoPaterno,@ApellidoMaterno,@PrimerNombre," +
                                                                          "@FechaNacimiento,@NroDocumento,@Telefono,@DireccionDomicilio,@IdTipoSexo,@IdEstadoCivil," +
                                                                          "@IdDocIdentidad,@Email,@RegistroExitoso OUTPUT",
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
                        parametroSalida);
                    var outParamValue = Convert.ToBoolean(parametroSalida.Value);
                    if (!outParamValue)
                    {
                        respuesta.Id = 0;
                        respuesta.Mensaje = "Registro sin éxito. El paciente ya existe.";
                    }
                
                    //Correo
                    MailMessage mailMessage = new MailMessage();

                    string body =
                        $"Sus credenciales de Accesso son -> Email: {solicitud.CorreoElectronico} Doc. Identidad: {solicitud.NumeroDocumento}";
                    mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                    mailMessage.To.Add(solicitud.CorreoElectronico);
                    mailMessage.Subject = "INO CITAS WEB - Registro Paciente";
                    client.Send(mailMessage);
                
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Registro exitoso!";
                }
                catch (Exception e)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Error en el servidor.";
                }

            }

            
            return respuesta;
        }
    }
}