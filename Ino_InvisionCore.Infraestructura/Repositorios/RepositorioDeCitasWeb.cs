// RepositorioDeCitasWeb.cs22:0122:01

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.CitasWeb;
using Ino_InvisionCore.Dominio.Entidades.ConsultaWeb_ConsultaRapida;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
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
                    
                    var parametroPacienteSalida = new SqlParameter
                    {
                        ParameterName = "IdPaciente",
                        SqlDbType = SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Output
                    };
                    
                    string sql = "EXEC dbo.Invision_CitasWeb_RegistrarPaciente @ApellidoPaterno,@ApellidoMaterno,@PrimerNombre," +
                                 "@FechaNacimiento,@NroDocumento,@Telefono,@DireccionDomicilio,@IdTipoSexo,@IdEstadoCivil," +
                                 "@IdDocIdentidad,@Email,@RegistroExitoso OUTPUT,@IdPaciente OUTPUT";
                    
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
                        parametroPacienteSalida);
                    var outParamValue = Convert.ToBoolean(parametroSalida.Value);
                    //if (!outParamValue)
                    //{
                    //    respuesta.Id = 0;
                    //    respuesta.Mensaje = "Registro sin éxito. El paciente ya existe.";
                    //    return respuesta;
                    //}
                
                    //Correo
                    MailMessage mailMessage = new MailMessage();

                    string body =
                        $"Sus credenciales de Accesso son -> Usuario: {solicitud.CorreoElectronico} Constraseña: {solicitud.NumeroDocumento}";
                    mailMessage.From = new MailAddress("noreply.inoinvision@gmail.com");
                    mailMessage.To.Add(solicitud.CorreoElectronico);
                    mailMessage.Subject = "INO CITAS WEB - Registro Paciente";
                    mailMessage.Body = body;
                    client.Send(mailMessage);
                    
                    
                    
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
                        IdRol = 23
                    };

                    _inoContext.PacientesCitaWeb.Add(pacienteCitaWeb);
                    await _inoContext.SaveChangesAsync();
                    
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
                                            FechaNacimiento = x.FechaNacimiento.ToString("yyyy-MM-dd"),
                                            Roles = new List<RolGeneral>{new RolGeneral{IdRol = x.Rol.IdRol, Nombre = x.Rol.Nombre, EsActivo = x.Rol.EsActivo}},
                                        })
                                        .FirstOrDefaultAsync();
            if (paciente != null)
            {
                paciente.Modulo = ObtenerMenu(paciente).Modulo;
            }
            return paciente;
        }

        public async Task<RespuestaBD> RegistrarConsultaRapida(RegistrarConsultaRapida solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

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
                            x.NumeroDocumento == pacienteGalenos.NumeroDocumento);

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
                        OrigenPaciente = "CITA WEB"
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
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                await _galenosContext.Database.ExecuteSqlCommandAsync("dbo.Invision_CitasWeb_RegistrarCita @IdProgramacion,@IdPaciente,@HoraInicio,@HoraFin",
                    new SqlParameter("IdProgramacion", solicitud.IdProgramacion),
                    new SqlParameter("IdPaciente", solicitud.IdPaciente),
                    new SqlParameter("HoraInicio", solicitud.HoraInicio),
                    new SqlParameter("HoraFin", solicitud.HoraFin));

                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se ha registrado la cita correctamente.";
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
            List<SubModuloMenu> subModulos = (from e in _inoContext.Roles
                                              join rsm in _inoContext.RolSubModulo on e.IdRol equals rsm.IdRol
                                              join sm in _inoContext.SubModulo on rsm.IdSubModulo equals sm.IdSubModulo
                                              //where e.Empleado.Any(x => x.IdEmpleado == usuarioLogin.IdEmpleado)
                                              where e.PacienteCitaWeb.Id == usuarioLogin.IdPacienteInvision
                                              && rsm.EsActivo == true
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

            List<ModuloMenu> modulos = (from e in _inoContext.Roles
                                        join rsm in _inoContext.RolSubModulo on e.IdRol equals rsm.IdRol
                                        join sm in _inoContext.SubModulo on rsm.IdSubModulo equals sm.IdSubModulo
                                        join m in _inoContext.Modulo on sm.IdModulo equals m.IdModulo
                                        //where e.Empleado.Any(x => x.IdEmpleado == usuarioLogin.IdEmpleado)
                                        where e.PacienteCitaWeb.Id == usuarioLogin.IdPacienteInvision
                                              && rsm.EsActivo == true
                                        select new ModuloMenu
                                        {
                                            IdModulo = m.IdModulo,
                                            Modulo = m.Nombre,
                                            Icono = m.Icono,
                                            Orden = m.Orden,
                                        }).Distinct().OrderBy(x => x.Orden).ToList();

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
    }
}