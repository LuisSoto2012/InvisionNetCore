using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.OrdenMedica;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos;
using Ino_InvisionCore.Dominio.Entidades.OrdenMedica;
using Ino_InvisionCore.Dominio.EntidadesView;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeOrdenesMedicas : IRepositorioDeOrdenesMedicas
    {
        private readonly InoContext Context;

        public RepositorioDeOrdenesMedicas(InoContext context)
        {
            Context = context;
        }

        public RespuestaBD AgregarOrdenMedica(NuevaOrdenMedica nuevaOrdenMedica)
        {
            RespuestaBD respuesta = new RespuestaBD();

            OrdenesMedicas pacienteEncontrado = Context.OrdenesMedicas.Where(x => x.Fecha.Day == nuevaOrdenMedica.Fecha.Day &&
                                                        x.Fecha.Month == nuevaOrdenMedica.Fecha.Month &&
                                                        x.Fecha.Year == nuevaOrdenMedica.Fecha.Year &&
                                                        
                                                        x.HistoriaClinica == nuevaOrdenMedica.HistoriaClinica
                                                        && x.IdEspecialidad == nuevaOrdenMedica.IdEspecialidad
                                                        && x.EsActivo).FirstOrDefault();

            bool valido = true;

            if (pacienteEncontrado != null)
            {
                IList<OrdenesMedicasCodigos> ordenesCodigos = Context.OrdenesMedicasCodigos.Where(x => x.IdOrdenMedica == pacienteEncontrado.IdOrdenMedica && nuevaOrdenMedica.OrdenesMedicasCodigos.Select(o => o.IdProcedimiento).Contains(x.IdProcedimiento))
                                                            .ToList();

                if (ordenesCodigos.Count() > 0)
                {
                    valido = false;
                }
                else
                {
                    valido = true;
                }
            }

            

            if (valido)
            {
                if (nuevaOrdenMedica.OrdenesMedicasCodigos.Count > 0)
                {
                    OrdenesMedicas ordenesMedicas = Mapper.Map<OrdenesMedicas>(nuevaOrdenMedica);
                    ordenesMedicas.OrdenesMedicasCodigos.Clear();
                    Context.OrdenesMedicas.Add(ordenesMedicas);
                    Context.SaveChanges();

                    foreach (NuevaOrdenesMedicasCodigos nuevaOrdenesMedicasCodigos in nuevaOrdenMedica.OrdenesMedicasCodigos)
                    {
                        OrdenesMedicasCodigos codigoExistente = Context.OrdenesMedicasCodigos.Where(x => x.IdOrdenMedica == nuevaOrdenesMedicasCodigos.IdOrdenMedica && x.IdProcedimiento == nuevaOrdenesMedicasCodigos.IdProcedimiento).FirstOrDefault();
                        if (codigoExistente == null)
                        {
                            Procedimiento codigoValido = Context.Procedimiento.Where(x => x.IdProcedimiento == nuevaOrdenesMedicasCodigos.IdProcedimiento).FirstOrDefault();
                            if (codigoValido != null)
                            {
                                OrdenesMedicasCodigos ordenesMedicasCodigos = Mapper.Map<OrdenesMedicasCodigos>(nuevaOrdenesMedicasCodigos);
                                ordenesMedicasCodigos.IdOrdenMedica = ordenesMedicas.IdOrdenMedica;
                                ordenesMedicasCodigos.IdUsuarioCreacion = ordenesMedicas.IdUsuarioCreacion;
                                //ordenesMedicasCodigos.OpcionesOrdenMedica.Clear();

                                //ordenesMedicasCodigos.OrdenesMedicasCodigosOpcionesOrdenMedicas.Clear();
                                ordenesMedicasCodigos.OrdenesMedicasCodigosOpcionesOrdenMedicas = new List<OrdenesMedicasCodigosOpcionesOrdenMedica>();
                                Context.OrdenesMedicasCodigos.Add(ordenesMedicasCodigos);

                                if (nuevaOrdenesMedicasCodigos.OpcionesOrdenMedica.Count > 0)
                                {
                                    List<int> idOpciones = nuevaOrdenesMedicasCodigos.OpcionesOrdenMedica.Select(r => r.Id).ToList();
                                    List<OpcionesOrdenMedica> opciones = Context.OpcionesOrdenMedica.Where(r => idOpciones.Contains(r.IdOpcionOrdenMedica)).ToList();
                                    foreach (OpcionesOrdenMedica opcion in opciones)
                                    {
                                        //ordenesMedicasCodigos.OpcionesOrdenMedica.Add(opcion);
                                        ordenesMedicasCodigos.OrdenesMedicasCodigosOpcionesOrdenMedicas.Add(new OrdenesMedicasCodigosOpcionesOrdenMedica { OpcionesOrdenMedica = opcion, OrdenesMedicasCodigos = ordenesMedicasCodigos, IdOpcionOrdenMedica = opcion.IdOpcionOrdenMedica, IdOrdenesMedicasCodigos = ordenesMedicasCodigos.IdOrdenesMedicasCodigos });
                                    }
                                }
                                Context.SaveChanges();
                                //Mensaje de respuesta
                                respuesta.Id = ordenesMedicas.IdOrdenMedica;
                                respuesta.Mensaje = "Se creó la información correctamente.";
                            }
                            else
                            {
                                //Mensaje de respuesta
                                respuesta.Id = 0;
                                respuesta.Mensaje = "El código que desea ingresar no existe.";
                            }
                        }
                    }
                }
                if (respuesta.Id > 0)
                {
                    ;
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se encontró ningún código seleccionado.";
                }

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya cuenta con la subespecialidad seleccionada para la fecha propuesta. Intentar nuevamente.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> AgregarOrdenMedicaAsync(NuevaOrdenMedica nuevaOrdenMedica)
        {
            RespuestaBD respuesta = new RespuestaBD();

            OrdenesMedicas pacienteEncontrado = await Context.OrdenesMedicas.Where(x => x.Fecha.Day == nuevaOrdenMedica.Fecha.Day &&
                                                            x.Fecha.Month == nuevaOrdenMedica.Fecha.Month &&
                                                            x.Fecha.Year == nuevaOrdenMedica.Fecha.Year &&
                                                            x.IdTipoOrdenMedica == nuevaOrdenMedica.IdTipoOrdenMedica &&
                                                            x.HistoriaClinica == nuevaOrdenMedica.HistoriaClinica).FirstOrDefaultAsync();
            if (pacienteEncontrado == null)
            {
                if (nuevaOrdenMedica.OrdenesMedicasCodigos.Count > 0)
                {
                    OrdenesMedicas ordenesMedicas = Mapper.Map<OrdenesMedicas>(nuevaOrdenMedica);
                    ordenesMedicas.OrdenesMedicasCodigos.Clear();
                    await Context.OrdenesMedicas.AddAsync(ordenesMedicas);
                    await Context.SaveChangesAsync();

                    foreach (NuevaOrdenesMedicasCodigos nuevaOrdenesMedicasCodigos in nuevaOrdenMedica.OrdenesMedicasCodigos)
                    {
                        OrdenesMedicasCodigos codigoExistente = await Context.OrdenesMedicasCodigos.Where(x => x.IdOrdenMedica == nuevaOrdenesMedicasCodigos.IdOrdenMedica && x.IdProcedimiento == nuevaOrdenesMedicasCodigos.IdProcedimiento).FirstOrDefaultAsync();
                        if (codigoExistente == null)
                        {
                            Procedimiento codigoValido = await Context.Procedimiento.Where(x => x.IdProcedimiento == nuevaOrdenesMedicasCodigos.IdProcedimiento).FirstOrDefaultAsync();
                            if (codigoValido != null)
                            {
                                OrdenesMedicasCodigos ordenesMedicasCodigos = Mapper.Map<OrdenesMedicasCodigos>(nuevaOrdenesMedicasCodigos);
                                ordenesMedicasCodigos.IdOrdenMedica = ordenesMedicas.IdOrdenMedica;
                                ordenesMedicasCodigos.IdUsuarioCreacion = ordenesMedicas.IdUsuarioCreacion;
                                //ordenesMedicasCodigos.OpcionesOrdenMedica.Clear();
                                ordenesMedicasCodigos.OrdenesMedicasCodigosOpcionesOrdenMedicas.Clear();
                                await Context.OrdenesMedicasCodigos.AddAsync(ordenesMedicasCodigos);

                                if (nuevaOrdenesMedicasCodigos.OpcionesOrdenMedica.Count > 0)
                                {
                                    List<int> idOpciones = nuevaOrdenesMedicasCodigos.OpcionesOrdenMedica.Select(r => r.Id).ToList();
                                    List<OpcionesOrdenMedica> opciones = await Context.OpcionesOrdenMedica.Where(r => idOpciones.Contains(r.IdOpcionOrdenMedica)).ToListAsync();
                                    foreach (OpcionesOrdenMedica opcion in opciones)
                                    {
                                        //ordenesMedicasCodigos.OpcionesOrdenMedica.Add(opcion);
                                        ordenesMedicasCodigos.OrdenesMedicasCodigosOpcionesOrdenMedicas.Add(new OrdenesMedicasCodigosOpcionesOrdenMedica { OpcionesOrdenMedica = opcion, OrdenesMedicasCodigos = ordenesMedicasCodigos, IdOpcionOrdenMedica = opcion.IdOpcionOrdenMedica, IdOrdenesMedicasCodigos = ordenesMedicasCodigos.IdOrdenesMedicasCodigos });
                                    }
                                }
                                await Context.SaveChangesAsync();
                                //Mensaje de respuesta
                                respuesta.Id = ordenesMedicas.IdOrdenMedica;
                                respuesta.Mensaje = "Se creó la información correctamente.";
                            }
                            else
                            {
                                //Mensaje de respuesta
                                respuesta.Id = 0;
                                respuesta.Mensaje = "El código que desea ingresar no existe.";
                            }
                        }
                    }
                }
                if (respuesta.Id > 0)
                {
                    ;
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se encontró ningún código seleccionado.";
                }

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya cuenta con esta orden médica en la fecha propuesta seleccionada, intente de nuevo.";
            }

            return respuesta;
        }

        public async Task<RespuestaBD> EliminarOrdenMedica(int idOrdenMedica)
        {
            RespuestaBD respuesta = new RespuestaBD();

            //1. Obtener OrdenMedica
            OrdenesMedicas ordenMedica = await Context.OrdenesMedicas.FirstOrDefaultAsync(x => x.IdOrdenMedica == idOrdenMedica);
            if (ordenMedica != null)
            {
                ////2. Obtener OrdenesMedicasCodigos
                //IEnumerable<OrdenesMedicasCodigos> listaOMC = await Context.OrdenesMedicasCodigos.Where(x => x.IdOrdenMedica == idOrdenMedica).ToListAsync();
                //if (listaOMC.Count() > 0)
                //{
                //    //3. Obtener OrdenesMedicasCodigos_OpcionesOrdenMedica
                //    IEnumerable<OrdenesMedicasCodigosOpcionesOrdenMedica> listaOMCOOM = await Context.OrdenesMedicasCodigosOpcionesOrdenesMedicas.Where(x => listaOMC.Select(o => o.IdOrdenesMedicasCodigos)
                //                                                                                                                                            .Contains(x.IdOrdenesMedicasCodigos))
                //                                                                                                                                  .ToListAsync();
                //    if (listaOMCOOM.Count() > 0)
                //    {
                //        Context.OrdenesMedicasCodigosOpcionesOrdenesMedicas.RemoveRange(listaOMCOOM);
                //    }

                //    Context.OrdenesMedicasCodigos.RemoveRange(listaOMC);
                //}

                //Context.OrdenesMedicas.Remove(ordenMedica);
                //await Context.SaveChangesAsync();

                ordenMedica.EsActivo = false;
                await Context.SaveChangesAsync();

                respuesta.Id = 1;
                respuesta.Mensaje = "Se ha eliminado correctamente la Orden Medica.";
            }
            else
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "No se ha encontrado la Orden Medica en la BD.";
            }

            

            return respuesta;
        }

        public IEnumerable<OrdenMedicaGeneral> ListarOrdenesMedicas(int? IdUsuario, int? IdOrdenMedica, int? idAtencion)
        {
            var opcionesOrdenMedica = Context.OpcionesOrdenMedica
                                                .Select(x => new OpcionesOrdenMedicaView
                                                {
                                                    IdOpcionOrdenMedica = x.IdOpcionOrdenMedica,
                                                    Descripcion = x.Descripcion
                                                });
            
            var ordenesMedicasCodigos = Context.OrdenesMedicasCodigos
                                            .Include(x => x.Procedimiento)
                                            .Include(x => x.OrdenesMedicasCodigosOpcionesOrdenMedicas)
                                                .ThenInclude(y => y.OpcionesOrdenMedica)
                                            .Select(x => new OrdenesMedicasCodigosView
                                            {
                                                IdOrdenesMedicasCodigos = x.IdOrdenesMedicasCodigos,
                                                Descripcion = x.Descripcion,
                                                IdOrdenMedica = x.IdOrdenMedica,
                                                Procedimiento = x.Procedimiento,
                                                OpcionesOrdenMedica = opcionesOrdenMedica
                                                                            .Where(om => x.OrdenesMedicasCodigosOpcionesOrdenMedicas.Select(y => y.IdOpcionOrdenMedica).Contains(om.IdOpcionOrdenMedica))
                                                                            .ToList()
                                            });

            var ordenesMedicas = Context.OrdenesMedicas
                                  .Include(x => x.TipoOrdenMedica)
                                  .Include(x => x.OrdenesMedicasCodigos)
                                        .ThenInclude(o => o.OrdenesMedicasCodigosOpcionesOrdenMedicas)
                                            .ThenInclude(om => om.OpcionesOrdenMedica)
                                  .Include(x => x.OrdenesMedicasCodigos)
                                        .ThenInclude(o => o.Procedimiento)
                                  .Where(x =>/* (IdUsuario == null || x.IdUsuarioCreacion == IdUsuario) &&*/ (IdOrdenMedica == null || x.IdOrdenMedica == IdOrdenMedica) && (idAtencion == null || x.IdAtencion == idAtencion))
                                  .Where(x => x.EsActivo);

            var result =          ordenesMedicas
                                  .Select(x => new OrdenMedicaView
                                  {
                                      IdUsuarioCreacion = x.IdUsuarioCreacion,
                                      IdOrdenMedica = x.IdOrdenMedica,
                                      HistoriaClinica = x.HistoriaClinica,
                                      NumeroDocumento = x.NumeroDocumento,
                                      Paciente = x.Paciente,
                                      Fecha = x.Fecha.ToString("dd/MM/yyyy"),
                                      IdTipoAnestesia = x.IdTipoAnestesia,
                                      IdTipoUsuario = x.IdTipoUsuario,
                                      FechaRegistro = x.FechaCreacion.ToString("dd/MM/yyyy HH:mm"),
                                      NombreEspecialidad = x.NombreEspecialidad,
                                      TipoOrdenMedica = x.TipoOrdenMedica,
                                      IdAtencion = x.IdAtencion,
                                      TiempoCita = x.TiempoCita,
                                      OrdenesMedicasCodigos = ordenesMedicasCodigos
                                                                    .Where(om => x.OrdenesMedicasCodigos.Select(y => y.IdOrdenesMedicasCodigos).Contains(om.IdOrdenesMedicasCodigos))
                                                                    .ToList()
                                  })
                                  .Select(x => Mapper.Map<OrdenMedicaGeneral>(x))
                                  .ToList();

            //var result = ordenesMedicas
            //                           .ToList()
            //                           .Select(x => Mapper.Map<OrdenMedicaGeneral>(x))
            //                           .ToList();

            return result;

            //return Context.OrdenesMedicas.Where(x => (IdUsuario == null || x.IdUsuarioCreacion == IdUsuario) && (IdOrdenMedica == null || x.IdOrdenMedica == IdOrdenMedica))
            //                      .Include(x => x.TipoOrdenMedica)
            //                      .Include(x => x.OrdenesMedicasCodigos)
            //                            .ThenInclude(o => o.OrdenesMedicasCodigosOpcionesOrdenMedicas)
            //                                .ThenInclude(om => om.OpcionesOrdenMedica)
            //                      .Include(x => x.OrdenesMedicasCodigos)
            //                            .ThenInclude(o => o.Procedimiento)
            //                      .ToList()
            //                      .Select(x => Mapper.Map<OrdenMedicaGeneral>(x))
            //                      .ToList();
        }

        public async Task<IEnumerable<OrdenMedicaGeneral>> ListarOrdenesMedicasPorDocumentoAsync(string numeroDocumento)
        {
            var opcionesOrdenMedica = Context.OpcionesOrdenMedica
                                                .Select(x => new OpcionesOrdenMedicaView
                                                {
                                                    IdOpcionOrdenMedica = x.IdOpcionOrdenMedica,
                                                    Descripcion = x.Descripcion
                                                });

            var ordenesMedicasCodigos = Context.OrdenesMedicasCodigos
                                            .Include(x => x.Procedimiento)
                                            .Include(x => x.OrdenesMedicasCodigosOpcionesOrdenMedicas)
                                                .ThenInclude(y => y.OpcionesOrdenMedica)
                                            .Select(x => new OrdenesMedicasCodigosView
                                            {
                                                IdOrdenesMedicasCodigos = x.IdOrdenesMedicasCodigos,
                                                Descripcion = x.Descripcion,
                                                IdOrdenMedica = x.IdOrdenMedica,
                                                Procedimiento = x.Procedimiento,
                                                OpcionesOrdenMedica = opcionesOrdenMedica
                                                                            .Where(om => x.OrdenesMedicasCodigosOpcionesOrdenMedicas.Select(y => y.IdOpcionOrdenMedica).Contains(om.IdOpcionOrdenMedica))
                                                                            .ToList()
                                            });

            var ordenesMedicas = Context.OrdenesMedicas
                                  .Include(x => x.TipoOrdenMedica)
                                  .Include(x => x.OrdenesMedicasCodigos)
                                        .ThenInclude(o => o.OrdenesMedicasCodigosOpcionesOrdenMedicas)
                                            .ThenInclude(om => om.OpcionesOrdenMedica)
                                  .Include(x => x.OrdenesMedicasCodigos)
                                        .ThenInclude(o => o.Procedimiento)
                                  .Where(x => x.NumeroDocumento == numeroDocumento)
                                  .Where(x => x.EsActivo);

            var result = await ordenesMedicas
                                    .OrderByDescending(x => x.FechaCreacion)
                                  .Select(x => new OrdenMedicaView
                                  {
                                      IdUsuarioCreacion = x.IdUsuarioCreacion,
                                      IdOrdenMedica = x.IdOrdenMedica,
                                      HistoriaClinica = x.HistoriaClinica,
                                      NumeroDocumento = x.NumeroDocumento,
                                      Paciente = x.Paciente,
                                      Fecha = x.Fecha.ToString("dd/MM/yyyy"),
                                      IdTipoAnestesia = x.IdTipoAnestesia,
                                      IdTipoUsuario = x.IdTipoUsuario,
                                      FechaRegistro = x.FechaCreacion.ToString("dd/MM/yyyy HH:mm"),
                                      Medico = x.Medico,
                                      NombreEspecialidad = x.NombreEspecialidad,
                                      TipoOrdenMedica = x.TipoOrdenMedica,
                                      IdAtencion = x.IdAtencion,
                                      TiempoCita = x.TiempoCita,
                                      OrdenesMedicasCodigos = ordenesMedicasCodigos
                                                                    .Where(om => x.OrdenesMedicasCodigos.Select(y => y.IdOrdenesMedicasCodigos).Contains(om.IdOrdenesMedicasCodigos))
                                                                    .ToList()
                                  })
                                  .Select(x => Mapper.Map<OrdenMedicaGeneral>(x))
                                  .ToListAsync();

            return result;

        }

        public async Task<IEnumerable<OrdenMedicaGeneral>> ListarOrdenesMedicasAsync(int? IdUsuario, int? IdOrdenMedica)
        {
            return await Context.OrdenesMedicas.Where(x => (IdUsuario == null || x.IdUsuarioCreacion == IdUsuario) && (IdOrdenMedica == null || x.IdOrdenMedica == IdOrdenMedica))
                                  .Include(x => x.TipoOrdenMedica)
                                  .Include(x => x.OrdenesMedicasCodigos)
                                        .ThenInclude(o => o.OrdenesMedicasCodigosOpcionesOrdenMedicas)
                                            .ThenInclude(om => om.OpcionesOrdenMedica)
                                  .Include(x => x.OrdenesMedicasCodigos)
                                        .ThenInclude(o => o.Procedimiento)
                                  .Select(x => Mapper.Map<OrdenMedicaGeneral>(x))
                                  .ToListAsync();
        }

        public IEnumerable<TipoOrdenMedicaGeneral> ListarTipoOrdenMedica(int? Id)
        {
            List<ProcedimientoDto> procedimientos = (from tomp in Context.TipoOrdenMedica_Procedimiento
                                                     join p in Context.Procedimiento on tomp.IdProcedimiento equals p.IdProcedimiento
                                                     where p.EsActivo == true
                                                     orderby tomp.Orden ascending
                                                     select new ProcedimientoDto
                                                     {
                                                         IdProcedimiento = tomp.IdProcedimiento,
                                                         IdTipoOrdenMedica = tomp.IdTipoOrdenMedica,
                                                         Codigo = p.Codigo,
                                                         Descripcion = p.Descripcion,
                                                         DescripcionCorta = p.DescripcionCorta
                                                     }).ToList();
            return Context.TipoOrdenMedica
                            .Include(x => x.TipoOrdenMedicaRangos)
                            .Where(x => x.EsActivo == true &&
                               (Id == -1 || x.IdEspecialidad == Id) ||
                               x.IdEspecialidad == -1
                              )
                     .ToList()
                     .Select(x => new TipoOrdenMedicaGeneral
                     {
                         Id = x.IdTipoOrdenMedica,
                         Codigo = x.Descripcion.Replace(" ", ""),
                         Descripcion = x.Descripcion,
                         IdEspecialidad = x.IdEspecialidad,
                         TamanoFormulario = x.TamanoFormulario,
                         TituloFormulario = x.TituloFormulario,
                         Procedimiento = procedimientos.Where(y => y.IdTipoOrdenMedica == x.IdTipoOrdenMedica).ToList(),
                         TipoOrdenMedicaRangos = x.TipoOrdenMedicaRangos.Select(y => Mapper.Map<TipoOrdenMedicaRangosDto>(y)).ToList(),
                     })
                     .ToList();
        }

        public async Task<IEnumerable<TipoOrdenMedicaGeneral>> ListarTipoOrdenMedicaAsync(int? Id)
        {
            List<ProcedimientoDto> procedimientos = await (from tomp in Context.TipoOrdenMedica_Procedimiento
                                                     join p in Context.Procedimiento on tomp.IdProcedimiento equals p.IdProcedimiento
                                                     where p.EsActivo == true
                                                     orderby tomp.Orden ascending
                                                     select new ProcedimientoDto
                                                     {
                                                         IdProcedimiento = tomp.IdProcedimiento,
                                                         IdTipoOrdenMedica = tomp.IdTipoOrdenMedica,
                                                         Codigo = p.Codigo,
                                                         Descripcion = p.Descripcion,
                                                         DescripcionCorta = p.DescripcionCorta
                                                     }).ToListAsync();
            return await Context.TipoOrdenMedica
                            .Include(x => x.TipoOrdenMedicaRangos)
                            .Where(x => x.EsActivo == true &&
                               (Id == -1 || x.IdEspecialidad == Id) ||
                               x.IdEspecialidad == -1
                              )
                     .Select(x => new TipoOrdenMedicaGeneral
                     {
                         Id = x.IdTipoOrdenMedica,
                         Codigo = x.Descripcion.Replace(" ", ""),
                         Descripcion = x.Descripcion,
                         IdEspecialidad = x.IdEspecialidad,
                         TamanoFormulario = x.TamanoFormulario,
                         TituloFormulario = x.TituloFormulario,
                         Procedimiento = procedimientos.Where(y => y.IdTipoOrdenMedica == x.IdTipoOrdenMedica).ToList(),
                         TipoOrdenMedicaRangos = x.TipoOrdenMedicaRangos.Select(y => Mapper.Map<TipoOrdenMedicaRangosDto>(y)).ToList(),
                     })
                     .ToListAsync();
        }
    }
}
