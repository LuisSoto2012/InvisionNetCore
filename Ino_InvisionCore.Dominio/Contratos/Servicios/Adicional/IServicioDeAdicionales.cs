using Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Peticiones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Adicional
{
    public interface IServicioDeAdicionales
    {
        IEnumerable<Adicionales> ConsultaExternaAdicionalesPorMedicoListar(BuscarPaciente paciente);
        int ConsultaExternaAdicionalesPorMedicoRegistrar(NuevoAdicional nuevaAdicional);
        Task<RespuestaBD> ConsultaExternaAdicionalesPorMedicoEliminar(int idAdicional);
    }
}
