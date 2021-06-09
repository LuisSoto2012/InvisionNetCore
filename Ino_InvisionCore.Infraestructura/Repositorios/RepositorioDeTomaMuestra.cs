using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncidentesPacientes.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncidentesPacientes.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncumplimientoAnalisis.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IncumplimientoAnalisis.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PruebasNoRealizadas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PruebasNoRealizadas.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RecoleccionMuestra.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RecoleccionMuestra.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.VenopunturasFallidas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.VenopunturasFallidas.Respuestas;
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
    public class RepositorioDeTomaMuestra : IRepositorioDeTomaMuestra
    {
        private InoContext Context;

        public RepositorioDeTomaMuestra(InoContext context)
        {
            Context = context;
        }

        public RespuestaBD AgregarIncidentesPacientes(NuevoIncidentesPacientes nuevoIncidentesPacientes)
        {
            RespuestaBD respuesta = new RespuestaBD();

            IncidentesPacientes pacienteEncontrado = Context.IncidentesPacientes.Where(x => x.HistoriaClinica == nuevoIncidentesPacientes.HistoriaClinica && x.FechaOcurrencia == nuevoIncidentesPacientes.FechaOcurrencia).FirstOrDefault();
            if (pacienteEncontrado == null)
            {
                IncidentesPacientes incidentesPacientes = Mapper.Map<IncidentesPacientes>(nuevoIncidentesPacientes);
                Context.IncidentesPacientes.Add(incidentesPacientes);
                Context.SaveChanges();

                //Mensaje de respuesta
                respuesta.Id = incidentesPacientes.IdIncidentesPacientes;
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

        public async Task<RespuestaBD> AgregarIncidentesPacientesAsync(NuevoIncidentesPacientes nuevoIncidentesPacientes)
        {
            RespuestaBD respuesta = new RespuestaBD();

            IncidentesPacientes pacienteEncontrado = await Context.IncidentesPacientes
                                                            .Where(x => x.HistoriaClinica == nuevoIncidentesPacientes.HistoriaClinica && x.FechaOcurrencia == nuevoIncidentesPacientes.FechaOcurrencia)
                                                            .FirstOrDefaultAsync();
            if (pacienteEncontrado == null)
            {
                IncidentesPacientes incidentesPacientes = Mapper.Map<IncidentesPacientes>(nuevoIncidentesPacientes);
                await Context.IncidentesPacientes.AddAsync(incidentesPacientes);
                await Context.SaveChangesAsync();

                //Mensaje de respuesta
                respuesta.Id = incidentesPacientes.IdIncidentesPacientes;
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

        public RespuestaBD AgregarIncumplimientoAnalisis(NuevoIncumplimientoAnalisis nuevoIncumplimientoAnalisis)
        {
            RespuestaBD respuesta = new RespuestaBD();

            IncumplimientoAnalisis pacienteEncontrado = Context.IncumplimientoAnalisis.Where(x => x.HistoriaClinica == nuevoIncumplimientoAnalisis.HistoriaClinica && x.FechaOcurrencia == nuevoIncumplimientoAnalisis.FechaOcurrencia).FirstOrDefault();
            if (pacienteEncontrado == null)
            {
                IncumplimientoAnalisis incumplimientoAnalisis = Mapper.Map<IncumplimientoAnalisis>(nuevoIncumplimientoAnalisis);
                Context.IncumplimientoAnalisis.Add(incumplimientoAnalisis);
                Context.SaveChanges();

                //Mensaje de respuesta
                respuesta.Id = incumplimientoAnalisis.IdIncumplimientoAnalisis;
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

        public async Task<RespuestaBD> AgregarIncumplimientoAnalisisAsync(NuevoIncumplimientoAnalisis nuevoIncumplimientoAnalisis)
        {
            RespuestaBD respuesta = new RespuestaBD();

            IncumplimientoAnalisis pacienteEncontrado = await Context.IncumplimientoAnalisis
                                                                .Where(x => x.HistoriaClinica == nuevoIncumplimientoAnalisis.HistoriaClinica && x.FechaOcurrencia == nuevoIncumplimientoAnalisis.FechaOcurrencia)
                                                                .FirstOrDefaultAsync();
            if (pacienteEncontrado == null)
            {
                IncumplimientoAnalisis incumplimientoAnalisis = Mapper.Map<IncumplimientoAnalisis>(nuevoIncumplimientoAnalisis);
                await Context.IncumplimientoAnalisis.AddAsync(incumplimientoAnalisis);
                await Context.SaveChangesAsync();

                //Mensaje de respuesta
                respuesta.Id = incumplimientoAnalisis.IdIncumplimientoAnalisis;
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

        public RespuestaBD AgregarPruebasNoRealizadas(NuevoPruebasNoRealizadas nuevoPruebasNoRealizadas)
        {
            RespuestaBD respuesta = new RespuestaBD();

            PruebasNoRealizadas pacienteEncontrado = Context.PruebasNoRealizadas.Where(x => x.HistoriaClinica == nuevoPruebasNoRealizadas.HistoriaClinica && x.FechaOcurrencia == nuevoPruebasNoRealizadas.FechaOcurrencia).FirstOrDefault();
            if (pacienteEncontrado == null)
            {
                PruebasNoRealizadas pruebasNoRealizadas = Mapper.Map<PruebasNoRealizadas>(nuevoPruebasNoRealizadas);
                Context.PruebasNoRealizadas.Add(pruebasNoRealizadas);
                Context.SaveChanges();

                //Mensaje de respuesta
                respuesta.Id = pruebasNoRealizadas.IdPruebasNoRealizadas;
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

        public async Task<RespuestaBD> AgregarPruebasNoRealizadasAsync(NuevoPruebasNoRealizadas nuevoPruebasNoRealizadas)
        {
            RespuestaBD respuesta = new RespuestaBD();

            PruebasNoRealizadas pacienteEncontrado = await Context.PruebasNoRealizadas
                                                            .Where(x => x.HistoriaClinica == nuevoPruebasNoRealizadas.HistoriaClinica && x.FechaOcurrencia == nuevoPruebasNoRealizadas.FechaOcurrencia)
                                                            .FirstOrDefaultAsync();
            if (pacienteEncontrado == null)
            {
                PruebasNoRealizadas pruebasNoRealizadas = Mapper.Map<PruebasNoRealizadas>(nuevoPruebasNoRealizadas);
                await Context.PruebasNoRealizadas.AddAsync(pruebasNoRealizadas);
                await Context.SaveChangesAsync();

                //Mensaje de respuesta
                respuesta.Id = pruebasNoRealizadas.IdPruebasNoRealizadas;
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

        public RespuestaBD AgregarRecoleccionMuestra(NuevoRecoleccionMuestra nuevoRecoleccionMuestra)
        {
            RespuestaBD respuesta = new RespuestaBD();

            RecoleccionMuestra pacienteEncontrado = Context.RecoleccionMuestra.Where(x => x.HistoriaClinica == nuevoRecoleccionMuestra.HistoriaClinica && x.FechaOcurrencia == nuevoRecoleccionMuestra.FechaOcurrencia).FirstOrDefault();
            if (pacienteEncontrado == null)
            {
                RecoleccionMuestra recoleccionMuestra = Mapper.Map<RecoleccionMuestra>(nuevoRecoleccionMuestra);
                Context.RecoleccionMuestra.Add(recoleccionMuestra);
                Context.SaveChanges();

                //Mensaje de respuesta
                respuesta.Id = recoleccionMuestra.IdRecoleccionMuestra;
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

        public async Task<RespuestaBD> AgregarRecoleccionMuestraAsync(NuevoRecoleccionMuestra nuevoRecoleccionMuestra)
        {
            RespuestaBD respuesta = new RespuestaBD();

            RecoleccionMuestra pacienteEncontrado = await Context.RecoleccionMuestra
                                                            .Where(x => x.HistoriaClinica == nuevoRecoleccionMuestra.HistoriaClinica && x.FechaOcurrencia == nuevoRecoleccionMuestra.FechaOcurrencia)
                                                            .FirstOrDefaultAsync();
            if (pacienteEncontrado == null)
            {
                RecoleccionMuestra recoleccionMuestra = Mapper.Map<RecoleccionMuestra>(nuevoRecoleccionMuestra);
                await Context.RecoleccionMuestra.AddAsync(recoleccionMuestra);
                await Context.SaveChangesAsync();

                //Mensaje de respuesta
                respuesta.Id = recoleccionMuestra.IdRecoleccionMuestra;
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

        public RespuestaBD AgregarVenopunturasFallidas(NuevoVenopunturasFallidas nuevoVenopunturasFallidas)
        {
            RespuestaBD respuesta = new RespuestaBD();

            VenopunturasFallidas pacienteEncontrado = Context.VenopunturasFallidas.Where(x => x.HistoriaClinica == nuevoVenopunturasFallidas.HistoriaClinica && x.FechaOcurrencia == nuevoVenopunturasFallidas.FechaOcurrencia).FirstOrDefault();
            if (pacienteEncontrado == null)
            {
                VenopunturasFallidas venopunturasFallidas = Mapper.Map<VenopunturasFallidas>(nuevoVenopunturasFallidas);
                Context.VenopunturasFallidas.Add(venopunturasFallidas);
                Context.SaveChanges();

                //Mensaje de respuesta
                respuesta.Id = venopunturasFallidas.IdVenopunturasFallidas;
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

        public async Task<RespuestaBD> AgregarVenopunturasFallidasAsync(NuevoVenopunturasFallidas nuevoVenopunturasFallidas)
        {
            RespuestaBD respuesta = new RespuestaBD();

            VenopunturasFallidas pacienteEncontrado = await Context.VenopunturasFallidas
                                                            .Where(x => x.HistoriaClinica == nuevoVenopunturasFallidas.HistoriaClinica && x.FechaOcurrencia == nuevoVenopunturasFallidas.FechaOcurrencia)
                                                            .FirstOrDefaultAsync();
            if (pacienteEncontrado == null)
            {
                VenopunturasFallidas venopunturasFallidas = Mapper.Map<VenopunturasFallidas>(nuevoVenopunturasFallidas);
                await Context.VenopunturasFallidas.AddAsync(venopunturasFallidas);
                await Context.SaveChangesAsync();

                //Mensaje de respuesta
                respuesta.Id = venopunturasFallidas.IdVenopunturasFallidas;
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

        public RespuestaBD EditarIncidentesPacientes(ActualizarIncidentesPacientes actualizarIncidentesPacientes)
        {
            RespuestaBD respuesta = new RespuestaBD();

            IncidentesPacientes incidentesPacientes = Context.IncidentesPacientes.Where(x => x.IdIncidentesPacientes == actualizarIncidentesPacientes.IdIncidentesPacientes).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(incidentesPacientes);
            if (incidentesPacientes != null)
            {
                IncidentesPacientes pacienteEncontrado = Context.IncidentesPacientes.Where(x => x.HistoriaClinica == actualizarIncidentesPacientes.HistoriaClinica && x.FechaOcurrencia == actualizarIncidentesPacientes.FechaOcurrencia && x.IdIncidentesPacientes != actualizarIncidentesPacientes.IdIncidentesPacientes).FirstOrDefault();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(incidentesPacientes).CurrentValues.SetValues(actualizarIncidentesPacientes);
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = incidentesPacientes.IdIncidentesPacientes;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                    return respuesta;
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

        public async Task<RespuestaBD> EditarIncidentesPacientesAsync(ActualizarIncidentesPacientes actualizarIncidentesPacientes)
        {
            RespuestaBD respuesta = new RespuestaBD();

            IncidentesPacientes incidentesPacientes = await Context.IncidentesPacientes
                                                                .Where(x => x.IdIncidentesPacientes == actualizarIncidentesPacientes.IdIncidentesPacientes)
                                                                .FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(incidentesPacientes);
            if (incidentesPacientes != null)
            {
                IncidentesPacientes pacienteEncontrado = await Context.IncidentesPacientes.Where(x => x.HistoriaClinica == actualizarIncidentesPacientes.HistoriaClinica && x.FechaOcurrencia == actualizarIncidentesPacientes.FechaOcurrencia && x.IdIncidentesPacientes != actualizarIncidentesPacientes.IdIncidentesPacientes).FirstOrDefaultAsync();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(incidentesPacientes).CurrentValues.SetValues(actualizarIncidentesPacientes);
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = incidentesPacientes.IdIncidentesPacientes;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                    return respuesta;
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

        public RespuestaBD EditarIncumplimientoAnalisis(ActualizarIncumplimientoAnalisis actualizarIncumplimientoAnalisis)
        {
            RespuestaBD respuesta = new RespuestaBD();

            IncumplimientoAnalisis incumplimientoAnalisis = Context.IncumplimientoAnalisis.Where(x => x.IdIncumplimientoAnalisis == actualizarIncumplimientoAnalisis.IdIncumplimientoAnalisis).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(incumplimientoAnalisis);
            if (incumplimientoAnalisis != null)
            {
                IncumplimientoAnalisis pacienteEncontrado = Context.IncumplimientoAnalisis.Where(x => x.HistoriaClinica == actualizarIncumplimientoAnalisis.HistoriaClinica && x.FechaOcurrencia == actualizarIncumplimientoAnalisis.FechaOcurrencia && x.IdIncumplimientoAnalisis != actualizarIncumplimientoAnalisis.IdIncumplimientoAnalisis).FirstOrDefault();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(incumplimientoAnalisis).CurrentValues.SetValues(actualizarIncumplimientoAnalisis);
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = incumplimientoAnalisis.IdIncumplimientoAnalisis;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                    return respuesta;
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

        public async Task<RespuestaBD> EditarIncumplimientoAnalisisAsync(ActualizarIncumplimientoAnalisis actualizarIncumplimientoAnalisis)
        {
            RespuestaBD respuesta = new RespuestaBD();

            IncumplimientoAnalisis incumplimientoAnalisis = await Context.IncumplimientoAnalisis
                                                                    .Where(x => x.IdIncumplimientoAnalisis == actualizarIncumplimientoAnalisis.IdIncumplimientoAnalisis)
                                                                    .FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(incumplimientoAnalisis);
            if (incumplimientoAnalisis != null)
            {
                IncumplimientoAnalisis pacienteEncontrado = await Context.IncumplimientoAnalisis
                                                                    .Where(x => x.HistoriaClinica == actualizarIncumplimientoAnalisis.HistoriaClinica && x.FechaOcurrencia == actualizarIncumplimientoAnalisis.FechaOcurrencia && x.IdIncumplimientoAnalisis != actualizarIncumplimientoAnalisis.IdIncumplimientoAnalisis)
                                                                    .FirstOrDefaultAsync();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(incumplimientoAnalisis).CurrentValues.SetValues(actualizarIncumplimientoAnalisis);
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = incumplimientoAnalisis.IdIncumplimientoAnalisis;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                    return respuesta;
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

        public RespuestaBD EditarPruebasNoRealizadas(ActualizarPruebasNoRealizadas actualizarPruebasNoRealizadas)
        {
            RespuestaBD respuesta = new RespuestaBD();

            PruebasNoRealizadas pruebasNoRealizadas = Context.PruebasNoRealizadas.Where(x => x.IdPruebasNoRealizadas == actualizarPruebasNoRealizadas.IdPruebasNoRealizadas).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(pruebasNoRealizadas);
            if (pruebasNoRealizadas != null)
            {
                PruebasNoRealizadas pacienteEncontrado = Context.PruebasNoRealizadas.Where(x => x.HistoriaClinica == actualizarPruebasNoRealizadas.HistoriaClinica && x.FechaOcurrencia == actualizarPruebasNoRealizadas.FechaOcurrencia && x.IdPruebasNoRealizadas != actualizarPruebasNoRealizadas.IdPruebasNoRealizadas).FirstOrDefault();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(pruebasNoRealizadas).CurrentValues.SetValues(actualizarPruebasNoRealizadas);
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = pruebasNoRealizadas.IdPruebasNoRealizadas;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                    return respuesta;
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

        public async Task<RespuestaBD> EditarPruebasNoRealizadasAsync(ActualizarPruebasNoRealizadas actualizarPruebasNoRealizadas)
        {
            RespuestaBD respuesta = new RespuestaBD();

            PruebasNoRealizadas pruebasNoRealizadas = await Context.PruebasNoRealizadas
                                                            .Where(x => x.IdPruebasNoRealizadas == actualizarPruebasNoRealizadas.IdPruebasNoRealizadas)
                                                            .FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(pruebasNoRealizadas);
            if (pruebasNoRealizadas != null)
            {
                PruebasNoRealizadas pacienteEncontrado = await Context.PruebasNoRealizadas.Where(x => x.HistoriaClinica == actualizarPruebasNoRealizadas.HistoriaClinica && x.FechaOcurrencia == actualizarPruebasNoRealizadas.FechaOcurrencia && x.IdPruebasNoRealizadas != actualizarPruebasNoRealizadas.IdPruebasNoRealizadas).FirstOrDefaultAsync();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(pruebasNoRealizadas).CurrentValues.SetValues(actualizarPruebasNoRealizadas);
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = pruebasNoRealizadas.IdPruebasNoRealizadas;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                    return respuesta;
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

        public RespuestaBD EditarRecoleccionMuestra(ActualizarRecoleccionMuestra actualizarRecoleccionMuestra)
        {
            RespuestaBD respuesta = new RespuestaBD();

            RecoleccionMuestra recoleccionMuestra = Context.RecoleccionMuestra.Where(x => x.IdRecoleccionMuestra == actualizarRecoleccionMuestra.IdRecoleccionMuestra).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(recoleccionMuestra);
            if (recoleccionMuestra != null)
            {
                RecoleccionMuestra pacienteEncontrado = Context.RecoleccionMuestra.Where(x => x.HistoriaClinica == actualizarRecoleccionMuestra.HistoriaClinica && x.FechaOcurrencia == actualizarRecoleccionMuestra.FechaOcurrencia && x.IdRecoleccionMuestra != actualizarRecoleccionMuestra.IdRecoleccionMuestra).FirstOrDefault();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(recoleccionMuestra).CurrentValues.SetValues(actualizarRecoleccionMuestra);
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = recoleccionMuestra.IdRecoleccionMuestra;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                    return respuesta;
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

        public async Task<RespuestaBD> EditarRecoleccionMuestraAsync(ActualizarRecoleccionMuestra actualizarRecoleccionMuestra)
        {
            RespuestaBD respuesta = new RespuestaBD();

            RecoleccionMuestra recoleccionMuestra = await Context.RecoleccionMuestra
                                                            .Where(x => x.IdRecoleccionMuestra == actualizarRecoleccionMuestra.IdRecoleccionMuestra)
                                                            .FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(recoleccionMuestra);
            if (recoleccionMuestra != null)
            {
                RecoleccionMuestra pacienteEncontrado = await Context.RecoleccionMuestra
                                                                    .Where(x => x.HistoriaClinica == actualizarRecoleccionMuestra.HistoriaClinica && x.FechaOcurrencia == actualizarRecoleccionMuestra.FechaOcurrencia && x.IdRecoleccionMuestra != actualizarRecoleccionMuestra.IdRecoleccionMuestra)
                                                                    .FirstOrDefaultAsync();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(recoleccionMuestra).CurrentValues.SetValues(actualizarRecoleccionMuestra);
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = recoleccionMuestra.IdRecoleccionMuestra;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                    return respuesta;
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

        public RespuestaBD EditarVenopunturasFallidas(ActualizarVenopunturasFallidas actualizarVenopunturasFallidas)
        {
            RespuestaBD respuesta = new RespuestaBD();

            VenopunturasFallidas venopunturasFallidas = Context.VenopunturasFallidas.Where(x => x.IdVenopunturasFallidas == actualizarVenopunturasFallidas.IdVenopunturasFallidas).FirstOrDefault();
            string valoresAntiguos = JsonConvert.SerializeObject(venopunturasFallidas);
            if (venopunturasFallidas != null)
            {
                VenopunturasFallidas pacienteEncontrado = Context.VenopunturasFallidas.Where(x => x.HistoriaClinica == actualizarVenopunturasFallidas.HistoriaClinica && x.FechaOcurrencia == actualizarVenopunturasFallidas.FechaOcurrencia && x.IdVenopunturasFallidas != actualizarVenopunturasFallidas.IdVenopunturasFallidas).FirstOrDefault();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(venopunturasFallidas).CurrentValues.SetValues(actualizarVenopunturasFallidas);
                    Context.SaveChanges();
                    //Mensaje de respuesta
                    respuesta.Id = venopunturasFallidas.IdVenopunturasFallidas;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                    return respuesta;
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

        public async Task<RespuestaBD> EditarVenopunturasFallidasAsync(ActualizarVenopunturasFallidas actualizarVenopunturasFallidas)
        {
            RespuestaBD respuesta = new RespuestaBD();

            VenopunturasFallidas venopunturasFallidas = await Context.VenopunturasFallidas
                                                                .Where(x => x.IdVenopunturasFallidas == actualizarVenopunturasFallidas.IdVenopunturasFallidas)
                                                                .FirstOrDefaultAsync();
            string valoresAntiguos = JsonConvert.SerializeObject(venopunturasFallidas);
            if (venopunturasFallidas != null)
            {
                VenopunturasFallidas pacienteEncontrado = await Context.VenopunturasFallidas
                                                                    .Where(x => x.HistoriaClinica == actualizarVenopunturasFallidas.HistoriaClinica && x.FechaOcurrencia == actualizarVenopunturasFallidas.FechaOcurrencia && x.IdVenopunturasFallidas != actualizarVenopunturasFallidas.IdVenopunturasFallidas)
                                                                    .FirstOrDefaultAsync();
                if (pacienteEncontrado == null)
                {
                    Context.Entry(venopunturasFallidas).CurrentValues.SetValues(actualizarVenopunturasFallidas);
                    await Context.SaveChangesAsync();
                    //Mensaje de respuesta
                    respuesta.Id = venopunturasFallidas.IdVenopunturasFallidas;
                    respuesta.Mensaje = "Se modificó los datos correctamente.";
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El paciente ya se encuentra registrado para esta fecha.";
                    return respuesta;
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

        public IncidentesPacientes EncontrarIncidentesPacientes(int Id)
        {
            return Context.IncidentesPacientes.Where(x => x.IdIncidentesPacientes == Id).FirstOrDefault();
        }

        public async Task<IncidentesPacientes> EncontrarIncidentesPacientesAsync(int Id)
        {
            return await Context.IncidentesPacientes.Where(x => x.IdIncidentesPacientes == Id).FirstOrDefaultAsync();
        }

        public IncumplimientoAnalisis EncontrarIncumplimientoAnalisis(int Id)
        {
            return Context.IncumplimientoAnalisis.Where(x => x.IdIncumplimientoAnalisis == Id).FirstOrDefault();
        }

        public async Task<IncumplimientoAnalisis> EncontrarIncumplimientoAnalisisAsync(int Id)
        {
            return await Context.IncumplimientoAnalisis.Where(x => x.IdIncumplimientoAnalisis == Id).FirstOrDefaultAsync();
        }

        public PruebasNoRealizadas EncontrarPruebasNoRealizadas(int Id)
        {
            return Context.PruebasNoRealizadas.Where(x => x.IdPruebasNoRealizadas == Id).FirstOrDefault();
        }

        public async Task<PruebasNoRealizadas> EncontrarPruebasNoRealizadasAsync(int Id)
        {
            return await Context.PruebasNoRealizadas.Where(x => x.IdPruebasNoRealizadas == Id).FirstOrDefaultAsync();
        }

        public RecoleccionMuestra EncontrarRecoleccionMuestra(int Id)
        {
            return Context.RecoleccionMuestra.Where(x => x.IdRecoleccionMuestra == Id).FirstOrDefault();
        }

        public async Task<RecoleccionMuestra> EncontrarRecoleccionMuestraAsync(int Id)
        {
            return await Context.RecoleccionMuestra.Where(x => x.IdRecoleccionMuestra == Id).FirstOrDefaultAsync();
        }

        public VenopunturasFallidas EncontrarVenopunturasFallidas(int Id)
        {
            return Context.VenopunturasFallidas.Where(x => x.IdVenopunturasFallidas == Id).FirstOrDefault();
        }

        public async Task<VenopunturasFallidas> EncontrarVenopunturasFallidasAsync(int Id)
        {
            return await Context.VenopunturasFallidas.Where(x => x.IdVenopunturasFallidas == Id).FirstOrDefaultAsync();
        }

        public IEnumerable<IncidentesPacientesGeneral> ListarIncidentesPacientes()
        {
            return Context.IncidentesPacientes
                                      .Select(x => Mapper.Map<IncidentesPacientesGeneral>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<IncidentesPacientesGeneral>> ListarIncidentesPacientesAsync(int? Id)
        {
            return await Context.IncidentesPacientes
                                      .Select(x => Mapper.Map<IncidentesPacientesGeneral>(x))
                                      .ToListAsync();
        }

        public IEnumerable<IncumplimientoAnalisisGeneral> ListarIncumplimientoAnalisis()
        {
            return Context.IncumplimientoAnalisis
                                      .Select(x => Mapper.Map<IncumplimientoAnalisisGeneral>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<IncumplimientoAnalisisGeneral>> ListarIncumplimientoAnalisisAsync(int? Id)
        {
            return await Context.IncumplimientoAnalisis
                                      .Select(x => Mapper.Map<IncumplimientoAnalisisGeneral>(x))
                                      .ToListAsync();
        }

        public IEnumerable<PruebasNoRealizadasGeneral> ListarPruebasNoRealizadas()
        {
            return Context.PruebasNoRealizadas
                                      .Select(x => Mapper.Map<PruebasNoRealizadasGeneral>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<PruebasNoRealizadasGeneral>> ListarPruebasNoRealizadasAsync(int? Id)
        {
            return await Context.PruebasNoRealizadas
                                      .Select(x => Mapper.Map<PruebasNoRealizadasGeneral>(x))
                                      .ToListAsync();
        }

        public IEnumerable<RecoleccionMuestraGeneral> ListarRecoleccionMuestra()
        {
            return Context.RecoleccionMuestra
                                      .Select(x => Mapper.Map<RecoleccionMuestraGeneral>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<RecoleccionMuestraGeneral>> ListarRecoleccionMuestraAsync(int? Id)
        {
            return await Context.RecoleccionMuestra
                                      .Select(x => Mapper.Map<RecoleccionMuestraGeneral>(x))
                                      .ToListAsync();
        }

        public IEnumerable<VenopunturasFallidasGeneral> ListarVenopunturasFallidas()
        {
            return Context.VenopunturasFallidas
                                      .Select(x => Mapper.Map<VenopunturasFallidasGeneral>(x))
                                      .ToList();
        }

        public async Task<IEnumerable<VenopunturasFallidasGeneral>> ListarVenopunturasFallidasAsync(int? Id)
        {
            return await Context.VenopunturasFallidas
                                      .Select(x => Mapper.Map<VenopunturasFallidasGeneral>(x))
                                      .ToListAsync();
        }
    }
}
