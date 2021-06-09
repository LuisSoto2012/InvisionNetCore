using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.RecetaMedica.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.RecetaMedica;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.OrdenMedica;
using Ino_InvisionCore.Dominio.Entidades.RecetaMedica;
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
    public class RepositorioDeRecetasMedicas : IRepositorioDeRecetasMedicas
    {
        private readonly InoContext InoContext;
        private readonly GalenPlusContext GalenPlusContext;

        public RepositorioDeRecetasMedicas(InoContext inoContext, GalenPlusContext galenPlusContext)
        {
            InoContext = inoContext;
            GalenPlusContext = galenPlusContext;
        }

        public RespuestaBD AgregarRecetaMedicaEstandar(NuevaRecetaMedicaEstandar parametros)
        {
            RespuestaBD respuesta = new RespuestaBD();

            RecetaMedicaEstandar recetaEstandarEncontrada = InoContext.RecetasMedicasEstandar.Where(x => x.IdAtencion == parametros.IdAtencion).FirstOrDefault();

            if (recetaEstandarEncontrada == null)
            {
                if (parametros.Medicamentos.Count > 0)
                {
                    RecetaMedicaEstandar receta = Mapper.Map<RecetaMedicaEstandar>(parametros);
                    try
                    {
                        InoContext.RecetasMedicasEstandar.Add(receta);
                        InoContext.SaveChanges();
                        respuesta.Id = receta.IdRecetaMedica;
                        respuesta.Mensaje = "Se creó la receta médica correctamente.";
                    }
                    catch (Exception ex)
                    {
                        respuesta.Id = 0;
                        respuesta.Mensaje = "Error en el servidor";
                    }
                    
                }
                else
                {
                    //Mensaje de respuesta
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se encontró ningún medicamento seleccionado.";
                }

            }
            else
            {
                //Mensaje de respuesta
                respuesta.Id = 0;
                respuesta.Mensaje = "El paciente ya cuenta con una receta médica estandar para la atención seleccionada.";
            }

            return respuesta;
        }

        public IEnumerable<MedicamentoGeneral> ListarMedicamentos(bool sisFlag)
        {
            return GalenPlusContext.Query<MedicamentoView>().FromSql("dbo.Invision_ListarMedicamentosAlmacen @SIS_FLAG",
                            new SqlParameter("SIS_FLAG", sisFlag))
                                        .ToList()
                                        .Select(x => Mapper.Map<MedicamentoGeneral>(x))
                                        .ToList();
        }

        public IEnumerable<RecetaMedicaEstandarDTO> ListarRecetaMedicaEstandar(string historiaClinica)
        {
            var empleados = InoContext.Empleados.ToList();

            //var medicamentos = InoContext.Medicamentos.Include(x => x.RecetaMedicaEstandar)
            //                                          .Where(x => x.RecetaMedicaEstandar.HistoriaClinica == historiaClinica)
            //                                          .Select(x => Mapper.Map<MedicamentoDTO>(x))
            //                                          .ToList();

            return InoContext.RecetasMedicasEstandar.Where(x => x.HistoriaClinica == historiaClinica)
                                                    .Select(x => new RecetaMedicaEstandarDTO
                                                    { 
                                                        FechaEmision = x.FechaCreacion.ToString("yyyy-MM-dd"),
                                                        Medico = empleados.FirstOrDefault(y => y.IdEmpleado == x.IdUsuarioCreacion).Nombres + empleados.FirstOrDefault(y => y.IdEmpleado == x.IdUsuarioCreacion).ApellidoPaterno + empleados.FirstOrDefault(y => y.IdEmpleado == x.IdUsuarioCreacion).ApellidoMaterno,
                                                        IdRecetaMedica = x.IdRecetaMedica,
                                                        OtrosMedicamentos = x.OtrosMedicamentos,
                                                        Observaciones = x.Observaciones,
                                                        Medicamentos = x.Medicamentos.Select(m => new MedicamentoDTO
                                                        {
                                                            Nombre = m.Nombre,
                                                            ForFarm = m.ForFarm,
                                                            Cantidad = m.Cantidad,
                                                            Ojo = m.Ojo,
                                                            Indicacion = m.Indicacion,
                                                            Via = m.ViaAdministracion
                                                        }).ToList()
                                                    })
                                                    .ToList();
        }

        public RecetaMedicaEstandarImprimirDTO ImprimirRecetaMedicaEstandar(int idRecetaMedica)
        {
            var empleados = InoContext.Empleados.ToList();

            var medicamentos = InoContext.Medicamentos.Include(x => x.RecetaMedicaEstandar)
                                                      .Where(x => x.RecetaMedicaEstandar.IdRecetaMedica == idRecetaMedica)
                                                      .Select(x => Mapper.Map<MedicamentoDTO>(x))
                                                      .ToList();

            return InoContext.RecetasMedicasEstandar.Where(x => x.IdRecetaMedica == idRecetaMedica)
                                                    .Select(x => new RecetaMedicaEstandarImprimirDTO
                                                    {
                                                        FechaEmision = x.FechaCreacion.ToString("yyyy-MM-dd"),
                                                        Medico = empleados.FirstOrDefault(y => y.IdEmpleado == x.IdUsuarioCreacion).Nombres + empleados.FirstOrDefault(y => y.IdEmpleado == x.IdUsuarioCreacion).ApellidoPaterno + empleados.FirstOrDefault(y => y.IdEmpleado == x.IdUsuarioCreacion).ApellidoMaterno,
                                                        IdRecetaMedica = x.IdRecetaMedica,
                                                        Medicamentos = medicamentos,
                                                        NroDocumento = x.NroDocumento,
                                                        Paciente = x.Paciente,
                                                        HistoriaClinica = x.HistoriaClinica,
                                                        Diagnostico = x.Diagnostico,
                                                        CodigoCIE10 = x.CodigoCIE10,
                                                        ValidoHasta = x.ValidoHasta.ToString("yyyy-MM-dd")
                                                    })
                                                    .FirstOrDefault();
        }

        public async Task<RecetaMedicaEstandarDTO> ObtenerRecetaMedicaPorAtencion(int idAtencion)
        {
            var receta = await InoContext.RecetasMedicasEstandar.Include(x => x.Medicamentos)
                                                                .FirstOrDefaultAsync(x => x.IdAtencion == idAtencion);

            if (receta == null)
                return null;
            else
            {
                RecetaMedicaEstandarDTO dto = new RecetaMedicaEstandarDTO
                {
                    IdRecetaMedica = receta.IdRecetaMedica,
                    FechaEmision = receta.FechaCreacion.ToString("yyyy-MM-dd"),
                    ValidoHasta = receta.ValidoHasta.ToString("yyyy-MM-dd"),
                    OtrosMedicamentos = receta.OtrosMedicamentos,
                    Observaciones = receta.Observaciones,
                    Medicamentos = receta.Medicamentos.Select(m => new MedicamentoDTO
                    {
                        IdMedicamento = m.IdMedicamento,
                        IdRecetaMedica = m.IdRecetaMedica,
                        Nombre = m.Nombre,
                        ForFarm = m.ForFarm,
                        Cantidad = m.Cantidad,
                        Ojo = m.Ojo,
                        Indicacion = m.Indicacion,
                        Via = m.ViaAdministracion
                    }).ToList()
                };

                return dto;
            }
        }

        public async Task<RespuestaBD> ModificarRecetaMedicaEstandar(ModificarRecetaMedicaEstandarDto dto)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                //Obtener receta
                RecetaMedicaEstandar receta = await InoContext.RecetasMedicasEstandar.Include(x => x.Medicamentos).FirstOrDefaultAsync(x => x.IdRecetaMedica == dto.IdRecetaMedica);

                if (receta == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado información en la base de datos.";
                }
                else
                {
                    InoContext.Medicamentos.RemoveRange(receta.Medicamentos);
                    await InoContext.SaveChangesAsync();
                    receta.ValidoHasta = dto.ValidoHasta;
                    receta.Observaciones = dto.Observaciones;
                    receta.OtrosMedicamentos = dto.OtrosMedicamentos;
                    IList<Medicamento> nuevosMedicamentos = new List<Medicamento>();
                    foreach (var e in dto.Medicamentos)
                    {
                        nuevosMedicamentos.Add(new Medicamento
                        {
                            IdRecetaMedica = dto.IdRecetaMedica,
                            Nombre = e.Nombre,
                            ForFarm = e.ForFarm,
                            Cantidad = e.Cantidad,
                            Ojo = e.Ojo,
                            Indicacion = e.Indicacion,
                            ViaAdministracion = e.Via,
                        });
                    }
                    InoContext.Medicamentos.AddRange(nuevosMedicamentos);
                    receta.FechaModificacion = DateTime.Now;
                    receta.IdUsuarioModificacion = dto.IdUsuarioModificacion;
                    await InoContext.SaveChangesAsync();
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se ha modificado la receta médica correctamente"; 
                }
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }

            return respuesta;
        }

        public async Task<IEnumerable<RecetaMedicaPorDocDto>> ListarRecetasPorDocumento(string numeroDocumento)
        {
            return await InoContext.RecetasMedicasEstandar.Where(x => x.NroDocumento == numeroDocumento && x.EsActivo)
                                   .OrderByDescending(x => x.FechaCreacion)
                                   .Select(x => new RecetaMedicaPorDocDto
                                   {
                                       IdRecetaMedica = x.IdRecetaMedica,
                                       FechaCreacion = x.FechaCreacion.ToString("dd/MM/yyyy HH:mm"),
                                       Medico = x.Medico
                                   })
                                   .ToListAsync();
        }
    }
}
