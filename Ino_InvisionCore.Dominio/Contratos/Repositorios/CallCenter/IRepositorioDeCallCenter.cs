using Ino_InvisionCore.Dominio.Contratos.Helpers.CallCenter.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CallCenter.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.CallCenter
{
    public interface IRepositorioDeCallCenter
    {
        Task<RespuestaBD> RegistrarCitaCallCenter(RegistrarCitaCallCenter solicitud);
        Task<IEnumerable<CitaCallCenterDto>> ListarCitaCallCenter(DateTime fechaDesde, DateTime fechaHasta);
    }
}
