using Ino_InvisionCore.Dominio.Contratos.Helpers.Reporte.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Reporte;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Reporte;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeReportes : IServicioDeReportes
    {
        public IRepositorioDeReportes RepositorioDeReportes { get; set; }

        public ServicioDeReportes(IRepositorioDeReportes repositorioDeReportes)
        {
            RepositorioDeReportes = repositorioDeReportes;
        }

        public IEnumerable<ReporteGeneral> ListarReportes(int? Id)
        {
            return RepositorioDeReportes.ListarReportes(Id);
        }
    }
}
