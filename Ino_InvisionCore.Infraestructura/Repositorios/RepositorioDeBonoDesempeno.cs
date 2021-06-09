using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.BonoDesempeno;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeBonoDesempeno : IRepositorioDeBonoDesempeno
    {
        private GalenPlusContext Context;

        public RepositorioDeBonoDesempeno(GalenPlusContext context)
        {
            Context = context;
        }

        public IEnumerable<FormatoTrama> ListarDiferimientoCitas(DatosTramaBono datosTramaBono)
        {
            //return Context.Database.SqlQuery<DiferimientoCitas>("dbo.Invision_BonoDesempenoDiferimiento @FechaDesde, @FechaHasta, @IdEspecialidad, @Tipo_Paciente",
            //            new SqlParameter("FechaDesde", datosTramaBono.FechaDesde),
            //            new SqlParameter("FechaHasta", datosTramaBono.FechaHasta),
            //            new SqlParameter("IdEspecialidad", datosTramaBono.IdEspecialidad),
            //            new SqlParameter("Tipo_Paciente", datosTramaBono.Tipo_Paciente)).ToList()
            //            .Select(x => new FormatoTrama
            //            {
            //                id_referencia = x.id_referencia,
            //                id_cita = x.idCita,
            //                tipo = x.tipo,
            //                ipress = new
            //                {
            //                    ipress_id = x.ipress_id,
            //                    diresa_id = x.diressa_id,
            //                    red_id = x.red_id,
            //                    microred_id = x.microred_id
            //                },
            //                paciente = new
            //                {
            //                    seguro_sis = x.seguro_sis,
            //                    documento = new
            //                    {
            //                        tipo = x.documento_tipo,
            //                        numero = x.documento_numero
            //                    },
            //                    nombre = new
            //                    {
            //                        prenombres = x.nombre_prenombres,
            //                        apellido_paterno = x.nombre_paterno,
            //                        apellido_materno = x.nombre_materno
            //                    },
            //                    ubigeo_domicilio = new
            //                    {
            //                        departamento_id = x.departamento_id,
            //                        provincia_id = x.provincia_id,
            //                        distrito_id = x.distrito_id
            //                    }
            //                },
            //                registro = new
            //                {
            //                    inicio = x.fecha_inicio,
            //                    fin = x.fecha_fin
            //                }
            //            }).ToList();

            return Context.Query<DiferimientoCitasConDiasView>().ToList()
                        .Where(x => ((datosTramaBono.Tipo_Paciente == 'T') || x.tipo_paciente == datosTramaBono.Tipo_Paciente) && x.fecha_inicio_dt >= datosTramaBono.FechaDesde
                                && x.fecha_inicio_dt <= datosTramaBono.FechaHasta && (datosTramaBono.IdEspecialidad == 1 || x.idEspecialidad == datosTramaBono.IdEspecialidad)
                                && (datosTramaBono.IdServicio == null || (datosTramaBono.IdServicio == 0 || x.idServicio == datosTramaBono.IdServicio)))
                        .Select(x => new FormatoTrama
                        {
                            id_referencia = x.id_referencia,
                            id_cita = x.idCita,
                            tipo = x.tipo,
                            ipress = new
                            {
                                ipress_id = x.ipress_id,
                                diresa_id = x.diressa_id,
                                red_id = x.red_id,
                                microred_id = x.microred_id
                            },
                            paciente = new
                            {
                                seguro_sis = x.seguro_sis,
                                documento = new
                                {
                                    tipo = x.documento_tipo,
                                    numero = x.documento_numero
                                },
                                nombre = new
                                {
                                    prenombres = x.nombre_prenombres,
                                    apellido_paterno = x.nombre_paterno,
                                    apellido_materno = x.nombre_materno
                                },
                                ubigeo_domicilio = new
                                {
                                    departamento_id = x.departamento_id,
                                    provincia_id = x.provincia_id,
                                    distrito_id = x.distrito_id
                                }
                            },
                            registro = new
                            {
                                inicio = x.fecha_inicio,
                                fin = x.fecha_fin
                            }
                        }).ToList();
        }

        public async Task<IEnumerable<FormatoTrama>> ListarDiferimientoCitasAsync(DatosTramaBono datosTramaBono)
        {
            return await Context.Query<DiferimientoCitasView>().FromSql("dbo.Invision_BonoDesempenoDiferimiento @FechaDesde, @FechaHasta, @IdEspecialidad, @Tipo_Paciente",
                        new SqlParameter("FechaDesde", datosTramaBono.FechaDesde),
                        new SqlParameter("FechaHasta", datosTramaBono.FechaHasta),
                        new SqlParameter("IdEspecialidad", datosTramaBono.IdEspecialidad),
                        new SqlParameter("Tipo_Paciente", datosTramaBono.Tipo_Paciente))
                        .Select(x => new FormatoTrama
                        {
                            id_referencia = x.id_referencia,
                            id_cita = x.idCita,
                            tipo = x.tipo,
                            ipress = new
                            {
                                ipress_id = x.ipress_id,
                                diresa_id = x.diressa_id,
                                red_id = x.red_id,
                                microred_id = x.microred_id
                            },
                            paciente = new
                            {
                                seguro_sis = x.seguro_sis,
                                documento = new
                                {
                                    tipo = x.documento_tipo,
                                    numero = x.documento_numero
                                },
                                nombre = new
                                {
                                    prenombres = x.nombre_prenombres,
                                    apellido_paterno = x.nombre_paterno,
                                    apellido_materno = x.nombre_materno
                                },
                                ubigeo_domicilio = new
                                {
                                    departamento_id = x.departamento_id,
                                    provincia_id = x.provincia_id,
                                    distrito_id = x.distrito_id
                                }
                            },
                            registro = new
                            {
                                inicio = x.fecha_inicio,
                                fin = x.fecha_fin
                            }
                        }).ToListAsync();
        }

        public IEnumerable<FormatoTramaConDias> ListarDiferimientoCitasConDias(DatosTramaBono datosTramaBono)
        {
            //return Context.Database.SqlQuery<DiferimientoCitas>("dbo.Invision_BonoDesempenoDiferimiento @FechaDesde, @FechaHasta, @IdEspecialidad, @Tipo_Paciente",
            //            new SqlParameter("FechaDesde", datosTramaBono.FechaDesde),
            //            new SqlParameter("FechaHasta", datosTramaBono.FechaHasta),
            //            new SqlParameter("IdEspecialidad", datosTramaBono.IdEspecialidad),
            //            new SqlParameter("Tipo_Paciente", datosTramaBono.Tipo_Paciente)).ToList()
            //            .Select(x => new FormatoTramaConDias
            //            {
            //                id_referencia = x.id_referencia,
            //                id_cita = x.idCita,
            //                tipo = x.tipo,
            //                dias = x.dias,
            //                ipress = new
            //                {
            //                    ipress_id = x.ipress_id,
            //                    diresa_id = x.diressa_id,
            //                    red_id = x.red_id,
            //                    microred_id = x.microred_id
            //                },
            //                paciente = new
            //                {
            //                    seguro_sis = x.seguro_sis,
            //                    documento = new
            //                    {
            //                        tipo = x.documento_tipo,
            //                        numero = x.documento_numero
            //                    },
            //                    nombre = new
            //                    {
            //                        prenombres = x.nombre_prenombres,
            //                        apellido_paterno = x.nombre_paterno,
            //                        apellido_materno = x.nombre_materno
            //                    },
            //                    ubigeo_domicilio = new
            //                    {
            //                        departamento_id = x.departamento_id,
            //                        provincia_id = x.provincia_id,
            //                        distrito_id = x.distrito_id
            //                    }
            //                },
            //                registro = new
            //                {
            //                    inicio = x.fecha_inicio,
            //                    fin = x.fecha_fin
            //                }
            //            }).ToList();

            return Context.Query<DiferimientoCitasConDiasView>().ToList()
                        .Where(x => ((datosTramaBono.Tipo_Paciente == 'T') || x.tipo_paciente == datosTramaBono.Tipo_Paciente) && x.fecha_inicio_dt >= datosTramaBono.FechaDesde
                                && x.fecha_inicio_dt <= datosTramaBono.FechaHasta && (datosTramaBono.IdEspecialidad == 1 || x.idEspecialidad == datosTramaBono.IdEspecialidad)
                                && (datosTramaBono.IdServicio == null || (datosTramaBono.IdServicio == 0 || x.idServicio == datosTramaBono.IdServicio)))
                        .Select(x => new FormatoTramaConDias
                        {
                            id_referencia = x.id_referencia,
                            id_cita = x.idCita,
                            tipo = x.tipo,
                            dias = x.dias,
                            ipress = new
                            {
                                ipress_id = x.ipress_id,
                                diresa_id = x.diressa_id,
                                red_id = x.red_id,
                                microred_id = x.microred_id
                            },
                            paciente = new
                            {
                                seguro_sis = x.seguro_sis,
                                documento = new
                                {
                                    tipo = x.documento_tipo,
                                    numero = x.documento_numero
                                },
                                nombre = new
                                {
                                    prenombres = x.nombre_prenombres,
                                    apellido_paterno = x.nombre_paterno,
                                    apellido_materno = x.nombre_materno
                                },
                                ubigeo_domicilio = new
                                {
                                    departamento_id = x.departamento_id,
                                    provincia_id = x.provincia_id,
                                    distrito_id = x.distrito_id
                                }
                            },
                            registro = new
                            {
                                inicio = x.fecha_inicio,
                                fin = x.fecha_fin
                            }
                        }).ToList();
        }

        public async Task<IEnumerable<FormatoTramaConDias>> ListarDiferimientoCitasConDiasAsync(DatosTramaBono datosTramaBono)
        {
            return await Context.Query<DiferimientoCitasView>().FromSql("dbo.Invision_BonoDesempenoDiferimiento @FechaDesde, @FechaHasta, @IdEspecialidad, @Tipo_Paciente",
                        new SqlParameter("FechaDesde", datosTramaBono.FechaDesde),
                        new SqlParameter("FechaHasta", datosTramaBono.FechaHasta),
                        new SqlParameter("IdEspecialidad", datosTramaBono.IdEspecialidad),
                        new SqlParameter("Tipo_Paciente", datosTramaBono.Tipo_Paciente))
                        .Select(x => new FormatoTramaConDias
                        {
                            id_referencia = x.id_referencia,
                            id_cita = x.idCita,
                            tipo = x.tipo,
                            dias = x.dias,
                            ipress = new
                            {
                                ipress_id = x.ipress_id,
                                diresa_id = x.diressa_id,
                                red_id = x.red_id,
                                microred_id = x.microred_id
                            },
                            paciente = new
                            {
                                seguro_sis = x.seguro_sis,
                                documento = new
                                {
                                    tipo = x.documento_tipo,
                                    numero = x.documento_numero
                                },
                                nombre = new
                                {
                                    prenombres = x.nombre_prenombres,
                                    apellido_paterno = x.nombre_paterno,
                                    apellido_materno = x.nombre_materno
                                },
                                ubigeo_domicilio = new
                                {
                                    departamento_id = x.departamento_id,
                                    provincia_id = x.provincia_id,
                                    distrito_id = x.distrito_id
                                }
                            },
                            registro = new
                            {
                                inicio = x.fecha_inicio,
                                fin = x.fecha_fin
                            }
                        }).ToListAsync();
        }

        public IEnumerable<TiempoEsperaAtencion> ListarTiempoEsperaAtencion(DatosTramaBono datosTramaBono)
        {
            //return Context.Database.SqlQuery<TiempoEsperaAtencion>("dbo.Invision_IndicadoresDeDesempeno @FechaDesde, @FechaHasta, @IdEspecialidad",
            //            new SqlParameter("FechaDesde", datosTramaBono.FechaDesde),
            //            new SqlParameter("FechaHasta", datosTramaBono.FechaHasta),
            //            new SqlParameter("IdEspecialidad", datosTramaBono.IdEspecialidad)).ToList();

            return Context.Query<TiempoEsperaAtencionView>().FromSql("dbo.Invision_IndicadoresDeDesempeno @FechaDesde, @FechaHasta, @IdEspecialidad",
                        new SqlParameter("FechaDesde", datosTramaBono.FechaDesde),
                        new SqlParameter("FechaHasta", datosTramaBono.FechaHasta),
                        new SqlParameter("IdEspecialidad", datosTramaBono.IdEspecialidad)).ToList().Select(x => Mapper.Map<TiempoEsperaAtencion>(x)).ToList();
        }

        public async Task<IEnumerable<TiempoEsperaAtencion>> ListarTiempoEsperaAtencionAsync(DatosTramaBono datosTramaBono)
        {
            return await Context.Query<TiempoEsperaAtencionView>().FromSql("dbo.Invision_IndicadoresDeDesempeno @FechaDesde, @FechaHasta, @IdEspecialidad",
                            new SqlParameter("FechaDesde", datosTramaBono.FechaDesde),
                            new SqlParameter("FechaHasta", datosTramaBono.FechaHasta),
                            new SqlParameter("IdEspecialidad", datosTramaBono.IdEspecialidad)).Select(x => Mapper.Map<TiempoEsperaAtencion>(x)).ToListAsync();
        }
    }
}
