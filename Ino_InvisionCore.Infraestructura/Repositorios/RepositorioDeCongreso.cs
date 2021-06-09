using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Congreso;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
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
    public class RepositorioDeCongreso : IRepositorioDeCongreso
    {
        private readonly GalenPlusContext Context;

        public RepositorioDeCongreso(GalenPlusContext context)
        {
            Context = context;
        }

        public List<AsistenciaGeneral> EventoAsistenciaListar(int IdHorario, int IdEvento)
        {
            //return Context.Database.SqlQuery<AsistenciaGeneral>("dbo.INO_EventoAsistenciaListar @IdHorario, @IdEvento",
            //            new SqlParameter("IdHorario", IdHorario),
            //            new SqlParameter("IdEvento", IdEvento)).ToList();

            return Context.Query<AsistenciaGeneralView>().FromSql("dbo.INO_EventoAsistenciaListar @IdHorario, @IdEvento",
                        new SqlParameter("IdHorario", IdHorario),
                        new SqlParameter("IdEvento", IdEvento))
                        .ToList()
                        .Select(x => Mapper.Map<AsistenciaGeneral>(x))
                        .ToList();
        }

        public async Task<List<AsistenciaGeneral>> EventoAsistenciaListarAsync(int IdHorario, int IdEvento)
        {
            return await Context.Query<AsistenciaGeneralView>().FromSql("dbo.INO_EventoAsistenciaListar @IdHorario, @IdEvento",
                        new SqlParameter("IdHorario", IdHorario),
                        new SqlParameter("IdEvento", IdEvento))
                        .Select(x => Mapper.Map<AsistenciaGeneral>(x))
                        .ToListAsync();
        }

        public RespuestaBD EventoAsistenciaRegistrar(NuevaAsistencia nuevaAsistencia)
        {
            //int IdRegistro = Context.Database.SqlQuery<int>("dbo.INO_EventoAsistenciaRegistrar @IdEvento, @IdParticipante, @IdHorario, @FechaRegistro, @IdUsuario",
            //            new SqlParameter("IdEvento", nuevaAsistencia.IdEvento),
            //            new SqlParameter("IdParticipante", nuevaAsistencia.IdParticipante),
            //            new SqlParameter("IdHorario", nuevaAsistencia.IdHorario),
            //            new SqlParameter("FechaRegistro", nuevaAsistencia.FechaRegistro),
            //            new SqlParameter("IdUsuario", nuevaAsistencia.IdUsuario)).FirstOrDefault();

            int IdRegistro = Context.Query<EventoAsistenciaRegistrarView>().FromSql("dbo.INO_EventoAsistenciaRegistrar @IdEvento, @IdParticipante, @IdHorario, @FechaRegistro, @IdUsuario",
                        new SqlParameter("IdEvento", nuevaAsistencia.IdEvento),
                        new SqlParameter("IdParticipante", nuevaAsistencia.IdParticipante),
                        new SqlParameter("IdHorario", nuevaAsistencia.IdHorario),
                        new SqlParameter("FechaRegistro", nuevaAsistencia.FechaRegistro),
                        new SqlParameter("IdUsuario", nuevaAsistencia.IdUsuario)).FirstOrDefault().IdRegistro;

            return new RespuestaBD
            {
                Id = IdRegistro,
                Mensaje = IdRegistro > 0 ? "Se guardó correctamente la atención." : "El participante ya ha sido registrado para este horario."
            };
        }

        public async Task<RespuestaBD> EventoAsistenciaRegistrarAsync(NuevaAsistencia nuevaAsistencia)
        {
            var result = await Context.Query<EventoAsistenciaRegistrarView>().FromSql("dbo.INO_EventoAsistenciaRegistrar @IdEvento, @IdParticipante, @IdHorario, @FechaRegistro, @IdUsuario",
                            new SqlParameter("IdEvento", nuevaAsistencia.IdEvento),
                            new SqlParameter("IdParticipante", nuevaAsistencia.IdParticipante),
                            new SqlParameter("IdHorario", nuevaAsistencia.IdHorario),
                            new SqlParameter("FechaRegistro", nuevaAsistencia.FechaRegistro),
                            new SqlParameter("IdUsuario", nuevaAsistencia.IdUsuario)).FirstOrDefaultAsync();


            return new RespuestaBD
            {
                Id = result.IdRegistro,
                Mensaje = result.IdRegistro > 0 ? "Se guardó correctamente la atención." : "El participante ya ha sido registrado para este horario."
            };
        }

        public List<EventoGeneral> EventoListar()
        {
            //return Context.Database.SqlQuery<EventoGeneral>("dbo.INO_EventoListar").ToList();
            return Context.Query<EventoGeneralView>().FromSql("dbo.INO_EventoListar")
                        .ToList()
                        .Select(x => Mapper.Map<EventoGeneral>(x))
                        .ToList();
        }

        public async Task<List<EventoGeneral>> EventoListarAsync()
        {
            return await Context.Query<EventoGeneralView>().FromSql("dbo.INO_EventoListar")
                            .Select(x => Mapper.Map<EventoGeneral>(x))
                            .ToListAsync();
        }

        public ParticipanteGeneral EventoParticipanteXDNI(string NumeroDocumento)
        {
            //return Context.Database.SqlQuery<ParticipanteGeneral>("dbo.INO_EventoParticipanteXDNI @Dni",
            //            new SqlParameter("Dni", NumeroDocumento)).FirstOrDefault();
            return Context.Query<ParticipanteGeneralView>().FromSql("dbo.INO_EventoParticipanteXDNI @Dni",
                        new SqlParameter("Dni", NumeroDocumento)).Select(x => Mapper.Map<ParticipanteGeneral>(x)).FirstOrDefault();
        }

        public async Task<ParticipanteGeneral> EventoParticipanteXDNIAsync(string NumeroDocumento)
        {
            return await Context.Query<ParticipanteGeneralView>().FromSql("dbo.INO_EventoParticipanteXDNI @Dni",
                        new SqlParameter("Dni", NumeroDocumento))
                            .Select(x => Mapper.Map<ParticipanteGeneral>(x))
                            .FirstOrDefaultAsync();
        }
    }
}
