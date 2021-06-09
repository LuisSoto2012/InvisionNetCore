using Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Servicios.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Servicios
{
    public interface IServicioDeServicios
    {
        IEnumerable<ServicioPorEspecialidad> ListarServicioPorEspecialidad(MedicoPorEspecialidad especialidad);
    }
}
