using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.AccidenteDeTrabajo;
using Ino_InvisionCore.Dominio.Entidades.AccidenteDeTrabajo;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Infraestructura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeAccidentesTrabajo : IRepositorioDeAccidentesTrabajo
    {
        private readonly InoContext Context;

        public RepositorioDeAccidentesTrabajo(InoContext context)
        {
            Context = context;
        }

        public RespuestaBD RegistrarAccidenteDeTrabajo(RegistroAccidenteDeTrabajo request)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                AccidenteDeTrabajo accidenteDeTrabajo = Mapper.Map<AccidenteDeTrabajo>(request);

                string agente_CausaAccidente = "";
                string mecanismo_CausaAccidente = "";
                string lesion_CausaAccidente = "";
                string cuerpo_CausaAccidente = "";

                for (int i = 0; i < request.AgenteAccidente_CausaAccidente.Count; ++i)
                {
                    agente_CausaAccidente += request.AgenteAccidente_CausaAccidente[i] + (i == request.AgenteAccidente_CausaAccidente.Count - 1 ? "" : "*");
                }

                for (int i = 0; i < request.MecanismoFormaAccidente_CausaAccidente.Count; ++i)
                {
                    mecanismo_CausaAccidente += request.MecanismoFormaAccidente_CausaAccidente[i] + (i == request.MecanismoFormaAccidente_CausaAccidente.Count - 1 ? "" : "*");
                }

                for (int i = 0; i < request.TipoLesion_CausaAccidente.Count; ++i)
                {
                    lesion_CausaAccidente += request.TipoLesion_CausaAccidente[i] + (i == request.TipoLesion_CausaAccidente.Count - 1 ? "" : "*");
                }

                for (int i = 0; i < request.ParteCuerpo_CausaAccidente.Count; ++i)
                {
                    cuerpo_CausaAccidente += request.ParteCuerpo_CausaAccidente[i] + (i == request.ParteCuerpo_CausaAccidente.Count - 1 ? "" : "*");
                }

                accidenteDeTrabajo.AgenteAccidente_CausaAccidente = agente_CausaAccidente;
                accidenteDeTrabajo.MecanismoFormaAccidente_CausaAccidente = mecanismo_CausaAccidente;
                accidenteDeTrabajo.TipoLesion_CausaAccidente = lesion_CausaAccidente;
                accidenteDeTrabajo.ParteCuerpo_CausaAccidente = cuerpo_CausaAccidente;

                IList<Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones.MedidaCorrectivaDto> listMedidaCorrectiva = request.MedidasCorrectivas;

                string desc_MedidaCorrectiva = "";
                string resp_MedidaCorrectiva = "";
                string fec_MedidcaCorrectiva = "";
                string estado_MedidaCorrectiva = "";

                for (int i = 0; i < listMedidaCorrectiva.Count; ++i)
                {
                    desc_MedidaCorrectiva += listMedidaCorrectiva[i].Descripcion_MedidaCorrectiva + (i == listMedidaCorrectiva.Count - 1 ? "" : "*");
                    resp_MedidaCorrectiva += listMedidaCorrectiva[i].Responsable_MedidaCorrectiva + (i == listMedidaCorrectiva.Count - 1 ? "" : "*");
                    fec_MedidcaCorrectiva += listMedidaCorrectiva[i].FechaEjecucion_MedidaCorrectiva.ToString("yyyy-MM-dd") + (i == listMedidaCorrectiva.Count - 1 ? "" : "*");
                    estado_MedidaCorrectiva += listMedidaCorrectiva[i].EstadoImplementacion_MedidaCorrectiva + (i == listMedidaCorrectiva.Count - 1 ? "" : "*");
                }

                accidenteDeTrabajo.Descripcion_MedidaCorrectiva = desc_MedidaCorrectiva;
                accidenteDeTrabajo.Responsable_MedidaCorrectiva = resp_MedidaCorrectiva;
                accidenteDeTrabajo.FechaEjecucion_MedidaCorrectiva = fec_MedidcaCorrectiva;
                accidenteDeTrabajo.EstadoImplementacion_MedidaCorrectiva = estado_MedidaCorrectiva;

                IList<Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones.RegistroInvestigacionDto> listRegistroInvestigacion = request.RegistrosInvestigacion;

                string nomb_RegistroInvestigacion = "";
                string cargo_RegistroInvestigacion = "";
                string fec_RegistroInvestigacion = "";

                for (int i = 0; i < listRegistroInvestigacion.Count; ++i)
                {
                    nomb_RegistroInvestigacion += listRegistroInvestigacion[i].NombreResponsable_RegistroInvestigacion + (i == listRegistroInvestigacion.Count - 1 ? "" : "*");
                    cargo_RegistroInvestigacion += listRegistroInvestigacion[i].CargoResponsable_RegistroInvestigacion + (i == listRegistroInvestigacion.Count - 1 ? "" : "*");
                    fec_RegistroInvestigacion += listRegistroInvestigacion[i].Fecha_RegistroInvestigacion.ToString("yyyy-MM-dd") + (i == listRegistroInvestigacion.Count - 1 ? "" : "*");
                }

                accidenteDeTrabajo.NombreResponsable_RegistroInvestigacion = nomb_RegistroInvestigacion;
                accidenteDeTrabajo.CargoResponsable_RegistroInvestigacion = cargo_RegistroInvestigacion;
                accidenteDeTrabajo.Fecha_RegistroInvestigacion = fec_RegistroInvestigacion;

                Context.AccidentesDeTrabajo.Add(accidenteDeTrabajo);

                Context.SaveChanges();

                respuesta.Id = 1;
                respuesta.Mensaje = "Se ha registrado el accidente de trabajo correctamente";
            }
            catch (Exception)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Ha ocurrido un error";
            }

            return respuesta;
        }

        public RespuestaBD ActualizarAccidenteDeTrabajo(ActualizarAccidenteDeTrabajo request)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                AccidenteDeTrabajo accidenteDeTrabajoPorId = Context.AccidentesDeTrabajo.FirstOrDefault(x => x.IdRegistroAccidenteDeTrabajo == request.IdRegistroAccidenteDeTrabajo);

                if (accidenteDeTrabajoPorId == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "El registro no existe";
                }
                else
                {
                    Context.Entry(accidenteDeTrabajoPorId).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    AccidenteDeTrabajo accidenteDeTrabajo = Mapper.Map<AccidenteDeTrabajo>(request);
                    //Context.Entry(accidenteDeTrabajoPorId).CurrentValues.SetValues(request);

                    string agente_CausaAccidente = "";
                    string mecanismo_CausaAccidente = "";
                    string lesion_CausaAccidente = "";
                    string cuerpo_CausaAccidente = "";

                    for (int i = 0; i < request.AgenteAccidente_CausaAccidente.Count; ++i)
                    {
                        agente_CausaAccidente += request.AgenteAccidente_CausaAccidente[i] + (i == request.AgenteAccidente_CausaAccidente.Count - 1 ? "" : "*");
                    }

                    for (int i = 0; i < request.MecanismoFormaAccidente_CausaAccidente.Count; ++i)
                    {
                        mecanismo_CausaAccidente += request.MecanismoFormaAccidente_CausaAccidente[i] + (i == request.MecanismoFormaAccidente_CausaAccidente.Count - 1 ? "" : "*");
                    }

                    for (int i = 0; i < request.TipoLesion_CausaAccidente.Count; ++i)
                    {
                        lesion_CausaAccidente += request.TipoLesion_CausaAccidente[i] + (i == request.TipoLesion_CausaAccidente.Count - 1 ? "" : "*");
                    }

                    for (int i = 0; i < request.ParteCuerpo_CausaAccidente.Count; ++i)
                    {
                        cuerpo_CausaAccidente += request.ParteCuerpo_CausaAccidente[i] + (i == request.ParteCuerpo_CausaAccidente.Count - 1 ? "" : "*");
                    }

                    accidenteDeTrabajo.AgenteAccidente_CausaAccidente = agente_CausaAccidente;
                    accidenteDeTrabajo.MecanismoFormaAccidente_CausaAccidente = mecanismo_CausaAccidente;
                    accidenteDeTrabajo.TipoLesion_CausaAccidente = lesion_CausaAccidente;
                    accidenteDeTrabajo.ParteCuerpo_CausaAccidente = cuerpo_CausaAccidente;

                    IList<Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones.MedidaCorrectivaDto> listMedidaCorrectiva = request.MedidasCorrectivas;

                    string desc_MedidaCorrectiva = "";
                    string resp_MedidaCorrectiva = "";
                    string fec_MedidcaCorrectiva = "";
                    string estado_MedidaCorrectiva = "";

                    for (int i = 0; i < listMedidaCorrectiva.Count; ++i)
                    {
                        desc_MedidaCorrectiva += listMedidaCorrectiva[i].Descripcion_MedidaCorrectiva + (i == listMedidaCorrectiva.Count - 1 ? "" : "*");
                        resp_MedidaCorrectiva += listMedidaCorrectiva[i].Responsable_MedidaCorrectiva + (i == listMedidaCorrectiva.Count - 1 ? "" : "*");
                        fec_MedidcaCorrectiva += listMedidaCorrectiva[i].FechaEjecucion_MedidaCorrectiva.ToString("yyyy-MM-dd") + (i == listMedidaCorrectiva.Count - 1 ? "" : "*");
                        estado_MedidaCorrectiva += listMedidaCorrectiva[i].EstadoImplementacion_MedidaCorrectiva + (i == listMedidaCorrectiva.Count - 1 ? "" : "*");
                    }

                    accidenteDeTrabajo.Descripcion_MedidaCorrectiva = desc_MedidaCorrectiva;
                    accidenteDeTrabajo.Responsable_MedidaCorrectiva = resp_MedidaCorrectiva;
                    accidenteDeTrabajo.FechaEjecucion_MedidaCorrectiva = fec_MedidcaCorrectiva;
                    accidenteDeTrabajo.EstadoImplementacion_MedidaCorrectiva = estado_MedidaCorrectiva;

                    IList<Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones.RegistroInvestigacionDto> listRegistroInvestigacion = request.RegistrosInvestigacion;

                    string nomb_RegistroInvestigacion = "";
                    string cargo_RegistroInvestigacion = "";
                    string fec_RegistroInvestigacion = "";

                    for (int i = 0; i < listRegistroInvestigacion.Count; ++i)
                    {
                        nomb_RegistroInvestigacion += listRegistroInvestigacion[i].NombreResponsable_RegistroInvestigacion + (i == listRegistroInvestigacion.Count - 1 ? "" : "*");
                        cargo_RegistroInvestigacion += listRegistroInvestigacion[i].CargoResponsable_RegistroInvestigacion + (i == listRegistroInvestigacion.Count - 1 ? "" : "*");
                        fec_RegistroInvestigacion += listRegistroInvestigacion[i].Fecha_RegistroInvestigacion.ToString("yyyy-MM-dd") + (i == listRegistroInvestigacion.Count - 1 ? "" : "*");
                    }

                    accidenteDeTrabajo.NombreResponsable_RegistroInvestigacion = nomb_RegistroInvestigacion;
                    accidenteDeTrabajo.CargoResponsable_RegistroInvestigacion = cargo_RegistroInvestigacion;
                    accidenteDeTrabajo.Fecha_RegistroInvestigacion = fec_RegistroInvestigacion;

                    Context.Attach(accidenteDeTrabajo);

                    Context.Entry(accidenteDeTrabajo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    Context.SaveChanges();

                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se ha actualizado el accidente de trabajo correctamente";
                }        
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Ha ocurrido un error";
            }

            return respuesta;
        }

        public IEnumerable<AccidenteDeTrabajoDto> ListarAccidenteDeTrabajo()
        {
            var list = Context.AccidentesDeTrabajo.ToList();

            var listR = list.Select(x => Mapper.Map<AccidenteDeTrabajoDto>(x)).ToList();

            foreach (var e in listR)
            {
                var accidente = Context.AccidentesDeTrabajo.FirstOrDefault(x => x.IdRegistroAccidenteDeTrabajo == e.IdRegistroAccidenteDeTrabajo);

                e.AgenteAccidente_CausaAccidente = accidente.AgenteAccidente_CausaAccidente.Split("*");
                e.MecanismoFormaAccidente_CausaAccidente = accidente.MecanismoFormaAccidente_CausaAccidente.Split("*");
                e.TipoLesion_CausaAccidente = accidente.TipoLesion_CausaAccidente.Split("*");
                e.ParteCuerpo_CausaAccidente = accidente.ParteCuerpo_CausaAccidente.Split("*");

                IList<string> desc_MedidaCorrectiva = accidente.Descripcion_MedidaCorrectiva == null? new string[] { } : accidente.Descripcion_MedidaCorrectiva.Split("*");
                IList<string> resp_MedidaCorrectiva = accidente.Responsable_MedidaCorrectiva == null? new string[] { } : accidente.Responsable_MedidaCorrectiva.Split("*");
                IList<string> fec_MedidaCorrectiva = accidente.FechaEjecucion_MedidaCorrectiva == null ? new string[] { } : accidente.FechaEjecucion_MedidaCorrectiva.Split("*");
                IList<string> estado_MedidaCorrectiva = accidente.EstadoImplementacion_MedidaCorrectiva == null? new string[] { } : accidente.EstadoImplementacion_MedidaCorrectiva.Split("*");

                IList<Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas.MedidaCorrectivaDto> medidasDto = new List<Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas.MedidaCorrectivaDto>();

                for (int i = 0; i < desc_MedidaCorrectiva.Count; ++i)
                {
                    Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas.MedidaCorrectivaDto medidaCorrectivaDto = new Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas.MedidaCorrectivaDto
                    {
                        Descripcion_MedidaCorrectiva = desc_MedidaCorrectiva[i],
                        Responsable_MedidaCorrectiva = resp_MedidaCorrectiva[i],
                        FechaEjecucion_MedidaCorrectiva = fec_MedidaCorrectiva[i],
                        EstadoImplementacion_MedidaCorrectiva = estado_MedidaCorrectiva[i]
                    };

                    medidasDto.Add(medidaCorrectivaDto);
                }

                e.MedidasCorrectivas = medidasDto;

                IList<string> nomb_RegistroInvestigacion = accidente.NombreResponsable_RegistroInvestigacion == null ? new string[] { } : accidente.NombreResponsable_RegistroInvestigacion.Split("*");
                IList<string> cargo_RegistroInvestigacion = accidente.CargoResponsable_RegistroInvestigacion == null ? new string[] { } : accidente.CargoResponsable_RegistroInvestigacion.Split("*");
                IList<string> fec_RegistroInvestigacion = accidente.Fecha_RegistroInvestigacion == null ? new string[] { } : accidente.Fecha_RegistroInvestigacion.Split("*");

                IList<Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas.RegistroInvestigacionDto> registrosDto = new List<Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas.RegistroInvestigacionDto>();

                for (int i = 0; i < nomb_RegistroInvestigacion.Count; ++i)
                {
                    Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas.RegistroInvestigacionDto registroDto = new Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas.RegistroInvestigacionDto
                    {
                        NombreResponsable_RegistroInvestigacion = nomb_RegistroInvestigacion[i],
                        CargoResponsable_RegistroInvestigacion = cargo_RegistroInvestigacion[i],
                        Fecha_RegistroInvestigacion = fec_RegistroInvestigacion[i]
                    };

                    registrosDto.Add(registroDto);
                }

                e.RegistrosInvestigacion = registrosDto;

            }

            return listR;

        }

        public AccidenteDeTrabajo ObtenerAccidenteDeTrabajo(int id)
        {
            return Context.AccidentesDeTrabajo.FirstOrDefault(x => x.IdRegistroAccidenteDeTrabajo == id);
        }
    }
}
