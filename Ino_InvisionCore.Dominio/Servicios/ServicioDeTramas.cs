using Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Tramas.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Tramas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Tramas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeTramas : IServicioDeTramas
    {
        public IRepositorioDeTramas Repositorio { get; set; }

        public ServicioDeTramas(IRepositorioDeTramas repositorio)
        {
            Repositorio = repositorio;
        }

        public IEnumerable<TramaHISMINSADto> ListarTramasHISMINSA(FiltroTramaHISMINSA filtro)
        {
            return Repositorio.ListarTramasHISMINSA(filtro);
        }
    }
}
