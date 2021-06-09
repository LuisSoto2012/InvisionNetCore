
using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErronea.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErronea.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Laboratorio;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDePedidosAnalisis : IRepositorioDePedidosAnalisis
    {
        private readonly InoContext Context;

        public RepositorioDePedidosAnalisis(InoContext context)
        {
            Context = context;
        }

        public RespuestaBD AgregarSolicitudDatosIncompletos(NuevoSolicitudDatosIncompletos nuevoSolicitudDatosIncompletos)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SolicitudDatosIncompletos pacienteEncontrado = Context.SolicitudDatosIncompletos.Where(x => x.HistoriaClinica == nuevoSolicitudDatosIncompletos.HistoriaClinica && x.FechaOcurrencia == nuevoSolicitudDatosIncompletos.FechaOcurrencia).FirstOrDefault();
            if (pacienteEncontrado == null)
            {
                SolicitudDatosIncompletos solicitudDatosIncompletos = Mapper.Map<SolicitudDatosIncompletos>(nuevoSolicitudDatosIncompletos);
                Context.SolicitudDatosIncompletos.Add(solicitudDatosIncompletos);
                Context.SaveChanges();

                //Mensaje de respuesta
                respuesta.Id = solicitudDatosIncompletos.IdSolicitudDatosIncompletos;
                respuesta.Mensaje = "Se ingresó los datos correctamente.";

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarSolicitudDatosIncompletosAsync(NuevoSolicitudDatosIncompletos nuevoSolicitudDatosIncompletos)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SolicitudDatosIncompletos pacienteEncontrado = await Context.SolicitudDatosIncompletos.Where(x => x.HistoriaClinica == nuevoSolicitudDatosIncompletos.HistoriaClinica && x.FechaOcurrencia == nuevoSolicitudDatosIncompletos.FechaOcurrencia).FirstOrDefaultAsync();
            if (pacienteEncontrado == null)
            {
                SolicitudDatosIncompletos solicitudDatosIncompletos = Mapper.Map<SolicitudDatosIncompletos>(nuevoSolicitudDatosIncompletos);
                await Context.SolicitudDatosIncompletos.AddAsync(solicitudDatosIncompletos);
                await Context.SaveChangesAsync();

                //Mensaje de respuesta
                respuesta.Id = solicitudDatosIncompletos.IdSolicitudDatosIncompletos;
                respuesta.Mensaje = "Se ingresó los datos correctamente.";

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
            }

            return respuesta;
        }

        public RespuestaBD AgregarTranscripcionErronea(NuevoTranscripcionErronea nuevoTranscripcionErronea)
        {
            RespuestaBD respuesta = new RespuestaBD();

            TranscripcionErronea pacienteEncontrado = Context.TranscripcionErronea.Where(x => x.HistoriaClinica == nuevoTranscripcionErronea.HistoriaClinica && x.FechaOcurrencia == nuevoTranscripcionErronea.FechaOcurrencia).FirstOrDefault();
            if (pacienteEncontrado == null)
            {
                TranscripcionErronea transcripcionErronea = Mapper.Map<TranscripcionErronea>(nuevoTranscripcionErronea);
                Context.TranscripcionErronea.Add(transcripcionErronea);
                Context.SaveChanges();

                //Mensaje de respuesta
                respuesta.Id = transcripcionErronea.IdTranscripcionErronea;
                respuesta.Mensaje = "Se ingresó los datos correctamente.";

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarTranscripcionErroneaAsync(NuevoTranscripcionErronea nuevoTranscripcionErronea)
        {
            RespuestaBD respuesta = new RespuestaBD();

            TranscripcionErronea pacienteEncontrado = await Context.TranscripcionErronea.Where(x => x.HistoriaClinica == nuevoTranscripcionErronea.HistoriaClinica && x.FechaOcurrencia == nuevoTranscripcionErronea.FechaOcurrencia).FirstOrDefaultAsync();
            if (pacienteEncontrado == null)
            {
                TranscripcionErronea transcripcionErronea = Mapper.Map<TranscripcionErronea>(nuevoTranscripcionErronea);
                await Context.TranscripcionErronea.AddAsync(transcripcionErronea);
                await Context.SaveChangesAsync();

                //Mensaje de respuesta
                respuesta.Id = transcripcionErronea.IdTranscripcionErronea;
                respuesta.Mensaje = "Se ingresó los datos correctamente.";

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
            }

            return respuesta;
        }

        public RespuestaBD EditarSolicitudDatosIncompletos(ActualizarSolicitudDatosIncompletos actualizarSolicitudDatosIncompletos)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SolicitudDatosIncompletos solicitudDatosIncompletos = Context.SolicitudDatosIncompletos.Where(x => x.IdSolicitudDatosIncompletos == actualizarSolicitudDatosIncompletos.IdSolicitudDatosIncompletos).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(solicitudDatosIncompletos);
            if (solicitudDatosIncompletos != null)
            {
                SolicitudDatosIncompletos pacienteEncontrado = Context.SolicitudDatosIncompletos.Where(x => x.HistoriaClinica == actualizarSolicitudDatosIncompletos.HistoriaClinica && x.FechaOcurrencia == actualizarSolicitudDatosIncompletos.FechaOcurrencia && x.IdSolicitudDatosIncompletos != actualizarSolicitudDatosIncompletos.IdSolicitudDatosIncompletos).FirstOrDefault();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(solicitudDatosIncompletos).CurrentValues.SetValues(actualizarSolicitudDatosIncompletos);
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = solicitudDatosIncompletos.IdSolicitudDatosIncompletos;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";

                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EditarSolicitudDatosIncompletosAsync(ActualizarSolicitudDatosIncompletos actualizarSolicitudDatosIncompletos)
        {
            RespuestaBD respuesta = new RespuestaBD();

            SolicitudDatosIncompletos solicitudDatosIncompletos = await Context.SolicitudDatosIncompletos
                                                                            .Where(x => x.IdSolicitudDatosIncompletos == actualizarSolicitudDatosIncompletos.IdSolicitudDatosIncompletos)
                                                                            .FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(solicitudDatosIncompletos);
            if (solicitudDatosIncompletos != null)
            {
                SolicitudDatosIncompletos pacienteEncontrado = await Context.SolicitudDatosIncompletos
                                                                                .Where(x => x.HistoriaClinica == actualizarSolicitudDatosIncompletos.HistoriaClinica && x.FechaOcurrencia == actualizarSolicitudDatosIncompletos.FechaOcurrencia && x.IdSolicitudDatosIncompletos != actualizarSolicitudDatosIncompletos.IdSolicitudDatosIncompletos)
                                                                                .FirstOrDefaultAsync();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(solicitudDatosIncompletos).CurrentValues.SetValues(actualizarSolicitudDatosIncompletos);
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = solicitudDatosIncompletos.IdSolicitudDatosIncompletos;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";

                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public RespuestaBD EditarTranscripcionErronea(ActualizarTranscripcionErronea actualizarTranscripcionErronea)
        {
            RespuestaBD respuesta = new RespuestaBD();

            TranscripcionErronea transcripcionErronea = Context.TranscripcionErronea.Where(x=> x.IdTranscripcionErronea == actualizarTranscripcionErronea.IdTranscripcionErronea).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(transcripcionErronea);
            if (transcripcionErronea != null)
            {
                TranscripcionErronea pacienteEncontrado = Context.TranscripcionErronea.Where(x => x.HistoriaClinica == actualizarTranscripcionErronea.HistoriaClinica && x.FechaOcurrencia == actualizarTranscripcionErronea.FechaOcurrencia && x.IdTranscripcionErronea != actualizarTranscripcionErronea.IdTranscripcionErronea).FirstOrDefault();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(transcripcionErronea).CurrentValues.SetValues(actualizarTranscripcionErronea);
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = transcripcionErronea.IdTranscripcionErronea;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";

                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EditarTranscripcionErroneaAsync(ActualizarTranscripcionErronea actualizarTranscripcionErronea)
        {
            RespuestaBD respuesta = new RespuestaBD();

            TranscripcionErronea transcripcionErronea = await Context.TranscripcionErronea
                                                                    .Where(x => x.IdTranscripcionErronea == actualizarTranscripcionErronea.IdTranscripcionErronea)
                                                                    .FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(transcripcionErronea);
            if (transcripcionErronea != null)
            {
                TranscripcionErronea pacienteEncontrado = await Context.TranscripcionErronea
                                                                    .Where(x => x.HistoriaClinica == actualizarTranscripcionErronea.HistoriaClinica && x.FechaOcurrencia == actualizarTranscripcionErronea.FechaOcurrencia && x.IdTranscripcionErronea != actualizarTranscripcionErronea.IdTranscripcionErronea)
                                                                    .FirstOrDefaultAsync();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(transcripcionErronea).CurrentValues.SetValues(actualizarTranscripcionErronea);
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = transcripcionErronea.IdTranscripcionErronea;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";

                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                }
            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public SolicitudDatosIncompletos EncontrarSolicitudDatosIncompletos(int Id)
        {
            return Context.SolicitudDatosIncompletos.Where(x => x.IdSolicitudDatosIncompletos == Id).FirstOrDefault();
        }

        public async Task<SolicitudDatosIncompletos> EncontrarSolicitudDatosIncompletosAsync(int Id)
        {
            return await Context.SolicitudDatosIncompletos.Where(x => x.IdSolicitudDatosIncompletos == Id).FirstOrDefaultAsync();
        }

        public TranscripcionErronea EncontrarTranscripcionErronea(int Id)
        {
            return Context.TranscripcionErronea.Where(x => x.IdTranscripcionErronea == Id).FirstOrDefault();
        }

        public async Task<TranscripcionErronea> EncontrarTranscripcionErroneaAsync(int Id)
        {
            return await Context.TranscripcionErronea.Where(x => x.IdTranscripcionErronea == Id).FirstOrDefaultAsync();
        }

        public IEnumerable<SolicitudDatosIncompletosGeneral> ListarSolicitudDatosIncompletos()
        {
            return Context.SolicitudDatosIncompletos.Select(x => Mapper.Map<SolicitudDatosIncompletosGeneral>(x))
                                                   .ToList();
        }

        public async Task<IEnumerable<SolicitudDatosIncompletosGeneral>> ListarSolicitudDatosIncompletosAsync(int? Id)
        {
            return await Context.SolicitudDatosIncompletos.Select(x => Mapper.Map<SolicitudDatosIncompletosGeneral>(x))
                                                   .ToListAsync();
        }

        public IEnumerable<TranscripcionErroneaGeneral> ListarTranscripcionErronea()
        {
            return Context.TranscripcionErronea.Select(x => Mapper.Map<TranscripcionErroneaGeneral>(x))
                                              .ToList();
        }

        public async Task<IEnumerable<TranscripcionErroneaGeneral>> ListarTranscripcionErroneaAsync(int? Id)
        {
            return await Context.TranscripcionErronea.Select(x => Mapper.Map<TranscripcionErroneaGeneral>(x))
                                              .ToListAsync();
        }
    }
}
