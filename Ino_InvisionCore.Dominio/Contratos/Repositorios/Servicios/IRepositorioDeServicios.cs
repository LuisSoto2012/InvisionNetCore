using Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Servicios.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Servicios
{
    public interface IRepositorioDeServicios 
    {
        IEnumerable<ServicioPorEspecialidad> ListarServicioPorEspecialidad(MedicoPorEspecialidad especialidad);

        Task<IEnumerable<ServicioPorEspecialidad>> ListarServicioPorEspecialidadAsync(MedicoPorEspecialidad especialidad);
    }
}
