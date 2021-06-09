using Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Servicios.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Servicios;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeServicios : IServicioDeServicios
    {
        public IRepositorioDeServicios RepositorioDeServicios { get; set; }

        public ServicioDeServicios(IRepositorioDeServicios repositorioDeServicios)
        {
            RepositorioDeServicios = repositorioDeServicios;
        }

        public IEnumerable<ServicioPorEspecialidad> ListarServicioPorEspecialidad(MedicoPorEspecialidad especialidad)
        {
            return RepositorioDeServicios.ListarServicioPorEspecialidad(especialidad);
        }
    }
}
