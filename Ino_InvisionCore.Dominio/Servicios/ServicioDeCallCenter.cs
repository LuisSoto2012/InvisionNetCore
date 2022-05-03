using Ino_InvisionCore.Dominio.Contratos.Helpers.CallCenter.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CallCenter.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.CallCenter;
using Ino_InvisionCore.Dominio.Contratos.Servicios.CallCenter;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeCallCenter : IServicioDeCallCenter
    {
        private readonly IRepositorioDeCallCenter _repositorio;

        public ServicioDeCallCenter(IRepositorioDeCallCenter repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<CitaCallCenterDto>> ListarCitaCallCenter(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _repositorio.ListarCitaCallCenter(fechaDesde, fechaHasta);
        }

        public async Task<RespuestaBD> RegistrarCitaCallCenter(RegistrarCitaCallCenter solicitud)
        {
            return await _repositorio.RegistrarCitaCallCenter(solicitud);
        }
    }
}
