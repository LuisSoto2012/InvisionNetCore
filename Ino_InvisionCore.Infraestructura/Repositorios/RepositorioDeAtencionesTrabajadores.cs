 using AutoMapper;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionTrabajador.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.AtencionTrabajador;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Infraestructura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeAtencionesTrabajadores : IRepositorioDeAtencionesTrabajadores
    {
        private InoContext Context;

        public RepositorioDeAtencionesTrabajadores(InoContext context)
        {
            Context = context;
        }

        public IEnumerable<AtencionTrabajadorGeneral> ListarAtencionTrabajador(int? Id)
        {
            return Context.AtencionTrabajador.Where(x => x.EsActivo == true &&
                                                  (Id == null || x.IdAtencionTrabajador == Id))
                                            .ToList()
                                            .Select(x => Mapper.Map<AtencionTrabajadorGeneral>(x))
                                            .ToList();
        }

        public async Task<IEnumerable<AtencionTrabajadorGeneral>> ListarAtencionTrabajadorAsync(int? Id)
        {
            return await Context.AtencionTrabajador.Where(x => x.EsActivo == true &&
                                                  (Id == null || x.IdAtencionTrabajador == Id))
                                            .Select(x => Mapper.Map<AtencionTrabajadorGeneral>(x))
                                            .ToListAsync();
        }

        public RespuestaBD RegistrarAtencionTrabajador(NuevaAtencionTrabajador nuevaAtencionTrabajador)
        {
            RespuestaBD respuesta = new RespuestaBD();

            AtencionTrabajador pacienteEncontrado = Context.AtencionTrabajador.Where(x => x.FechaCreacion.Day == DateTime.Now.Day &&
                                                        x.FechaCreacion.Month == DateTime.Now.Month &&
                                                        x.FechaCreacion.Year == DateTime.Now.Year &&
                                                        x.HistoriaClinica == nuevaAtencionTrabajador.HistoriaClinica).FirstOrDefault();
            if (pacienteEncontrado == null)
            {
                AtencionTrabajador atencionTrabajador = Mapper.Map<AtencionTrabajador>(nuevaAtencionTrabajador);
                Context.AtencionTrabajador.Add(atencionTrabajador);
                Context.SaveChanges();

                foreach (var diagnostico in nuevaAtencionTrabajador.Diagnosticos)
                {
                    AtencionTrabajador_Diagnostico atencion_Diagnostico = new AtencionTrabajador_Diagnostico
                    {
                        IdAtencionTrabajador = atencionTrabajador.IdAtencionTrabajador,
                        IdDiagnostico = diagnostico.Id,
                        TipoDiagnostico = diagnostico.Codigo,
                        IdUsuarioCreacion = nuevaAtencionTrabajador.IdUsuarioCreacion
                    };
                    Context.AtencionTrabajador_Diagnostico.Add(atencion_Diagnostico);
                    Context.SaveChanges();
                }

                //Mensaje de respuesta
                respuesta.Id = atencionTrabajador.IdAtencionTrabajador;
                respuesta.Mensaje = "Se guardó la atención correctamente.";

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya cuenta con un registro para el día de hoy, intente de nuevo.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> RegistrarAtencionTrabajadorAsync(NuevaAtencionTrabajador nuevaAtencionTrabajador)
        {
            RespuestaBD respuesta = new RespuestaBD();

            AtencionTrabajador pacienteEncontrado = await Context.AtencionTrabajador.Where(x => x.FechaCreacion.Day == DateTime.Now.Day &&
                                                                x.FechaCreacion.Month == DateTime.Now.Month &&
                                                                x.FechaCreacion.Year == DateTime.Now.Year &&
                                                                x.HistoriaClinica == nuevaAtencionTrabajador.HistoriaClinica).FirstOrDefaultAsync();
            if (pacienteEncontrado == null)
            {
                AtencionTrabajador atencionTrabajador = Mapper.Map<AtencionTrabajador>(nuevaAtencionTrabajador);
                await Context.AtencionTrabajador.AddAsync(atencionTrabajador);
                await Context.SaveChangesAsync();

                foreach (var diagnostico in nuevaAtencionTrabajador.Diagnosticos)
                {
                    AtencionTrabajador_Diagnostico atencion_Diagnostico = new AtencionTrabajador_Diagnostico
                    {
                        IdAtencionTrabajador = atencionTrabajador.IdAtencionTrabajador,
                        IdDiagnostico = diagnostico.Id,
                        TipoDiagnostico = diagnostico.Codigo,
                        IdUsuarioCreacion = nuevaAtencionTrabajador.IdUsuarioCreacion
                    };
                    await Context.AtencionTrabajador_Diagnostico.AddAsync(atencion_Diagnostico);
                    await Context.SaveChangesAsync();
                }

                //Mensaje de respuesta
                respuesta.Id = atencionTrabajador.IdAtencionTrabajador;
                respuesta.Mensaje = "Se guardó la atención correctamente.";

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya cuenta con un registro para el día de hoy, intente de nuevo.";
            }

            return respuesta;
        }
    }
}
