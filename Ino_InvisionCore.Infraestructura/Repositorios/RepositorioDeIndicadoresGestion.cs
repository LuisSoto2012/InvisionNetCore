using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.IndicadoresGestion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.RendimientoHoraTrabajador.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Laboratorio;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.IndicadoresGestion;
using Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeIndicadoresGestion : IRepositorioDeIndicadoresGestion
    {
        private readonly InoContext Context;

        public RepositorioDeIndicadoresGestion(InoContext context)
        {
            Context = context;
        }

        public RespuestaBD AgregarExamenAtendidoPorServicio(NuevoExamenAtendidoPorServicio request)
        {
            RespuestaBD respuesta = new RespuestaBD();

            ExamenAtendidoPorServicioModel examen = Mapper.Map<ExamenAtendidoPorServicioModel>(request);
            Context.ExamenesAtendidosPorServicio.Add(examen);
            try
            {
                Context.SaveChanges();
                //Mensaje de respuesta
                respuesta.Id = 1;
                respuesta.Mensaje = "Se ingresó los datos correctamente.";
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Ha ocurrido un error.";
            }
           
            return respuesta;
        }

        public RespuestaBD EditarExamenAtendidoPorServicio(ActualizarExamenAtendidoPorServicio request)
        {
            RespuestaBD respuesta = new RespuestaBD();

            ExamenAtendidoPorServicioModel examen = Context.ExamenesAtendidosPorServicio.Where(x => x.IdExamen == request.IdExamen).FirstOrDefault();
            if (examen != null)
            {
                Context.Entry(examen).CurrentValues.SetValues(request);
                Context.SaveChanges();
                //Mensaje de respuesta
                respuesta.Id = request.IdExamen;
                respuesta.Mensaje = "Se modificó los datos correctamente.";

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public RespuestaBD AgregarExamenNoInformadoPorServicio(NuevoExamenNoInformadoPorServicio request)
        {
            RespuestaBD respuesta = new RespuestaBD();

            ExamenNoInformadoPorServicioModel examen = Mapper.Map<ExamenNoInformadoPorServicioModel>(request);
            Context.ExamenesNoInformadosPorServicio.Add(examen);
            try
            {
                Context.SaveChanges();
                //Mensaje de respuesta
                respuesta.Id = 1;
                respuesta.Mensaje = "Se ingresó los datos correctamente.";
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Ha ocurrido un error.";
            }

            return respuesta;
        }

        public RespuestaBD EditarExamenNoInformadoPorServicio(ActualizarExamenNoInformadoPorServicio request)
        {
            RespuestaBD respuesta = new RespuestaBD();

            ExamenNoInformadoPorServicioModel examen = Context.ExamenesNoInformadosPorServicio.Where(x => x.IdExamen == request.IdExamen).FirstOrDefault();
            if (examen != null)
            {
                Context.Entry(examen).CurrentValues.SetValues(request);
                Context.SaveChanges();
                //Mensaje de respuesta
                respuesta.Id = request.IdExamen;
                respuesta.Mensaje = "Se modificó los datos correctamente.";

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public RespuestaBD AgregarRendimientoHoraTrabajador(NuevoRendimientoHoraTrabajador nuevoRendimientoHoraTrabajador)
        {
            RespuestaBD respuesta = new RespuestaBD();

            RendimientoHoraTrabajador rendimientoHoraTrabajador = Mapper.Map<RendimientoHoraTrabajador>(nuevoRendimientoHoraTrabajador);
            Context.RendimientoHoraTrabajador.Add(rendimientoHoraTrabajador);
            Context.SaveChanges();

            //Mensaje de respuesta
            respuesta.Id = rendimientoHoraTrabajador.IdRendimientoHoraTrabajador;
            respuesta.Mensaje = "Se ingresó los datos correctamente.";

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarRendimientoHoraTrabajadorAsync(NuevoRendimientoHoraTrabajador nuevoRendimientoHoraTrabajador)
        {
            RespuestaBD respuesta = new RespuestaBD();

            RendimientoHoraTrabajador rendimientoHoraTrabajador = Mapper.Map<RendimientoHoraTrabajador>(nuevoRendimientoHoraTrabajador);
            await Context.RendimientoHoraTrabajador.AddAsync(rendimientoHoraTrabajador);
            try
            {
                await Context.SaveChangesAsync();
                //Mensaje de respuesta
                respuesta.Id = rendimientoHoraTrabajador.IdRendimientoHoraTrabajador;
                respuesta.Mensaje = "Se ingresó los datos correctamente.";
            }
            catch (Exception ex)
            {

            }

            return respuesta;
        }

        public RespuestaBD EditarRendimientoHoraTrabajador(ActualizarRendimientoHoraTrabajador actualizarRendimientoHoraTrabajador)
        {
            RespuestaBD respuesta = new RespuestaBD();

            RendimientoHoraTrabajador rendimientoHoraTrabajador = Context.RendimientoHoraTrabajador.Where(x => x.IdRendimientoHoraTrabajador == actualizarRendimientoHoraTrabajador.IdRendimientoHoraTrabajador).FirstOrDefault();
            if (rendimientoHoraTrabajador != null)
            {
                Context.Entry(rendimientoHoraTrabajador).CurrentValues.SetValues(actualizarRendimientoHoraTrabajador);
                Context.SaveChanges();
                //Mensaje de respuesta
                respuesta.Id = rendimientoHoraTrabajador.IdRendimientoHoraTrabajador;
                respuesta.Mensaje = "Se modificó los datos correctamente.";

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EditarRendimientoHoraTrabajadorAsync(ActualizarRendimientoHoraTrabajador actualizarRendimientoHoraTrabajador)
        {
            RespuestaBD respuesta = new RespuestaBD();

            RendimientoHoraTrabajador rendimientoHoraTrabajador = await Context.RendimientoHoraTrabajador
                                                                            .Where(x => x.IdRendimientoHoraTrabajador == actualizarRendimientoHoraTrabajador.IdRendimientoHoraTrabajador)
                                                                            .FirstOrDefaultAsync();
            if (rendimientoHoraTrabajador != null)
            {
                Context.Entry(rendimientoHoraTrabajador).CurrentValues.SetValues(actualizarRendimientoHoraTrabajador);
                await Context.SaveChangesAsync();
                //Mensaje de respuesta
                respuesta.Id = rendimientoHoraTrabajador.IdRendimientoHoraTrabajador;
                respuesta.Mensaje = "Se modificó los datos correctamente.";

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El campo solicitado no existe.";
            }

            return respuesta;
        }

        public RendimientoHoraTrabajador EncontrarRendimientoHoraTrabajador(int Id)
        {
            return Context.RendimientoHoraTrabajador.Where(x => x.IdRendimientoHoraTrabajador == Id).FirstOrDefault();
        }

        public async Task<RendimientoHoraTrabajador> EncontrarRendimientoHoraTrabajadorAsync(int Id)
        {
            return await Context.RendimientoHoraTrabajador.Where(x => x.IdRendimientoHoraTrabajador == Id).FirstOrDefaultAsync();
        }

        public IEnumerable<ExamenAtendidoPorServicio> ListarExamenAtendidoPorServicio()
        {
            return Context.ExamenesAtendidosPorServicio.Select(x => Mapper.Map<ExamenAtendidoPorServicio>(x)).ToList();
        }

        public IEnumerable<ExamenNoInformadoPorServicio> ListarExamenNoInformadoPorServicio()
        {
            return Context.ExamenesNoInformadosPorServicio.Select(x => Mapper.Map<ExamenNoInformadoPorServicio>(x)).ToList();
        }

        public IEnumerable<RendimientoHoraTrabajadorGeneral> ListarRendimientoHoraTrabajador()
        {
            return Context.RendimientoHoraTrabajador.Include(x => x.AreaLaboratorio)
                                                    .Select(x => Mapper.Map<RendimientoHoraTrabajadorGeneral>(x))
                                                    .ToList();
        }

        public async Task<IEnumerable<RendimientoHoraTrabajadorGeneral>> ListarRendimientoHoraTrabajadorAsync(int? Id)
        {
            return await Context.RendimientoHoraTrabajador.Include(x => x.AreaLaboratorio)
                                                          .Select(x => Mapper.Map<RendimientoHoraTrabajadorGeneral>(x))
                                                          .ToListAsync();
        }

        public ExamenAtendidoPorServicio EncontrarExamenAtendidoPorServicio(int Id)
        {
            return Context.ExamenesAtendidosPorServicio.Select(x => Mapper.Map<ExamenAtendidoPorServicio>(x)).FirstOrDefault(x => x.IdExamen == Id);
        }

        public ExamenNoInformadoPorServicio EncontrarExamenNoInformadoPorServicio(int Id)
        {
            return Context.ExamenesNoInformadosPorServicio.Select(x => Mapper.Map<ExamenNoInformadoPorServicio>(x)).FirstOrDefault(x => x.IdExamen == Id);
        }
    }
}
