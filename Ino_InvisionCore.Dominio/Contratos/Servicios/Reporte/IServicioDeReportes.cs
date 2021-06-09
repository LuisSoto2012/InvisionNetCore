using Ino_InvisionCore.Dominio.Contratos.Helpers.Reporte.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Reporte
{
    public interface IServicioDeReportes
    {
        IEnumerable<ReporteGeneral> ListarReportes(int? Id);
    }
}
