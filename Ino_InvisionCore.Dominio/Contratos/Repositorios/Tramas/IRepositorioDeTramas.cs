using Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Tramas
{
    public interface IRepositorioDeTramas
    {
        IEnumerable<TramaHISMINSADto> ListarTramasHISMINSA(FiltroTramaHISMINSA filtro);
    }
}
