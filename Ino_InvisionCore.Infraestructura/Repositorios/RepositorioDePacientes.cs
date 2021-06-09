using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Paciente;
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
    public class RepositorioDePacientes : IRepositorioDePacientes
    {
        private GalenPlusContext Context;

        public RepositorioDePacientes(GalenPlusContext context)
        {
            Context = context;
        }

        public IEnumerable<HistorialAtenciones> ListarHistorialAtenciones(PacientePorHcDni paciente)
        {
            var ds = paciente.NroHistoriaClinica.Value;
            //return Context.Database.SqlQuery<HistorialAtenciones>("dbo.INO_CEHistorialAtenciones @NroHistoriaClinica",
            //        new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value)).ToList();

            return Context.Query<HistorialAtencionesView>().FromSql("dbo.INO_CEHistorialAtenciones @NroHistoriaClinica",
                    new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value)).ToList().Select(x => Mapper.Map<HistorialAtenciones>(x)).ToList();
        }

        public async Task<IEnumerable<HistorialAtenciones>> ListarHistorialAtencionesAsync(PacientePorHcDni paciente)
        {
            return await Context.Query<HistorialAtencionesView>().FromSql("dbo.INO_CEHistorialAtenciones @NroHistoriaClinica",
                    new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value)).Select(x => Mapper.Map<HistorialAtenciones>(x)).ToListAsync();
        }

        public IEnumerable<HistorialCentroQuirurgico> ListarHistorialCentroQuirurgico(PacientePorHcDni paciente)
        {
            //return Context.Database.SqlQuery<HistorialCentroQuirurgico>("dbo.INO_CEHistorialAtencionesCQ @NroHistoriaClinica",
            //            new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value)).ToList();

            return Context.Query<HistorialCentroQuirurgicoView>().FromSql("dbo.INO_CEHistorialAtencionesCQ @NroHistoriaClinica",
                        new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value))
                            .ToList()
                            .Select(x => Mapper.Map<HistorialCentroQuirurgico>(x))
                            .ToList();
        }

        public async Task<IEnumerable<HistorialCentroQuirurgico>> ListarHistorialCentroQuirurgicoAsync(PacientePorHcDni paciente)
        {
            return await Context.Query<HistorialCentroQuirurgicoView>().FromSql("dbo.INO_CEHistorialAtencionesCQ @NroHistoriaClinica",
                        new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value))
                            .Select(x => Mapper.Map<HistorialCentroQuirurgico>(x))
                            .ToListAsync();
        }

        public IEnumerable<HistorialEmergencia> ListarHistorialEmergencia(PacientePorHcDni paciente)
        {
            //return Context.Database.SqlQuery<HistorialEmergencia>("dbo.INO_CEHistorialEmergencia @NroHistoriaClinica",
            //            new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value)).ToList();

            return Context.Query<HistorialEmergenciaView>().FromSql("dbo.INO_CEHistorialEmergencia @NroHistoriaClinica",
                        new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value))
                        .ToList()
                        .Select(x => Mapper.Map<HistorialEmergencia>(x));
        }

        public async Task<IEnumerable<HistorialEmergencia>> ListarHistorialEmergenciaAsync(PacientePorHcDni paciente)
        {
            return await Context.Query<HistorialEmergenciaView>().FromSql("dbo.INO_CEHistorialEmergencia @NroHistoriaClinica",
                        new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value))
                        .Select(x => Mapper.Map<HistorialEmergencia>(x))
                        .ToListAsync();
        }

        public IEnumerable<HistorialAtenciones> ListarHistorialHospitalizacion(PacientePorHcDni paciente)
        {
            return Context.Query<HistorialAtencionesView>().FromSql("dbo.INO_CEHistorialHospitalizacion @NroHistoriaClinica",
                    new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value)).ToList().Select(x => Mapper.Map<HistorialAtenciones>(x)).ToList();
        }

        public IEnumerable<HistorialLaboratorio> ListarHistorialLaboratorio(PacientePorHcDni paciente)
        {
            //return Context.Database.SqlQuery<HistorialLaboratorio>("dbo.INO_CEHistorialLaboratorio @NroHistoriaClinica",
            //            new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value)).ToList();

            return Context.Query<HistorialLaboratorioView>().FromSql("dbo.INO_CEHistorialLaboratorio @NroHistoriaClinica",
                        new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value))
                            .ToList()
                            .Select(x => Mapper.Map<HistorialLaboratorio>(x))
                            .ToList();
        }

        public async Task<IEnumerable<HistorialLaboratorio>> ListarHistorialLaboratorioAsync(PacientePorHcDni paciente)
        {
            return await Context.Query<HistorialLaboratorioView>().FromSql("dbo.INO_CEHistorialLaboratorio @NroHistoriaClinica",
                        new SqlParameter("NroHistoriaClinica", paciente.NroHistoriaClinica.Value))
                            .Select(x => Mapper.Map<HistorialLaboratorio>(x))
                            .ToListAsync();
        }

        public IEnumerable<HistorialRiesgoQuirurgico> ListarHistorialRiesgoQuirurgico(PacientePorHcDni paciente)
        {
            //return Context.Database.SqlQuery<HistorialRiesgoQuirurgico>("dbo.INO_HistoricoEKG @hcl",
            //            new SqlParameter("hcl", paciente.NroHistoriaClinica.Value)).ToList();

            return Context.Query<HistorialRiesgoQuirurgicoView>().FromSql("dbo.INO_HistoricoEKG @hcl",
                        new SqlParameter("hcl", paciente.NroHistoriaClinica.Value))
                            .ToList()
                            .Select(x => Mapper.Map<HistorialRiesgoQuirurgico>(x))
                            .ToList();
        }

        public async Task<IEnumerable<HistorialRiesgoQuirurgico>> ListarHistorialRiesgoQuirurgicoAsync(PacientePorHcDni paciente)
        {
            return await Context.Query<HistorialRiesgoQuirurgicoView>().FromSql("dbo.INO_HistoricoEKG @hcl",
                        new SqlParameter("hcl", paciente.NroHistoriaClinica.Value))
                            .Select(x => Mapper.Map<HistorialRiesgoQuirurgico>(x))
                            .ToListAsync();
        }

        public PacienteCitado ListarPacienteCitadoDelDia(PacientePorHcDni pacientePorHcDni)
        {
            var Hc = new SqlParameter("NroHistoria", pacientePorHcDni.NroHistoriaClinica);
            Hc.Value = (object)pacientePorHcDni.NroHistoriaClinica ?? DBNull.Value;
            var Dni = new SqlParameter("NroDocumento", pacientePorHcDni.NroDocumento);
            Dni.Value = (object)pacientePorHcDni.NroDocumento ?? DBNull.Value;
            var IdEspecialidad = new SqlParameter("IdEspecialidad", pacientePorHcDni.IdEspecialidad);

            //return Context.Database.SqlQuery<PacienteCitado>("dbo.INO_ArchivoPedirHCPacientes @NroHistoria, @NroDocumento, @IdEspecialidad", Hc, Dni, IdEspecialidad).FirstOrDefault();

            return Context.Query<PacienteCitadoView>().FromSql("dbo.INO_ArchivoPedirHCPacientes @NroHistoria, @NroDocumento, @IdEspecialidad", Hc, Dni, IdEspecialidad)
                .Select(x => Mapper.Map<PacienteCitado>(x))
                .FirstOrDefault();
        }

        public async Task<PacienteCitado> ListarPacienteCitadoDelDiaAsync(PacientePorHcDni pacientePorHcDni)
        {
            var Hc = new SqlParameter("NroHistoria", pacientePorHcDni.NroHistoriaClinica);
            Hc.Value = (object)pacientePorHcDni.NroHistoriaClinica ?? DBNull.Value;
            var Dni = new SqlParameter("NroDocumento", pacientePorHcDni.NroDocumento);
            Dni.Value = (object)pacientePorHcDni.NroDocumento ?? DBNull.Value;
            var IdEspecialidad = new SqlParameter("IdEspecialidad", pacientePorHcDni.IdEspecialidad);

            return await Context.Query<PacienteCitadoView>().FromSql("dbo.INO_ArchivoPedirHCPacientes @NroHistoria, @NroDocumento, @IdEspecialidad", Hc, Dni, IdEspecialidad)
                .Select(x => Mapper.Map<PacienteCitado>(x))
                .FirstOrDefaultAsync();
        }

        public PacienteAfiliacion ListarPacientePorHcDni(PacientePorHcDni pacientePorHcDni)
        {
            var Hc = new SqlParameter("Hc", pacientePorHcDni.NroHistoriaClinica);
            Hc.Value = (object)pacientePorHcDni.NroHistoriaClinica ?? DBNull.Value;
            var Dni = new SqlParameter("Dni", pacientePorHcDni.NroDocumento);
            Dni.Value = (object)pacientePorHcDni.NroDocumento ?? DBNull.Value;
            var Temp = new SqlParameter("Temp", pacientePorHcDni.Temporal);

            //return Context.Database.SqlQuery<PacienteAfiliacion>("dbo.INO_BuscarPacientePorHCDNI @Hc, @Dni, @Temp", Hc, Dni, Temp).FirstOrDefault();

            return Context.Query<PacienteAfiliacionView>().FromSql("dbo.INO_BuscarPacientePorHCDNI @Hc, @Dni, @Temp", Hc, Dni, Temp)
                .Select(x => Mapper.Map<PacienteAfiliacion>(x))
                .FirstOrDefault();
        }

        public async Task<PacienteAfiliacion> ListarPacientePorHcDniAsync(PacientePorHcDni pacientePorHcDni)
        {
            var Hc = new SqlParameter("Hc", pacientePorHcDni.NroHistoriaClinica);
            Hc.Value = (object)pacientePorHcDni.NroHistoriaClinica ?? DBNull.Value;
            var Dni = new SqlParameter("Dni", pacientePorHcDni.NroDocumento);
            Dni.Value = (object)pacientePorHcDni.NroDocumento ?? DBNull.Value;
            var Temp = new SqlParameter("Temp", pacientePorHcDni.Temporal);

            return await Context.Query<PacienteAfiliacionView>().FromSql("dbo.INO_BuscarPacientePorHCDNI @Hc, @Dni, @Temp", Hc, Dni, Temp)
                .Select(x => Mapper.Map<PacienteAfiliacion>(x))
                .FirstOrDefaultAsync();
        }

        public IEnumerable<PacientePorHcDni> ListarPacientesCitadosPorEspecialidadMedicoFecha(BuscarPaciente buscarPaciente)
        {
            //var pacientesCitados = Context.Database.SqlQuery<PacientePorHcDni>("dbo.INO_PacientesCitadosListarPorEspecialidadMedicoFecha @Fecha, @IdMedico, @IdEspecialidad",
            //            new SqlParameter("Fecha", buscarPaciente.Fecha),
            //            new SqlParameter("IdMedico", buscarPaciente.IdMedico),
            //            new SqlParameter("IdEspecialidad", buscarPaciente.IdEspecialidad)).ToList();

            var pacientesCitados = Context.Query<PacientePorHcDniView>().FromSql("dbo.INO_PacientesCitadosListarPorEspecialidadMedicoFecha @Fecha, @IdMedico, @IdEspecialidad",
                        new SqlParameter("Fecha", buscarPaciente.Fecha),
                        new SqlParameter("IdMedico", buscarPaciente.IdMedico),
                        new SqlParameter("IdEspecialidad", buscarPaciente.IdEspecialidad))
                            .ToList()
                            .Select(x => Mapper.Map<PacientePorHcDni>(x))
                            .ToList();

            return pacientesCitados;
        }

        public async Task<IEnumerable<PacientePorHcDni>> ListarPacientesCitadosPorEspecialidadMedicoFechaAsync(BuscarPaciente buscarPaciente)
        {
            return await Context.Query<PacientePorHcDniView>().FromSql("dbo.INO_PacientesCitadosListarPorEspecialidadMedicoFecha @Fecha, @IdMedico, @IdEspecialidad",
                        new SqlParameter("Fecha", buscarPaciente.Fecha),
                        new SqlParameter("IdMedico", buscarPaciente.IdMedico),
                        new SqlParameter("IdEspecialidad", buscarPaciente.IdEspecialidad))
                            .Select(x => Mapper.Map<PacientePorHcDni>(x))
                            .ToListAsync();
        }
    }
}
