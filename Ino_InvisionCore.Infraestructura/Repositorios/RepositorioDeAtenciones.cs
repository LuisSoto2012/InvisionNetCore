using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Atencion;
using Ino_InvisionCore.Dominio.Entidades.AtencionCE;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.EvaluacionesExamenes;
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
    public class RepositorioDeAtenciones : IRepositorioDeAtenciones
    {
        private readonly GalenPlusContext GalenPlusContext;
        private readonly InoContext InoContext;

        public RepositorioDeAtenciones(GalenPlusContext galenPlusContext, InoContext inoContext)
        {
            GalenPlusContext = galenPlusContext;
            InoContext = inoContext;
        }

        public RespuestaBD RegistrarAtencion(RegistroAtencion nuevaAtencion)
        {
            try
            {
                var result = GalenPlusContext.Database.ExecuteSqlCommand("dbo.INO_Teleconsulta_CEAtencionesRegistrar @IdCita,@NroHistoriaClinica,@Paciente,@IdMedico,@Medico,@IdEspecialidad,@Especialidad,@IdServicio,@Servicio,@Financiamiento," +
                    "@Diacod1,@Diades1,@IdTipoDiagnostico1,@Diacod2,@Diades2,@IdTipoDiagnostico2,@Diacod3,@Diades3,@IdTipoDiagnostico3,@FechaAtencion,@IdUsuario,@Usuario,@CodProc1,@Coddes1,@CodProc2," +
                    "@Coddes2,@CodProc3,@Coddes3,@IdResidente,@Residente,@IdTipoCondicionEstablecimiento,@IdTipoCondicionServicio,@Diacod1_OI,@Diades1_OI,@IdTipoDiagnostico1_OI,@Diacod2_OI,@Diades2_OI," +
                    "@IdTipoDiagnostico2_OI,@Diacod3_OI,@Diades3_OI,@IdTipoDiagnostico3_OI,@CodProc1_OI,@Coddes1_OI,@CodProc2_OI,@Coddes2_OI,@CodProc3_OI,@Coddes3_OI,@AVOD,@AVOI,@Anamnesis",
                    new SqlParameter("IdCita", nuevaAtencion.IdCita),
                    new SqlParameter("NroHistoriaClinica", nuevaAtencion.NroHistoriaClinica),
                    new SqlParameter("Paciente", nuevaAtencion.Paciente),
                    new SqlParameter("IdMedico", nuevaAtencion.IdMedico),
                    new SqlParameter("Medico", nuevaAtencion.Medico),
                    new SqlParameter("IdEspecialidad", nuevaAtencion.IdEspecialidad),
                    new SqlParameter("Especialidad", nuevaAtencion.Especialidad),
                    new SqlParameter("IdServicio", nuevaAtencion.IdServicio),
                    new SqlParameter("Servicio", nuevaAtencion.Servicio),
                    new SqlParameter("Financiamiento", nuevaAtencion.Financiamiento),
                    new SqlParameter("Diacod1", nuevaAtencion.Diacod1),
                    new SqlParameter("Diades1", nuevaAtencion.Diades1),
                    new SqlParameter("IdTipoDiagnostico1", nuevaAtencion.IdTipoDiagnostico1),
                    new SqlParameter("Diacod2", nuevaAtencion.Diacod2),
                    new SqlParameter("Diades2", nuevaAtencion.Diades2),
                    new SqlParameter("IdTipoDiagnostico2", nuevaAtencion.IdTipoDiagnostico2),
                    new SqlParameter("Diacod3", nuevaAtencion.Diacod3),
                    new SqlParameter("Diades3", nuevaAtencion.Diades3),
                    new SqlParameter("IdTipoDiagnostico3", nuevaAtencion.IdTipoDiagnostico3),
                    new SqlParameter("FechaAtencion", nuevaAtencion.FechaAtencion),
                    new SqlParameter("IdUsuario", nuevaAtencion.IdUsuario),
                    new SqlParameter("Usuario", nuevaAtencion.Usuario),
                    new SqlParameter("CodProc1", nuevaAtencion.CodProc1),
                    new SqlParameter("Coddes1", nuevaAtencion.Coddes1),
                    new SqlParameter("CodProc2", nuevaAtencion.CodProc2),
                    new SqlParameter("Coddes2", nuevaAtencion.Coddes2),
                    new SqlParameter("CodProc3", nuevaAtencion.CodProc3),
                    new SqlParameter("Coddes3", nuevaAtencion.Coddes3),
                    new SqlParameter("IdResidente", nuevaAtencion.IdResidente),
                    new SqlParameter("Residente", nuevaAtencion.Residente),
                    new SqlParameter("IdTipoCondicionEstablecimiento", nuevaAtencion.IdTipoCondicionEstablecimiento),
                    new SqlParameter("IdTipoCondicionServicio", nuevaAtencion.IdTipoCondicionServicio),
                    new SqlParameter("Diacod1_OI", nuevaAtencion.Diacod1_OI),
                    new SqlParameter("Diades1_OI", nuevaAtencion.Diades1_OI),
                    new SqlParameter("IdTipoDiagnostico1_OI", nuevaAtencion.IdTipoDiagnostico1_OI),
                    new SqlParameter("codigo", nuevaAtencion.IdCita),
                    new SqlParameter("Diacod2_OI", nuevaAtencion.Diacod2_OI),
                    new SqlParameter("Diades2_OI", nuevaAtencion.Diades2_OI),
                    new SqlParameter("IdTipoDiagnostico2_OI", nuevaAtencion.IdTipoDiagnostico2_OI),
                    new SqlParameter("Diacod3_OI", nuevaAtencion.Diacod3_OI),
                    new SqlParameter("Diades3_OI", nuevaAtencion.Diades3_OI),
                    new SqlParameter("IdTipoDiagnostico3_OI", nuevaAtencion.IdTipoDiagnostico3_OI),
                    new SqlParameter("CodProc1_OI", nuevaAtencion.CodProc1_OI),
                    new SqlParameter("Coddes1_OI", nuevaAtencion.Coddes1_OI),
                    new SqlParameter("CodProc2_OI", nuevaAtencion.CodProc2_OI),
                    new SqlParameter("Coddes2_OI", nuevaAtencion.Coddes2_OI),
                    new SqlParameter("CodProc3_OI", nuevaAtencion.CodProc3_OI),
                    new SqlParameter("Coddes3_OI", nuevaAtencion.Coddes3_OI),
                    new SqlParameter("AVOD", nuevaAtencion.Avod),
                    new SqlParameter("AVOI", nuevaAtencion.Avoi),
                    new SqlParameter("Anamnesis", nuevaAtencion.Anamnesis));

                if (result > 0)
                {
                    var listResult = GalenPlusContext.Query<AtencionCEView>().FromSql("dbo.INO_Teleconsulta_ObtenerIdAtencionPorCita @IdCita",
                            new SqlParameter("IdCita", nuevaAtencion.IdCita))
                         .ToList();

                    AtencionCE atencionCE = new AtencionCE
                    {
                        IdAtencionGalenos = listResult[0].IdAtencion,
                        MotivoConsulta = nuevaAtencion.MotivoConsulta,
                        TiempoEnfermedad = nuevaAtencion.TiempoEnfermedad,
                        DesarrolloCronologico = nuevaAtencion.DesarrolloCronologico,
                        Pa = nuevaAtencion.Pa,
                        Fc = nuevaAtencion.Fc,
                        Fr = nuevaAtencion.Fr,
                        T = nuevaAtencion.T,
                        SatO2 = nuevaAtencion.SatO2,
                        AvConAEOD = nuevaAtencion.AvConAEOD,
                        AvConAEOI = nuevaAtencion.AvConAEOI,
                        AvSinCorreccionOD = nuevaAtencion.AvSinCorreccionOD,
                        AvSinCorreccionOI = nuevaAtencion.AvSinCorreccionOI,
                        PioOD = nuevaAtencion.PioOD,
                        PioOI = nuevaAtencion.PioOI,
                        ParpadoOD = nuevaAtencion.ParpadoOD,
                        ParpadoOI = nuevaAtencion.ParpadoOI,
                        ConjuntivaOD = nuevaAtencion.ConjuntivaOD,
                        ConjuntivaOI = nuevaAtencion.ConjuntivaOI,
                        CorneaOD = nuevaAtencion.CorneaOD,
                        CorneaOI = nuevaAtencion.CorneaOI,
                        AvConCorreccionOD = nuevaAtencion.AvConCorreccionOD,
                        AvConCorreccionOI = nuevaAtencion.AvConCorreccionOI,
                        CristalinoOD = nuevaAtencion.CristalinoOD,
                        CristalinoOI = nuevaAtencion.CristalinoOI,
                        PupilarOD = nuevaAtencion.PupilarOD,
                        PupilarOI = nuevaAtencion.PupilarOI,
                        VitreoOD = nuevaAtencion.VitreoOD,
                        VitreoOI = nuevaAtencion.VitreoOI,
                        NervioOpticoOD = nuevaAtencion.NervioOpticoOD,
                        NervioOpticoOI = nuevaAtencion.NervioOpticoOI,
                        MaculaOD = nuevaAtencion.MaculaOD,
                        MaculaOI = nuevaAtencion.MaculaOI,
                        RetinaOD = nuevaAtencion.RetinaOD,
                        RetinaOI = nuevaAtencion.RetinaOI,
                        ImagenOjos = string.IsNullOrEmpty(nuevaAtencion.ImagenOjos) ? null : Convert.FromBase64String(nuevaAtencion.ImagenOjos.Split(";base64,")[1]),
                        ProximaCita = nuevaAtencion.ProximaCita,
                        PlanDeTrabajo = nuevaAtencion.PlanDeTrabajo,
                        IdUsuarioRegistro = nuevaAtencion.IdUsuario,
                        FechaRegistro = DateTime.Now,
                        Observaciones = nuevaAtencion.Observaciones,
                        MedidasGenerales = nuevaAtencion.MedidasGenerales
                    };

                    InoContext.AtencionesCE.Add(atencionCE);
                    InoContext.SaveChanges();

                    return new RespuestaBD
                    {
                        Id = listResult[0].IdAtencion,
                        Mensaje = "Registro satisfactorio.\nAhora puede ingresar sus ordenes médicas y/o recetas. Caso contrario, hacer click en cerrar."
                    };
                }
                else
                {
                    return new RespuestaBD
                    {
                        Id = 0,
                        Mensaje = "No se ha podido registrar la atención."
                    };
                }
            }
            catch (Exception ex)
            {
                return new RespuestaBD
                {
                    Id = 0,
                    Mensaje = ex.ToString()
                };
            }
        }

        public async Task<RespuestaBD> RegistrarAtencionAsync(RegistroAtencion nuevaAtencion)
        {
            await GalenPlusContext.Database.ExecuteSqlCommandAsync("dbo.INO_CEAtencionesRegistrar @IdCita,@NroHistoriaClinica,@Paciente,@IdMedico,@Medico,@IdEspecialidad,@Especialidad,@IdServicio,@Servicio,@Financiamiento," +
                    "@Diacod1,@Diades1,@IdTipoDiagnostico1,@Diacod2,@Diades2,@IdTipoDiagnostico2,@Diacod3,@Diades3,@IdTipoDiagnostico3,@FechaAtencion,@IdUsuario,@Usuario,@CodProc1,@Coddes1,@CodProc2," +
                    "@Coddes2,@CodProc3,@Coddes3,@IdResidente,@Residente,@IdTipoCondicionEstablecimiento,@IdTipoCondicionServicio,@Diacod1_OI,@Diades1_OI,@IdTipoDiagnostico1_OI,@Diacod2_OI,@Diades2_OI," +
                    "@IdTipoDiagnostico2_OI,@Diacod3_OI,@Diades3_OI,@IdTipoDiagnostico3_OI,@CodProc1_OI,@Coddes1_OI,@CodProc2_OI,@Coddes2_OI,@CodProc3_OI,@Coddes3_OI,@AVOD,@AVOI",
                    new SqlParameter("IdCita", nuevaAtencion.IdCita),
                    new SqlParameter("NroHistoriaClinica", nuevaAtencion.NroHistoriaClinica),
                    new SqlParameter("Paciente", nuevaAtencion.Paciente),
                    new SqlParameter("IdMedico", nuevaAtencion.IdMedico),
                    new SqlParameter("Medico", nuevaAtencion.Medico),
                    new SqlParameter("IdEspecialidad", nuevaAtencion.IdEspecialidad),
                    new SqlParameter("Especialidad", nuevaAtencion.Especialidad),
                    new SqlParameter("IdServicio", nuevaAtencion.IdServicio),
                    new SqlParameter("Servicio", nuevaAtencion.Servicio),
                    new SqlParameter("Financiamiento", nuevaAtencion.Financiamiento),
                    new SqlParameter("Diacod1", nuevaAtencion.Diacod1),
                    new SqlParameter("Diades1", nuevaAtencion.Diades1),
                    new SqlParameter("IdTipoDiagnostico1", nuevaAtencion.IdTipoDiagnostico1),
                    new SqlParameter("Diacod2", nuevaAtencion.Diacod2),
                    new SqlParameter("Diades2", nuevaAtencion.Diades2),
                    new SqlParameter("IdTipoDiagnostico2", nuevaAtencion.IdTipoDiagnostico2),
                    new SqlParameter("Diacod3", nuevaAtencion.Diacod3),
                    new SqlParameter("Diades3", nuevaAtencion.Diades3),
                    new SqlParameter("IdTipoDiagnostico3", nuevaAtencion.IdTipoDiagnostico3),
                    new SqlParameter("FechaAtencion", nuevaAtencion.FechaAtencion),
                    new SqlParameter("IdUsuario", nuevaAtencion.IdUsuario),
                    new SqlParameter("Usuario", nuevaAtencion.Usuario),
                    new SqlParameter("CodProc1", nuevaAtencion.CodProc1),
                    new SqlParameter("Coddes1", nuevaAtencion.Coddes1),
                    new SqlParameter("CodProc2", nuevaAtencion.CodProc2),
                    new SqlParameter("Coddes2", nuevaAtencion.Coddes2),
                    new SqlParameter("CodProc3", nuevaAtencion.CodProc3),
                    new SqlParameter("Coddes3", nuevaAtencion.Coddes3),
                    new SqlParameter("IdResidente", nuevaAtencion.IdResidente),
                    new SqlParameter("Residente", nuevaAtencion.Residente),
                    new SqlParameter("IdTipoCondicionEstablecimiento", nuevaAtencion.IdTipoCondicionEstablecimiento),
                    new SqlParameter("IdTipoCondicionServicio", nuevaAtencion.IdTipoCondicionServicio),
                    new SqlParameter("Diacod1_OI", nuevaAtencion.Diacod1_OI),
                    new SqlParameter("Diades1_OI", nuevaAtencion.Diades1_OI),
                    new SqlParameter("IdTipoDiagnostico1_OI", nuevaAtencion.IdTipoDiagnostico1_OI),
                    new SqlParameter("codigo", nuevaAtencion.IdCita),
                    new SqlParameter("Diacod2_OI", nuevaAtencion.Diacod2_OI),
                    new SqlParameter("Diades2_OI", nuevaAtencion.Diades2_OI),
                    new SqlParameter("IdTipoDiagnostico2_OI", nuevaAtencion.IdTipoDiagnostico2_OI),
                    new SqlParameter("Diacod3_OI", nuevaAtencion.Diacod3_OI),
                    new SqlParameter("Diades3_OI", nuevaAtencion.Diades3_OI),
                    new SqlParameter("IdTipoDiagnostico3_OI", nuevaAtencion.IdTipoDiagnostico3_OI),
                    new SqlParameter("CodProc1_OI", nuevaAtencion.CodProc1_OI),
                    new SqlParameter("Coddes1_OI", nuevaAtencion.Coddes1_OI),
                    new SqlParameter("CodProc2_OI", nuevaAtencion.CodProc2_OI),
                    new SqlParameter("Coddes2_OI", nuevaAtencion.Coddes2_OI),
                    new SqlParameter("CodProc3_OI", nuevaAtencion.CodProc3_OI),
                    new SqlParameter("Coddes3_OI", nuevaAtencion.Coddes3_OI),
                    new SqlParameter("AVOD", nuevaAtencion.Avod),
                    new SqlParameter("AVOI", nuevaAtencion.Avoi));

            return new RespuestaBD
            {
                Id = 1,
                Mensaje = "Se guardó correctamente la atención"
            };
        }

        public RespuestaBD ActualizarAtencion(RegistroAtencion nuevaAtencion)
        {
            GalenPlusContext.Database.ExecuteSqlCommand("dbo.INO_Teleconsulta_CEAtencionesActualizar @Id,@IdCita,@NroHistoriaClinica,@Paciente,@IdMedico,@Medico,@IdEspecialidad,@Especialidad,@IdServicio,@Servicio,@Financiamiento," +
                    "@Diacod1,@Diades1,@IdTipoDiagnostico1,@Diacod2,@Diades2,@IdTipoDiagnostico2,@Diacod3,@Diades3,@IdTipoDiagnostico3,@FechaAtencion,@IdUsuario,@Usuario,@CodProc1,@Coddes1,@CodProc2," +
                    "@Coddes2,@CodProc3,@Coddes3,@IdResidente,@Residente,@IdTipoCondicionEstablecimiento,@IdTipoCondicionServicio,@Diacod1_OI,@Diades1_OI,@IdTipoDiagnostico1_OI,@Diacod2_OI,@Diades2_OI," +
                    "@IdTipoDiagnostico2_OI,@Diacod3_OI,@Diades3_OI,@IdTipoDiagnostico3_OI,@CodProc1_OI,@Coddes1_OI,@CodProc2_OI,@Coddes2_OI,@CodProc3_OI,@Coddes3_OI,@AVOD,@AVOI,@Anamnesis",
                    new SqlParameter("Id", nuevaAtencion.Id),
                    new SqlParameter("IdCita", nuevaAtencion.IdCita),
                    new SqlParameter("NroHistoriaClinica", nuevaAtencion.NroHistoriaClinica),
                    new SqlParameter("Paciente", nuevaAtencion.Paciente),
                    new SqlParameter("IdMedico", nuevaAtencion.IdMedico),
                    new SqlParameter("Medico", nuevaAtencion.Medico),
                    new SqlParameter("IdEspecialidad", nuevaAtencion.IdEspecialidad),
                    new SqlParameter("Especialidad", nuevaAtencion.Especialidad),
                    new SqlParameter("IdServicio", nuevaAtencion.IdServicio),
                    new SqlParameter("Servicio", nuevaAtencion.Servicio),
                    new SqlParameter("Financiamiento", nuevaAtencion.Financiamiento),
                    new SqlParameter("Diacod1", nuevaAtencion.Diacod1),
                    new SqlParameter("Diades1", nuevaAtencion.Diades1),
                    new SqlParameter("IdTipoDiagnostico1", nuevaAtencion.IdTipoDiagnostico1),
                    new SqlParameter("Diacod2", nuevaAtencion.Diacod2),
                    new SqlParameter("Diades2", nuevaAtencion.Diades2),
                    new SqlParameter("IdTipoDiagnostico2", nuevaAtencion.IdTipoDiagnostico2),
                    new SqlParameter("Diacod3", nuevaAtencion.Diacod3),
                    new SqlParameter("Diades3", nuevaAtencion.Diades3),
                    new SqlParameter("IdTipoDiagnostico3", nuevaAtencion.IdTipoDiagnostico3),
                    new SqlParameter("FechaAtencion", nuevaAtencion.FechaAtencion),
                    new SqlParameter("IdUsuario", nuevaAtencion.IdUsuario),
                    new SqlParameter("Usuario", nuevaAtencion.Usuario),
                    new SqlParameter("CodProc1", nuevaAtencion.CodProc1),
                    new SqlParameter("Coddes1", nuevaAtencion.Coddes1),
                    new SqlParameter("CodProc2", nuevaAtencion.CodProc2),
                    new SqlParameter("Coddes2", nuevaAtencion.Coddes2),
                    new SqlParameter("CodProc3", nuevaAtencion.CodProc3),
                    new SqlParameter("Coddes3", nuevaAtencion.Coddes3),
                    new SqlParameter("IdResidente", nuevaAtencion.IdResidente),
                    new SqlParameter("Residente", nuevaAtencion.Residente),
                    new SqlParameter("IdTipoCondicionEstablecimiento", nuevaAtencion.IdTipoCondicionEstablecimiento),
                    new SqlParameter("IdTipoCondicionServicio", nuevaAtencion.IdTipoCondicionServicio),
                    new SqlParameter("Diacod1_OI", nuevaAtencion.Diacod1_OI),
                    new SqlParameter("Diades1_OI", nuevaAtencion.Diades1_OI),
                    new SqlParameter("IdTipoDiagnostico1_OI", nuevaAtencion.IdTipoDiagnostico1_OI),
                    new SqlParameter("codigo", nuevaAtencion.IdCita),
                    new SqlParameter("Diacod2_OI", nuevaAtencion.Diacod2_OI),
                    new SqlParameter("Diades2_OI", nuevaAtencion.Diades2_OI),
                    new SqlParameter("IdTipoDiagnostico2_OI", nuevaAtencion.IdTipoDiagnostico2_OI),
                    new SqlParameter("Diacod3_OI", nuevaAtencion.Diacod3_OI),
                    new SqlParameter("Diades3_OI", nuevaAtencion.Diades3_OI),
                    new SqlParameter("IdTipoDiagnostico3_OI", nuevaAtencion.IdTipoDiagnostico3_OI),
                    new SqlParameter("CodProc1_OI", nuevaAtencion.CodProc1_OI),
                    new SqlParameter("Coddes1_OI", nuevaAtencion.Coddes1_OI),
                    new SqlParameter("CodProc2_OI", nuevaAtencion.CodProc2_OI),
                    new SqlParameter("Coddes2_OI", nuevaAtencion.Coddes2_OI),
                    new SqlParameter("CodProc3_OI", nuevaAtencion.CodProc3_OI),
                    new SqlParameter("Coddes3_OI", nuevaAtencion.Coddes3_OI),
                    new SqlParameter("AVOD", nuevaAtencion.Avod),
                    new SqlParameter("AVOI", nuevaAtencion.Avoi),
                    new SqlParameter("Anamnesis", nuevaAtencion.Anamnesis));

            //Actualizar Tabla AtencionCE en Invision
            AtencionCE atencionCE = InoContext.AtencionesCE.FirstOrDefault(x => x.IdAtencionGalenos == nuevaAtencion.Id);

            if (atencionCE != null)
            {
                atencionCE.MotivoConsulta = nuevaAtencion.MotivoConsulta;
                atencionCE.TiempoEnfermedad = nuevaAtencion.TiempoEnfermedad;
                atencionCE.DesarrolloCronologico = nuevaAtencion.DesarrolloCronologico;
                atencionCE.Pa = nuevaAtencion.Pa;
                atencionCE.Fc = nuevaAtencion.Fc;
                atencionCE.Fr = nuevaAtencion.Fr;
                atencionCE.T = nuevaAtencion.T;
                atencionCE.SatO2 = nuevaAtencion.SatO2;
                atencionCE.AvConAEOD = nuevaAtencion.AvConAEOD;
                atencionCE.AvConAEOI = nuevaAtencion.AvConAEOI;
                atencionCE.AvSinCorreccionOD = nuevaAtencion.AvSinCorreccionOD;
                atencionCE.AvSinCorreccionOI = nuevaAtencion.AvSinCorreccionOI;
                atencionCE.PioOD = nuevaAtencion.PioOD;
                atencionCE.PioOI = nuevaAtencion.PioOI;
                atencionCE.ParpadoOD = nuevaAtencion.ParpadoOD;
                atencionCE.ParpadoOI = nuevaAtencion.ParpadoOI;
                atencionCE.ConjuntivaOD = nuevaAtencion.ConjuntivaOD;
                atencionCE.ConjuntivaOI = nuevaAtencion.ConjuntivaOI;
                atencionCE.CorneaOD = nuevaAtencion.CorneaOD;
                atencionCE.CorneaOI = nuevaAtencion.CorneaOI;
                atencionCE.AvConCorreccionOD = nuevaAtencion.AvConCorreccionOD;
                atencionCE.AvConCorreccionOI = nuevaAtencion.AvConCorreccionOI;
                atencionCE.CristalinoOD = nuevaAtencion.CristalinoOD;
                atencionCE.CristalinoOI = nuevaAtencion.CristalinoOI;
                atencionCE.PupilarOD = nuevaAtencion.PupilarOD;
                atencionCE.PupilarOI = nuevaAtencion.PupilarOI;
                atencionCE.VitreoOD = nuevaAtencion.VitreoOD;
                atencionCE.VitreoOI = nuevaAtencion.VitreoOI;
                atencionCE.NervioOpticoOD = nuevaAtencion.NervioOpticoOD;
                atencionCE.NervioOpticoOI = nuevaAtencion.NervioOpticoOI;
                atencionCE.MaculaOD = nuevaAtencion.MaculaOD;
                atencionCE.MaculaOI = nuevaAtencion.MaculaOI;
                atencionCE.RetinaOD = nuevaAtencion.RetinaOD;
                atencionCE.RetinaOI = nuevaAtencion.RetinaOI;
                atencionCE.ImagenOjos = string.IsNullOrEmpty(nuevaAtencion.ImagenOjos) ? null : Convert.FromBase64String(nuevaAtencion.ImagenOjos.Split(";base64,")[1]);
                atencionCE.ProximaCita = nuevaAtencion.ProximaCita;
                atencionCE.PlanDeTrabajo = nuevaAtencion.PlanDeTrabajo;
                atencionCE.IdUsuarioModificacion = nuevaAtencion.IdUsuario;
                atencionCE.FechaModificacion = DateTime.Now;
                atencionCE.Observaciones = nuevaAtencion.Observaciones;
                atencionCE.MedidasGenerales = nuevaAtencion.MedidasGenerales;

                InoContext.SaveChanges();
            }

            return new RespuestaBD
            {
                Id = nuevaAtencion.Id,
                Mensaje = "Se actualizó correctamente la atención. Si no va a registar una orden y/o receta médica, presione el botón Cerrar."
            };
        }

        public async Task<RespuestaBD> ActualizarAtencionAsync(RegistroAtencion nuevaAtencion)
        {
            await GalenPlusContext.Database.ExecuteSqlCommandAsync("dbo.INO_CEAtencionesActualizar @Id,@IdCita,@NroHistoriaClinica,@Paciente,@IdMedico,@Medico,@IdEspecialidad,@Especialidad,@IdServicio,@Servicio,@Financiamiento," +
                    "@Diacod1,@Diades1,@IdTipoDiagnostico1,@Diacod2,@Diades2,@IdTipoDiagnostico2,@Diacod3,@Diades3,@IdTipoDiagnostico3,@FechaAtencion,@IdUsuario,@Usuario,@CodProc1,@Coddes1,@CodProc2," +
                    "@Coddes2,@CodProc3,@Coddes3,@IdResidente,@Residente,@IdTipoCondicionEstablecimiento,@IdTipoCondicionServicio,@Diacod1_OI,@Diades1_OI,@IdTipoDiagnostico1_OI,@Diacod2_OI,@Diades2_OI," +
                    "@IdTipoDiagnostico2_OI,@Diacod3_OI,@Diades3_OI,@IdTipoDiagnostico3_OI,@CodProc1_OI,@Coddes1_OI,@CodProc2_OI,@Coddes2_OI,@CodProc3_OI,@Coddes3_OI,@AVOD,@AVOI",
                    new SqlParameter("Id", nuevaAtencion.Id),
                    new SqlParameter("IdCita", nuevaAtencion.IdCita),
                    new SqlParameter("NroHistoriaClinica", nuevaAtencion.NroHistoriaClinica),
                    new SqlParameter("Paciente", nuevaAtencion.Paciente),
                    new SqlParameter("IdMedico", nuevaAtencion.IdMedico),
                    new SqlParameter("Medico", nuevaAtencion.Medico),
                    new SqlParameter("IdEspecialidad", nuevaAtencion.IdEspecialidad),
                    new SqlParameter("Especialidad", nuevaAtencion.Especialidad),
                    new SqlParameter("IdServicio", nuevaAtencion.IdServicio),
                    new SqlParameter("Servicio", nuevaAtencion.Servicio),
                    new SqlParameter("Financiamiento", nuevaAtencion.Financiamiento),
                    new SqlParameter("Diacod1", nuevaAtencion.Diacod1),
                    new SqlParameter("Diades1", nuevaAtencion.Diades1),
                    new SqlParameter("IdTipoDiagnostico1", nuevaAtencion.IdTipoDiagnostico1),
                    new SqlParameter("Diacod2", nuevaAtencion.Diacod2),
                    new SqlParameter("Diades2", nuevaAtencion.Diades2),
                    new SqlParameter("IdTipoDiagnostico2", nuevaAtencion.IdTipoDiagnostico2),
                    new SqlParameter("Diacod3", nuevaAtencion.Diacod3),
                    new SqlParameter("Diades3", nuevaAtencion.Diades3),
                    new SqlParameter("IdTipoDiagnostico3", nuevaAtencion.IdTipoDiagnostico3),
                    new SqlParameter("FechaAtencion", nuevaAtencion.FechaAtencion),
                    new SqlParameter("IdUsuario", nuevaAtencion.IdUsuario),
                    new SqlParameter("Usuario", nuevaAtencion.Usuario),
                    new SqlParameter("CodProc1", nuevaAtencion.CodProc1),
                    new SqlParameter("Coddes1", nuevaAtencion.Coddes1),
                    new SqlParameter("CodProc2", nuevaAtencion.CodProc2),
                    new SqlParameter("Coddes2", nuevaAtencion.Coddes2),
                    new SqlParameter("CodProc3", nuevaAtencion.CodProc3),
                    new SqlParameter("Coddes3", nuevaAtencion.Coddes3),
                    new SqlParameter("IdResidente", nuevaAtencion.IdResidente),
                    new SqlParameter("Residente", nuevaAtencion.Residente),
                    new SqlParameter("IdTipoCondicionEstablecimiento", nuevaAtencion.IdTipoCondicionEstablecimiento),
                    new SqlParameter("IdTipoCondicionServicio", nuevaAtencion.IdTipoCondicionServicio),
                    new SqlParameter("Diacod1_OI", nuevaAtencion.Diacod1_OI),
                    new SqlParameter("Diades1_OI", nuevaAtencion.Diades1_OI),
                    new SqlParameter("IdTipoDiagnostico1_OI", nuevaAtencion.IdTipoDiagnostico1_OI),
                    new SqlParameter("codigo", nuevaAtencion.IdCita),
                    new SqlParameter("Diacod2_OI", nuevaAtencion.Diacod2_OI),
                    new SqlParameter("Diades2_OI", nuevaAtencion.Diades2_OI),
                    new SqlParameter("IdTipoDiagnostico2_OI", nuevaAtencion.IdTipoDiagnostico2_OI),
                    new SqlParameter("Diacod3_OI", nuevaAtencion.Diacod3_OI),
                    new SqlParameter("Diades3_OI", nuevaAtencion.Diades3_OI),
                    new SqlParameter("IdTipoDiagnostico3_OI", nuevaAtencion.IdTipoDiagnostico3_OI),
                    new SqlParameter("CodProc1_OI", nuevaAtencion.CodProc1_OI),
                    new SqlParameter("Coddes1_OI", nuevaAtencion.Coddes1_OI),
                    new SqlParameter("CodProc2_OI", nuevaAtencion.CodProc2_OI),
                    new SqlParameter("Coddes2_OI", nuevaAtencion.Coddes2_OI),
                    new SqlParameter("CodProc3_OI", nuevaAtencion.CodProc3_OI),
                    new SqlParameter("Coddes3_OI", nuevaAtencion.Coddes3_OI),
                    new SqlParameter("AVOD", nuevaAtencion.Avod),
                    new SqlParameter("AVOI", nuevaAtencion.Avoi));

            return new RespuestaBD
            {
                Id = 1,
                Mensaje = "Se guardó correctamente la atención"
            };
        }

        public async Task<RespuestaBD> AgregarRecetaRefraccion(RegistroRecetaRefraccion parametrosRegistro)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                RecetaRefraccionCE receta = await InoContext.RecetasRefraccion.FirstOrDefaultAsync(x => x.IdCita == parametrosRegistro.IdCita);

                if (receta != null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "La cita ya cuenta con una receta registrada.";

                    return respuesta;
                }
                else

                {
                    RecetaRefraccionCE recetaRefraccion = Mapper.Map<RecetaRefraccionCE>(parametrosRegistro);

                    InoContext.RecetasRefraccion.Add(recetaRefraccion);
                    await InoContext.SaveChangesAsync();
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se creó la receta médica correctamente.";
                }
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = ex.ToString();
            }

            return respuesta;
        }

        public async Task<RespuestaBD> ImprimirRecetaRefraccion(ImprimirRecetaRefraccion parametros)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                RecetaRefraccionCE receta = await InoContext.RecetasRefraccion.FirstOrDefaultAsync(x => x.IdRecetaRefraccion == parametros.IdRecetaRefraccion);

                if (receta == null)
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "Error en la Base de Datos. No se encuentra la receta";

                    return respuesta;
                }
                else
                {
                    receta.EstaImpreso = true;
                    await InoContext.SaveChangesAsync();
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se ha impreso la receta correctamente!";
                }
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = ex.ToString();
            }

            return respuesta;
        }

        public IEnumerable<AtencionFiltro> ListarAtenciones(AtencionesPor atencionesPor)
        {
            var list = GalenPlusContext.Query<AtencionFiltroView>().FromSql("dbo.Invision_CEPacientesAtendidosListar @Fecha,@IdEspecialidad,@IdServicio,@IdMedico",
                            new SqlParameter("Fecha", atencionesPor.Fecha),
                            new SqlParameter("IdEspecialidad", atencionesPor.IdEspecialidad),
                            new SqlParameter("IdServicio", atencionesPor.IdServicio),
                            new SqlParameter("IdMedico", atencionesPor.IdMedico)
                        ).ToList()
                         .Select(x => Mapper.Map<AtencionFiltro>(x));

            return list;
        }

        public async Task<IEnumerable<AtencionFiltro>> ListarAtencionesAsync(AtencionesPor atencionesPor)
        {
            return await GalenPlusContext.Query<AtencionFiltroView>().FromSql("dbo.Invision_CEPacientesAtendidosListar @Fecha,@IdEspecialidad,@IdServicio,@IdMedico",
                            new SqlParameter("Fecha", atencionesPor.Fecha),
                            new SqlParameter("IdEspecialidad", atencionesPor.IdEspecialidad),
                            new SqlParameter("IdServicio", atencionesPor.IdServicio),
                            new SqlParameter("IdMedico", atencionesPor.IdMedico)
                        ).Select(x => Mapper.Map<AtencionFiltro>(x))
                         .ToListAsync();
        }

        public IEnumerable<CitadosPorFecha> ListarCitadosPorFecha(CitasPor citasPor)
        {
            //return GalenPlusContext.Database.SqlQuery<CitadosPorFecha>("dbo.Invision_CECitadosPorFecha @FechaDesde,@FechaHasta,@IdMedico",
            //                new SqlParameter("FechaDesde", citasPor.FechaDesde),
            //                new SqlParameter("FechaHasta", citasPor.FechaHasta),
            //                new SqlParameter("IdMedico", citasPor.IdMedico)
            //            ).ToList();

            return GalenPlusContext.Query<CitadosPorFechaView>().FromSql("dbo.Invision_CECitadosPorFecha @FechaDesde,@FechaHasta,@IdMedico",
                            new SqlParameter("FechaDesde", citasPor.FechaDesde),
                            new SqlParameter("FechaHasta", citasPor.FechaHasta),
                            new SqlParameter("IdMedico", citasPor.IdMedico)
                        ).ToList()
                         .Select(x => Mapper.Map<CitadosPorFecha>(x))
                         .ToList();
        }

        public async Task<IEnumerable<CitadosPorFecha>> ListarCitadosPorFechaAsync(CitasPor citasPor)
        {
            return await GalenPlusContext.Query<CitadosPorFechaView>().FromSql("dbo.Invision_CECitadosPorFecha @FechaDesde,@FechaHasta,@IdMedico",
                            new SqlParameter("FechaDesde", citasPor.FechaDesde),
                            new SqlParameter("FechaHasta", citasPor.FechaHasta),
                            new SqlParameter("IdMedico", citasPor.IdMedico)
                        ).Select(x => Mapper.Map<CitadosPorFecha>(x))
                         .ToListAsync();
        }

        public IEnumerable<CitadosPorFechaMedicoEspecialidad> ListarCitadosPorFechaMedicoEspecialidad(PacientesPor PacientesPor)
        {
            //return GalenPlusContext.Database.SqlQuery<CitadosPorFechaMedicoEspecialidad>("dbo.Invision_CECitadosPorFechaMedicoEspecialidad @IdMedico,@IdEspecialidad,@Fecha",
            //                new SqlParameter("IdMedico", PacientesPor.IdMedico),
            //                new SqlParameter("IdEspecialidad", PacientesPor.IdEspecialidad),
            //                new SqlParameter("Fecha", PacientesPor.Fecha)
            //            ).ToList();

            return GalenPlusContext.Query<CitadosPorFechaMedicoEspecialidadView>().FromSql("dbo.Invision_CECitadosPorFechaMedicoEspecialidad @IdMedico,@IdEspecialidad,@Fecha",
                            new SqlParameter("IdMedico", PacientesPor.IdMedico),
                            new SqlParameter("IdEspecialidad", PacientesPor.IdEspecialidad),
                            new SqlParameter("Fecha", PacientesPor.Fecha)
                        ).ToList()
                         .Select(x => Mapper.Map<CitadosPorFechaMedicoEspecialidad>(x))
                         .ToList();
        }

        public async Task<IEnumerable<CitadosPorFechaMedicoEspecialidad>> ListarCitadosPorFechaMedicoEspecialidadAsync(PacientesPor PacientesPor)
        {
            return await GalenPlusContext.Query<CitadosPorFechaMedicoEspecialidadView>().FromSql("dbo.Invision_CECitadosPorFechaMedicoEspecialidad @IdMedico,@IdEspecialidad,@Fecha",
                            new SqlParameter("IdMedico", PacientesPor.IdMedico),
                            new SqlParameter("IdEspecialidad", PacientesPor.IdEspecialidad),
                            new SqlParameter("Fecha", PacientesPor.Fecha)
                        ).Select(x => Mapper.Map<CitadosPorFechaMedicoEspecialidad>(x))
                         .ToListAsync();
        }

        public IEnumerable<Diagnostico> ListarDiagnosticos(Diagnostico diagnostico)
        {
            //return GalenPlusContext.Database.SqlQuery<Diagnostico>("dbo.INO_CiruDiagnosticos @Diag,@Descripcion",
            //                new SqlParameter("Diag", diagnostico.CodigoCIE10),
            //                new SqlParameter("Descripcion", diagnostico.Descripcion)
            //            ).ToList();

            return GalenPlusContext.Query<DiagnosticoView>().FromSql("dbo.INO_CiruDiagnosticos @Diag,@Descripcion",
                            new SqlParameter("Diag", diagnostico.CodigoCIE10 ?? ""),
                            new SqlParameter("Descripcion", diagnostico.Descripcion ?? "")
                        ).ToList()
                         .Select(x => Mapper.Map<Diagnostico>(x))
                         .ToList();
        }

        public async Task<IEnumerable<Diagnostico>> ListarDiagnosticosAsync(Diagnostico diagnostico)
        {
            return await GalenPlusContext.Query<DiagnosticoView>().FromSql("dbo.INO_CiruDiagnosticos @Diag,@Descripcion",
                            new SqlParameter("Diag", diagnostico.CodigoCIE10 ?? ""),
                            new SqlParameter("Descripcion", diagnostico.Descripcion ?? "")
                        ).Select(x => Mapper.Map<Diagnostico>(x))
                         .ToListAsync();
        }

        public IEnumerable<ProcedimientoDto> ListarProcedimientos(ProcedimientoDto procedimiento)
        {
            return InoContext.Procedimiento.Where(x => x.EsActivo == true &&
                                                   ((procedimiento.Codigo ?? "") == "" || x.Codigo == procedimiento.Codigo) &&
                                                   ((procedimiento.Descripcion ?? "") == "" || x.Descripcion.Contains(procedimiento.Descripcion)))
                                                   .ToList()
                                                   .Select(x => Mapper.Map<ProcedimientoDto>(x))
                                                   .ToList();
        }

        public async Task<IEnumerable<ProcedimientoDto>> ListarProcedimientosAsync(ProcedimientoDto procedimiento)
        {
            return await InoContext.Procedimiento.Where(x => x.EsActivo == true &&
                                                   ((procedimiento.Codigo ?? "") == "" || x.Codigo == procedimiento.Codigo) &&
                                                   ((procedimiento.Descripcion ?? "") == "" || x.Descripcion.Contains(procedimiento.Descripcion)))
                                                   .Select(x => Mapper.Map<ProcedimientoDto>(x))
                                                   .ToListAsync();
        }

        public async Task<IEnumerable<RecetaRefraccionDto>> ListarRecetaRefraccion(DateTime fecha)
        {
            return await InoContext.RecetasRefraccion.Where(x => x.FechaCreacion.ToString("yyyy-MM-dd") == fecha.ToString("yyyy-MM-dd"))
                                                   .Select(x => Mapper.Map<RecetaRefraccionDto>(x))
                                                   .ToListAsync();
        }

        public async Task<RespuestaBD> RegistrarEvaluacionExamen(RegistrarEvaluacionExamenDto solicitud) 
        {
            RespuestaBD respuestaBD = new RespuestaBD();

            try
            {
                EvaluacionExamen evaluacionExamen = Mapper.Map<EvaluacionExamen>(solicitud);
                InoContext.EvaluacionesExamenes.Add(evaluacionExamen);
                await InoContext.SaveChangesAsync();
                respuestaBD.Id = 1;
                respuestaBD.Mensaje = "Evaluación guardada correctamente!";
            }
            catch (Exception ex)
            {
                respuestaBD.Id = 0;
                respuestaBD.Mensaje = "Error en el servidor.";
            }

            return respuestaBD;
        }

        public async Task<IEnumerable<EvaluacionExamenDto>> ListarEvaluacionExamenPorAtencion(int idAtencion)
        {
            return await InoContext.EvaluacionesExamenes.Where(x => x.IdAtencion == idAtencion && x.IdEstado.Value == 1).Select(x => Mapper.Map<EvaluacionExamenDto>(x)).ToListAsync();
        }

        public async Task<RespuestaBD> EliminarEvaluacionExamen(EliminarEvaluacionExamenDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                // 1. Obtener Evaluacion Examen
                EvaluacionExamen evaluacion = await InoContext.EvaluacionesExamenes.FirstOrDefaultAsync(x => x.Id == solicitud.IdEvaluacionExamen && x.IdAtencion == solicitud.IdAtencion
                                                                                                                    && x.IdEstado.Value == 1);

                if (evaluacion != null)
                {
                    //2. Deshabilitar logicamente
                    evaluacion.IdEstado = 0;
                    evaluacion.IdUsuarioModificacion = solicitud.IdUsuarioModificacion;
                    evaluacion.FechaModificacion = DateTime.Now;
                    await InoContext.SaveChangesAsync();
                    respuesta.Id = 1;
                    respuesta.Mensaje = "Se ha eliminado la evaluación correctamente!";
                }
                else
                {
                    respuesta.Id = 0;
                    respuesta.Mensaje = "No se ha encontrado evaluación en la base de datos.";
                }
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Ha ocurrido un error en el servidor.";
            }

            return respuesta;
        }
    }
}
