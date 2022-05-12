using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Ticket.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Ticket;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeTickets : IRepositorioDeTickets   
    {
        private readonly InoContext InoContext;
        private readonly GalenPlusContext GalenPlusContext;

        public RepositorioDeTickets(InoContext inoContext, GalenPlusContext galenPlusContext)
        {
            InoContext = inoContext;
            GalenPlusContext = galenPlusContext;
        }

        public RespuestaBD ActualizarNroHistoriaClinicaTemporal(ActualizarHistoriaClinicaTemporal actualizarHistoriaClinicaTemporal)
        {
            RespuestaBD respuesta = new RespuestaBD();

            //int HistoricaClinica = GalenPlusContext.Database.SqlQuery<int>("dbo.INO_ActualizarNroHistoriaClinicaTemporal @AntiguoHC,@Hc,@IdUsuario,@IdTipoNumeracion,@IdPaciente,@IdManual",
            //            new SqlParameter("AntiguoHC", actualizarHistoriaClinicaTemporal.AntiguaHistoriaClinica),
            //            new SqlParameter("Hc", actualizarHistoriaClinicaTemporal.HistoriaClinica),
            //            new SqlParameter("IdUsuario", actualizarHistoriaClinicaTemporal.IdUsuario),
            //            new SqlParameter("IdTipoNumeracion", actualizarHistoriaClinicaTemporal.IdTipoNumeracion),
            //            new SqlParameter("IdPaciente", actualizarHistoriaClinicaTemporal.IdPaciente),
            //            new SqlParameter("IdManual", actualizarHistoriaClinicaTemporal.IdManual)).FirstOrDefault();

            int HistoricaClinica = GalenPlusContext.Query<ActualizarNroHistoriaClinicaTemporalView>().FromSql("dbo.INO_ActualizarNroHistoriaClinicaTemporal @AntiguoHC,@Hc,@IdUsuario,@IdTipoNumeracion,@IdPaciente,@IdManual",
                        new SqlParameter("AntiguoHC", actualizarHistoriaClinicaTemporal.AntiguaHistoriaClinica),
                        new SqlParameter("Hc", actualizarHistoriaClinicaTemporal.HistoriaClinica),
                        new SqlParameter("IdUsuario", actualizarHistoriaClinicaTemporal.IdUsuario),
                        new SqlParameter("IdTipoNumeracion", actualizarHistoriaClinicaTemporal.IdTipoNumeracion),
                        new SqlParameter("IdPaciente", actualizarHistoriaClinicaTemporal.IdPaciente),
                        new SqlParameter("IdManual", actualizarHistoriaClinicaTemporal.IdManual)).FirstOrDefault().HcMaximo;

            //Mensaje de respuesta
            respuesta.Id = HistoricaClinica;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public async Task<RespuestaBD> ActualizarNroHistoriaClinicaTemporalAsync(ActualizarHistoriaClinicaTemporal actualizarHistoriaClinicaTemporal)
        {
            RespuestaBD respuesta = new RespuestaBD();

            var result = await GalenPlusContext.Query<ActualizarNroHistoriaClinicaTemporalView>().FromSql("dbo.INO_ActualizarNroHistoriaClinicaTemporal @AntiguoHC,@Hc,@IdUsuario,@IdTipoNumeracion,@IdPaciente,@IdManual",
                        new SqlParameter("AntiguoHC", actualizarHistoriaClinicaTemporal.AntiguaHistoriaClinica),
                        new SqlParameter("Hc", actualizarHistoriaClinicaTemporal.HistoriaClinica),
                        new SqlParameter("IdUsuario", actualizarHistoriaClinicaTemporal.IdUsuario),
                        new SqlParameter("IdTipoNumeracion", actualizarHistoriaClinicaTemporal.IdTipoNumeracion),
                        new SqlParameter("IdPaciente", actualizarHistoriaClinicaTemporal.IdPaciente),
                        new SqlParameter("IdManual", actualizarHistoriaClinicaTemporal.IdManual)).FirstOrDefaultAsync();

            //Mensaje de respuesta
            respuesta.Id = result.HcMaximo;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public RespuestaBD ActualizarTicketIdImpresion(ActualizarTicketConsultaExterna actualizarTicketConsultaExterna)
        {
            RespuestaBD respuesta = new RespuestaBD();

            TicketConsultaExterna ticket = InoContext.TicketConsultaExterna.Where(x => x.IdTicketConsultaExterna == actualizarTicketConsultaExterna.IdTicketConsultaExterna).FirstOrDefault();

            if (ticket != null)
            {
                ticket.IdImpresion = actualizarTicketConsultaExterna.IdImpresion;
                InoContext.SaveChanges();
                respuesta.Id = ticket.IdTicketConsultaExterna;
                respuesta.Mensaje = "Se modificó el ticket correctamente.";
            }
            else
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "El ticket no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> ActualizarTicketIdImpresionAsync(ActualizarTicketConsultaExterna actualizarTicketConsultaExterna)
        {
            RespuestaBD respuesta = new RespuestaBD();

            TicketConsultaExterna ticket = await InoContext.TicketConsultaExterna.Where(x => x.IdTicketConsultaExterna == actualizarTicketConsultaExterna.IdTicketConsultaExterna).FirstOrDefaultAsync();

            if (ticket != null)
            {
                ticket.IdImpresion = actualizarTicketConsultaExterna.IdImpresion;
                await InoContext.SaveChangesAsync();
                respuesta.Id = ticket.IdTicketConsultaExterna;
                respuesta.Mensaje = "Se modificó el ticket correctamente.";
            }
            else
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "El ticket no existe.";
            }

            return respuesta;
        }

        public RespuestaBD ActualizarTicketIdImpresionRevision(ActualizarTicketConsultaExterna actualizarTicketConsultaExterna)
        {
            RespuestaBD respuesta = new RespuestaBD();

            TicketConsultaExterna ticket = InoContext.TicketConsultaExterna.Where(x => x.IdTicketConsultaExterna == actualizarTicketConsultaExterna.IdTicketConsultaExterna).FirstOrDefault();

            if (ticket != null)
            {
                ticket.IdImpresionRevision = actualizarTicketConsultaExterna.IdImpresionRevision;
                InoContext.SaveChanges();
                respuesta.Id = ticket.IdTicketConsultaExterna;
                respuesta.Mensaje = "Se modificó el ticket correctamente.";
            }
            else
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "El ticket no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> ActualizarTicketIdImpresionRevisionAsync(ActualizarTicketConsultaExterna actualizarTicketConsultaExterna)
        {
            RespuestaBD respuesta = new RespuestaBD();

            TicketConsultaExterna ticket = await InoContext.TicketConsultaExterna
                                                        .Where(x => x.IdTicketConsultaExterna == actualizarTicketConsultaExterna.IdTicketConsultaExterna)
                                                        .FirstOrDefaultAsync();

            if (ticket != null)
            {
                ticket.IdImpresionRevision = actualizarTicketConsultaExterna.IdImpresionRevision;
                await InoContext.SaveChangesAsync();
                respuesta.Id = ticket.IdTicketConsultaExterna;
                respuesta.Mensaje = "Se modificó el ticket correctamente.";
            }
            else
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "El ticket no existe.";
            }

            return respuesta;
        }

        public RespuestaBD AgregarTicketConsultaExterna(PacienteCitado pacienteCitado, NuevoTicketConsultaExterna nuevoTicketConsultaExterna)
        {
            RespuestaBD respuesta = new RespuestaBD();

            if (pacienteCitado != null)
            {
                TicketConsultaExterna pacienteEncontrado = InoContext.TicketConsultaExterna.Where(x => x.FechaCreacion.Day == DateTime.Now.Day &&
                                                                    x.FechaCreacion.Month == DateTime.Now.Month &&
                                                                    x.FechaCreacion.Year == DateTime.Now.Year &&
                                                                    x.HistoriaClinica == (nuevoTicketConsultaExterna.HistoriaClinica ?? 0).ToString() &&
                                                                    x.IdEspecialidad == nuevoTicketConsultaExterna.IdEspecialidad).FirstOrDefault();
                nuevoTicketConsultaExterna.Medico = (nuevoTicketConsultaExterna.Medico == "<SELECCIONAR>") ? " " : nuevoTicketConsultaExterna.Medico ?? " ";
                if (pacienteEncontrado == null)
                {
                    int pacienteTotalHoy = InoContext.TicketConsultaExterna.Where(x => x.FechaCreacion.Day == DateTime.Now.Day &&
                                                                        x.FechaCreacion.Month == DateTime.Now.Month &&
                                                                        x.FechaCreacion.Year == DateTime.Now.Year &&
                                                                        x.IdTurno == nuevoTicketConsultaExterna.IdTurno
                                                                        && x.IdMedico ==  nuevoTicketConsultaExterna.IdMedico).Count();
                    TicketConsultaExterna ticketConsultaExterna = Mapper.Map<TicketConsultaExterna>(nuevoTicketConsultaExterna);
                    if (pacienteTotalHoy == 0)
                    {
                        ticketConsultaExterna.Contador = 1;
                    }
                    else
                    {
                        ticketConsultaExterna.Contador = pacienteTotalHoy + 1;
                    }
                    //Edad
                    int edad = GalenPlusContext.Query<TicketObtenerEdadPacienteView>().FromSql("dbo.Invision_ObtenerEdadPaciente @IdPaciente",
                    new SqlParameter("IdPaciente", ticketConsultaExterna.IdPaciente)).FirstOrDefault().Edad;

                    ticketConsultaExterna.Edad = edad;

                    //Nro Boleta o Fua
                    var nroBoletaFua = GalenPlusContext.Query<TicketObtenerBoletaFuaView>().FromSql("dbo.Invision_ObtenerNroBoletaFua @Fecha,@IdEspecialidad,@IdPaciente",
                    new SqlParameter("Fecha", ticketConsultaExterna.FechaCreacion),
                    new SqlParameter("IdEspecialidad", ticketConsultaExterna.IdEspecialidad),
                    new SqlParameter("IdPaciente", ticketConsultaExterna.IdPaciente)).FirstOrDefault();

                    if (nroBoletaFua != null)
                    {
                        ticketConsultaExterna.NroBoletaFua = nroBoletaFua.NroBoletaFua;

                        InoContext.TicketConsultaExterna.Add(ticketConsultaExterna);
                        InoContext.SaveChanges();

                        //Mensaje de respuesta
                        respuesta.Id = ticketConsultaExterna.IdTicketConsultaExterna;
                        respuesta.Mensaje = "Se ingresó los datos correctamente.";
                    }
                    else
                    {
                        //Mensaje de respuesta
                        respuesta.Id = 0;
                        respuesta.Mensaje = "El paciente no cuenta con número de boleta o número de FUA.";
                    }
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya ha sido ingresado con los mismos datos.";
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente no se encuentra citado.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarTicketConsultaExternaAsync(PacienteCitado pacienteCitado, NuevoTicketConsultaExterna nuevoTicketConsultaExterna)
        {
            RespuestaBD respuesta = new RespuestaBD();

            if (pacienteCitado != null)
            {
                TicketConsultaExterna pacienteEncontrado = await InoContext.TicketConsultaExterna.Where(x => x.FechaCreacion.Day == DateTime.Now.Day &&
                                                                    x.FechaCreacion.Month == DateTime.Now.Month &&
                                                                    x.FechaCreacion.Year == DateTime.Now.Year &&
                                                                    x.HistoriaClinica == (nuevoTicketConsultaExterna.HistoriaClinica ?? 0).ToString() &&
                                                                    x.IdEspecialidad == nuevoTicketConsultaExterna.IdEspecialidad).FirstOrDefaultAsync();
                nuevoTicketConsultaExterna.Medico = (nuevoTicketConsultaExterna.Medico == "<SELECCIONAR>") ? " " : nuevoTicketConsultaExterna.Medico ?? " ";
                if (pacienteEncontrado == null)
                {
                    int pacienteTotalHoy = InoContext.TicketConsultaExterna.Where(x => x.FechaCreacion.Day == DateTime.Now.Day &&
                                                                        x.FechaCreacion.Month == DateTime.Now.Month &&
                                                                        x.FechaCreacion.Year == DateTime.Now.Year &&
                                                                        x.IdTurno == nuevoTicketConsultaExterna.IdTurno).Count();
                    TicketConsultaExterna ticketConsultaExterna = Mapper.Map<TicketConsultaExterna>(nuevoTicketConsultaExterna);
                    if (pacienteTotalHoy == 0)
                    {
                        ticketConsultaExterna.Contador = 1;
                    }
                    else
                    {
                        ticketConsultaExterna.Contador = pacienteTotalHoy + 1;
                    }
                    //Edad
                    var resultEdad = await GalenPlusContext.Query<TicketObtenerEdadPacienteView>().FromSql("dbo.Invision_ObtenerEdadPaciente @IdPaciente",
                            new SqlParameter("IdPaciente", ticketConsultaExterna.IdPaciente)).FirstOrDefaultAsync();

                    ticketConsultaExterna.Edad = resultEdad.Edad;

                    //Nro Boleta o Fua
                    var resultBoletaFua = await GalenPlusContext.Query<TicketObtenerBoletaFuaView>().FromSql("dbo.Invision_ObtenerNroBoletaFua @Fecha,@IdEspecialidad,@IdPaciente",
                                            new SqlParameter("Fecha", ticketConsultaExterna.FechaCreacion),
                                            new SqlParameter("IdEspecialidad", ticketConsultaExterna.IdEspecialidad),
                                            new SqlParameter("IdPaciente", ticketConsultaExterna.IdPaciente)).FirstOrDefaultAsync();

                    if (resultBoletaFua != null)
                    {
                        ticketConsultaExterna.NroBoletaFua = resultBoletaFua.NroBoletaFua;

                        await InoContext.TicketConsultaExterna.AddAsync(ticketConsultaExterna);
                        await InoContext.SaveChangesAsync();

                        //Mensaje de respuesta
                        respuesta.Id = ticketConsultaExterna.IdTicketConsultaExterna;
                        respuesta.Mensaje = "Se ingresó los datos correctamente.";
                    }
                    else
                    {
                        //Mensaje de respuesta
                        respuesta.Id = 0;
                        respuesta.Mensaje = "El paciente no cuenta con número de boleta o número de FUA.";
                    }
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya ha sido ingresado con los mismos datos.";
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente no se encuentra citado.";
            }

            return respuesta;
        }

        public IEnumerable<TicketConsultaExternaGeneral> ListarTicketConsultaExterna(DateTime Fecha)
        {
            var list = InoContext.TicketConsultaExterna.Where(x => (x.FechaCreacion.Day == Fecha.Day && x.FechaCreacion.Month == Fecha.Month && x.FechaCreacion.Year == Fecha.Year))
                                               .ToList()
                                               .OrderByDescending(x => x.FechaCreacion)
                                               .Select(x => Mapper.Map<TicketConsultaExternaGeneral>(x))
                                               .ToList();
            return list;
        }

        public async Task<IEnumerable<TicketConsultaExternaGeneral>> ListarTicketConsultaExternaAsync(int? Id, DateTime? Fecha)
        {
            var lista = await InoContext.TicketConsultaExterna.Where(x => (Id == null || x.IdTicketConsultaExterna == Id) &&
                                                                          (Fecha == null || (x.FechaCreacion.Day == Fecha.Value.Day && x.FechaCreacion.Month == Fecha.Value.Month && x.FechaCreacion.Year == Fecha.Value.Year)))
                .Select(x => Mapper.Map<TicketConsultaExternaGeneral>(x))
                .ToListAsync();
            return lista;
        }

        public IEnumerable<TicketConsultaExternaGeneral> ListarTicketsHub(DateTime Fecha)
        {

            return InoContext.Query<TicketConsultaExternaGeneral>().FromSql("dbo.Invision_ListarTicketsHub, @FECHA",
                            new SqlParameter("FECHA", Fecha.ToString("yyyy-MM-dd"))
                        ).ToList();
        }
    }
}
