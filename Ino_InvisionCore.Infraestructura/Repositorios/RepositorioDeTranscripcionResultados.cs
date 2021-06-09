using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PacienteSinResulado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PacienteSinResulado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErroneaInoportuna.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErroneaInoportuna.Respuestas;
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
    public class RepositorioDeTranscripcionResultados : IRepositorioDeTranscripcionResultados
    {
        private InoContext Context;

        public RepositorioDeTranscripcionResultados(InoContext context)
        {
            Context = context;
        }

        public RespuestaBD AgregarPacienteSinResultado(NuevoPacienteSinResultado nuevoPacienteSinResultado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            PacienteSinResultado pacienteEncontrado = Context.PacienteSinResultado.Where(x => x.HistoriaClinica == nuevoPacienteSinResultado.HistoriaClinica && x.FechaOcurrencia == nuevoPacienteSinResultado.FechaOcurrencia).FirstOrDefault();
            if (pacienteEncontrado == null)
            {
                PacienteSinResultado pacienteSinResultado = Mapper.Map<PacienteSinResultado>(nuevoPacienteSinResultado);
                Context.PacienteSinResultado.Add(pacienteSinResultado);
                Context.SaveChanges();

                //Mensaje de respuesta
                respuesta.Id = pacienteSinResultado.IdPacienteSinResultado;
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

        public async Task<RespuestaBD> AgregarPacienteSinResultadoAsync(NuevoPacienteSinResultado nuevoPacienteSinResultado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            PacienteSinResultado pacienteEncontrado = await Context.PacienteSinResultado.Where(x => x.HistoriaClinica == nuevoPacienteSinResultado.HistoriaClinica && x.FechaOcurrencia == nuevoPacienteSinResultado.FechaOcurrencia).FirstOrDefaultAsync();
            if (pacienteEncontrado == null)
            {
                PacienteSinResultado pacienteSinResultado = Mapper.Map<PacienteSinResultado>(nuevoPacienteSinResultado);
                await Context.PacienteSinResultado.AddAsync(pacienteSinResultado);
                await Context.SaveChangesAsync();

                //Mensaje de respuesta
                respuesta.Id = pacienteSinResultado.IdPacienteSinResultado;
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

        public RespuestaBD AgregarTranscripcionErroneaInoportuna(NuevoTranscripcionErroneaInoportuna nuevoTranscripcionErroneaInoportuna)
        {
            RespuestaBD respuesta = new RespuestaBD();

            TranscripcionErroneaInoportuna pacienteEncontrado = Context.TranscripcionErroneaInoportuna.Where(x => x.HistoriaClinica == nuevoTranscripcionErroneaInoportuna.HistoriaClinica && x.FechaOcurrencia == nuevoTranscripcionErroneaInoportuna.FechaOcurrencia).FirstOrDefault();
            if (pacienteEncontrado == null)
            {
                TranscripcionErroneaInoportuna transcripcionErroneaInoportuna = Mapper.Map<TranscripcionErroneaInoportuna>(nuevoTranscripcionErroneaInoportuna);
                Context.TranscripcionErroneaInoportuna.Add(transcripcionErroneaInoportuna);
                Context.SaveChanges();

                //Mensaje de respuesta
                respuesta.Id = transcripcionErroneaInoportuna.IdTranscripcionErroneaInoportuna;
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

        public async Task<RespuestaBD> AgregarTranscripcionErroneaInoportunaAsync(NuevoTranscripcionErroneaInoportuna nuevoTranscripcionErroneaInoportuna)
        {
            RespuestaBD respuesta = new RespuestaBD();

            TranscripcionErroneaInoportuna pacienteEncontrado = await Context.TranscripcionErroneaInoportuna.Where(x => x.HistoriaClinica == nuevoTranscripcionErroneaInoportuna.HistoriaClinica && x.FechaOcurrencia == nuevoTranscripcionErroneaInoportuna.FechaOcurrencia).FirstOrDefaultAsync();
            if (pacienteEncontrado == null)
            {
                TranscripcionErroneaInoportuna transcripcionErroneaInoportuna = Mapper.Map<TranscripcionErroneaInoportuna>(nuevoTranscripcionErroneaInoportuna);
                await Context.TranscripcionErroneaInoportuna.AddAsync(transcripcionErroneaInoportuna);
                await Context.SaveChangesAsync();

                //Mensaje de respuesta
                respuesta.Id = transcripcionErroneaInoportuna.IdTranscripcionErroneaInoportuna;
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

        public RespuestaBD EditarPacienteSinResultado(ActualizarPacienteSinResultado actualizarPacienteSinResultado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            PacienteSinResultado pacienteSinResultado = Context.PacienteSinResultado.Where(x => x.IdPacienteSinResultado == actualizarPacienteSinResultado.IdPacienteSinResultado).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(pacienteSinResultado);
            if (pacienteSinResultado != null)
            {
                PacienteSinResultado pacienteEncontrado = Context.PacienteSinResultado.Where(x => x.HistoriaClinica == actualizarPacienteSinResultado.HistoriaClinica && x.FechaOcurrencia == actualizarPacienteSinResultado.FechaOcurrencia && x.IdPacienteSinResultado != actualizarPacienteSinResultado.IdPacienteSinResultado).FirstOrDefault();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(pacienteSinResultado).CurrentValues.SetValues(actualizarPacienteSinResultado);
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = pacienteSinResultado.IdPacienteSinResultado;
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

        public async Task<RespuestaBD> EditarPacienteSinResultadoAsync(ActualizarPacienteSinResultado actualizarPacienteSinResultado)
        {
            RespuestaBD respuesta = new RespuestaBD();

            PacienteSinResultado pacienteSinResultado = await Context.PacienteSinResultado
                                                                .Where(x => x.IdPacienteSinResultado == actualizarPacienteSinResultado.IdPacienteSinResultado)
                                                                .FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(pacienteSinResultado);
            if (pacienteSinResultado != null)
            {
                PacienteSinResultado pacienteEncontrado = await Context.PacienteSinResultado.Where(x => x.HistoriaClinica == actualizarPacienteSinResultado.HistoriaClinica && x.FechaOcurrencia == actualizarPacienteSinResultado.FechaOcurrencia && x.IdPacienteSinResultado != actualizarPacienteSinResultado.IdPacienteSinResultado).FirstOrDefaultAsync();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(pacienteSinResultado).CurrentValues.SetValues(actualizarPacienteSinResultado);
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = pacienteSinResultado.IdPacienteSinResultado;
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

        public RespuestaBD EditarTranscripcionErroneaInoportuna(ActualizarTranscripcionErroneaInoportuna actualizarTranscripcionErroneaInoportuna)
        {
            RespuestaBD respuesta = new RespuestaBD();

            TranscripcionErroneaInoportuna transcripcionErroneaInoportuna = Context.TranscripcionErroneaInoportuna.Where(x => x.IdTranscripcionErroneaInoportuna == actualizarTranscripcionErroneaInoportuna.IdTranscripcionErroneaInoportuna).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(transcripcionErroneaInoportuna);
            if (transcripcionErroneaInoportuna != null)
            {
                TranscripcionErroneaInoportuna pacienteEncontrado = Context.TranscripcionErroneaInoportuna.Where(x => x.HistoriaClinica == actualizarTranscripcionErroneaInoportuna.HistoriaClinica && x.FechaOcurrencia == actualizarTranscripcionErroneaInoportuna.FechaOcurrencia && x.IdTranscripcionErroneaInoportuna != actualizarTranscripcionErroneaInoportuna.IdTranscripcionErroneaInoportuna).FirstOrDefault();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(transcripcionErroneaInoportuna).CurrentValues.SetValues(actualizarTranscripcionErroneaInoportuna);
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = transcripcionErroneaInoportuna.IdTranscripcionErroneaInoportuna;
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

        public async Task<RespuestaBD> EditarTranscripcionErroneaInoportunaAsync(ActualizarTranscripcionErroneaInoportuna actualizarTranscripcionErroneaInoportuna)
        {
            RespuestaBD respuesta = new RespuestaBD();

            TranscripcionErroneaInoportuna transcripcionErroneaInoportuna = await Context.TranscripcionErroneaInoportuna
                                                                                    .Where(x => x.IdTranscripcionErroneaInoportuna == actualizarTranscripcionErroneaInoportuna.IdTranscripcionErroneaInoportuna)
                                                                                    .FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(transcripcionErroneaInoportuna);
            if (transcripcionErroneaInoportuna != null)
            {
                TranscripcionErroneaInoportuna pacienteEncontrado = await Context.TranscripcionErroneaInoportuna.Where(x => x.HistoriaClinica == actualizarTranscripcionErroneaInoportuna.HistoriaClinica && x.FechaOcurrencia == actualizarTranscripcionErroneaInoportuna.FechaOcurrencia && x.IdTranscripcionErroneaInoportuna != actualizarTranscripcionErroneaInoportuna.IdTranscripcionErroneaInoportuna).FirstOrDefaultAsync();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(transcripcionErroneaInoportuna).CurrentValues.SetValues(actualizarTranscripcionErroneaInoportuna);
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = transcripcionErroneaInoportuna.IdTranscripcionErroneaInoportuna;
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

        public PacienteSinResultado EncontrarPacienteSinResultado(int Id)
        {
            return Context.PacienteSinResultado.Where(x => x.IdPacienteSinResultado == Id).FirstOrDefault();
        }

        public async Task<PacienteSinResultado> EncontrarPacienteSinResultadoAsync(int Id)
        {
            return await Context.PacienteSinResultado.Where(x => x.IdPacienteSinResultado == Id).FirstOrDefaultAsync();
        }

        public TranscripcionErroneaInoportuna EncontrarTranscripcionErroneaInoportuna(int Id)
        {
            return Context.TranscripcionErroneaInoportuna.Where(x => x.IdTranscripcionErroneaInoportuna == Id).FirstOrDefault();
        }

        public async Task<TranscripcionErroneaInoportuna> EncontrarTranscripcionErroneaInoportunaAsync(int Id)
        {
            return await Context.TranscripcionErroneaInoportuna.Where(x => x.IdTranscripcionErroneaInoportuna == Id).FirstOrDefaultAsync();
        }

        public IEnumerable<PacienteSinResultadoGeneral> ListarPacienteSinResultado()
        {
            return Context.PacienteSinResultado
                                              .Select(x => Mapper.Map<PacienteSinResultadoGeneral>(x))
                                              .ToList();
        }

        public async Task<IEnumerable<PacienteSinResultadoGeneral>> ListarPacienteSinResultadoAsync(int? Id)
        {
            return await Context.PacienteSinResultado
                                              .Select(x => Mapper.Map<PacienteSinResultadoGeneral>(x))
                                              .ToListAsync();
        }

        public IEnumerable<TranscripcionErroneaInoportunaGeneral> ListarTranscripcionErroneaInoportuna()
        {
            return Context.TranscripcionErroneaInoportuna
                                                        .Include(x => x.AreaLaboratorio)
                                                        .ToList()
                                                        .Select(x => Mapper.Map<TranscripcionErroneaInoportunaGeneral>(x))
                                                        .ToList();
        }

        public async Task<IEnumerable<TranscripcionErroneaInoportunaGeneral>> ListarTranscripcionErroneaInoportunaAsync(int? Id)
        {
            return await Context.TranscripcionErroneaInoportuna
                                                        .Include(x => x.AreaLaboratorio)
                                                        .Select(x => Mapper.Map<TranscripcionErroneaInoportunaGeneral>(x))
                                                        .ToListAsync();
        }
    }
}
