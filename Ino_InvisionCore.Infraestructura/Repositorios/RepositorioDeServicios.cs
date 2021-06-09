using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Servicios.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Servicios;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeServicios : IRepositorioDeServicios
    {
        private GalenPlusContext Context;

        public RepositorioDeServicios(GalenPlusContext context)
        {
            Context = context;
        }

        public IEnumerable<ServicioPorEspecialidad> ListarServicioPorEspecialidad(MedicoPorEspecialidad especialidad)
        {
            //var servicios = Context.Database.SqlQuery<ServicioPorEspecialidad>("dbo.INO_ConsultaExternaServiciosPorEspecialidad @IdEspecialidad",
            //            new SqlParameter("IdEspecialidad", especialidad.IdEspecialidad)).ToList();

            var servicios = Context.Query<ServicioPorEspecialidadView>().FromSql("dbo.INO_ConsultaExternaServiciosPorEspecialidad @IdEspecialidad",
                        new SqlParameter("IdEspecialidad", especialidad.IdEspecialidad))
                        .ToList()
                        .Select(x => Mapper.Map<ServicioPorEspecialidad>(x))
                        .ToList();

            return servicios;
        }

        public async Task<IEnumerable<ServicioPorEspecialidad>> ListarServicioPorEspecialidadAsync(MedicoPorEspecialidad especialidad)
        {
            return await Context.Query<ServicioPorEspecialidadView>().FromSql("dbo.INO_ConsultaExternaServiciosPorEspecialidad @IdEspecialidad",
                                new SqlParameter("IdEspecialidad", especialidad.IdEspecialidad))
                                .Select(x => Mapper.Map<ServicioPorEspecialidad>(x))
                                .ToListAsync();
        }
    }
}
