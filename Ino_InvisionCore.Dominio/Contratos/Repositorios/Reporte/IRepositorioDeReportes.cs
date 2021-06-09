using Ino_InvisionCore.Dominio.Contratos.Helpers.Reporte.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Reporte
{
    public interface IRepositorioDeReportes
    {
        IEnumerable<ReporteGeneral> ListarReportes(int? Id);

        Task<IEnumerable<ReporteGeneral>> ListarReportesAsync(int? Id);
    }
}
