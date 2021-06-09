using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Reporte.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Reporte;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeReportes : IRepositorioDeReportes
    {
        private InoContext Context;

        public RepositorioDeReportes(InoContext context)
        {
            Context = context;
        }

        public IEnumerable<ReporteGeneral> ListarReportes(int? Id)
        {
            return Context.SubModulo.Where(x => x.IdSubModulo == Id)
                                   .Include(x => x.SubModuloReportes)
                                   .ThenInclude(sr => sr.Reporte)
                                   .FirstOrDefault()
                                   //.Reportes
                                   .SubModuloReportes
                                   .Select(x => x.Reporte)
                                   .Where(x => x.EsActivo == true)
                                   .ToList()
                                   .Select(x => Mapper.Map<ReporteGeneral>(x))
                                   .ToList();
        }

        public async Task<IEnumerable<ReporteGeneral>> ListarReportesAsync(int? Id)
        {
            var subModulo = await Context.SubModulo.Where(x => x.IdSubModulo == Id)
                                   .Include(x => x.SubModuloReportes)
                                   .ThenInclude(sr => sr.Reporte)
                                   .FirstOrDefaultAsync();

            return subModulo.SubModuloReportes
                            .Select(x => x.Reporte)
                            .Where(x => x.EsActivo == true)
                            .ToList()
                            .Select(x => Mapper.Map<ReporteGeneral>(x))
                            .ToList();
        }
    }
}
