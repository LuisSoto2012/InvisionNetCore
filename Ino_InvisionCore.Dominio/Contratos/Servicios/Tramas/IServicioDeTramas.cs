using Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Tramas
{
    public interface IServicioDeTramas
    {
        IEnumerable<TramaHISMINSADto> ListarTramasHISMINSA(FiltroTramaHISMINSA filtro);
    }
}
