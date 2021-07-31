using Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Peticiones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Adicional
{
    public interface IRepositorioDeAdicionales
    {
        IEnumerable<Adicionales> ConsultaExternaAdicionalesPorMedicoListar(BuscarPaciente paciente);
        Task<IEnumerable<Adicionales>> ConsultaExternaAdicionalesPorMedicoListar(string hc);
        int ConsultaExternaAdicionalesPorMedicoRegistrar(NuevoAdicional nuevoAdicional);
        Task<RespuestaBD> ConsultaExternaAdicionalesPorMedicoEliminar(int idAdicional);
        Task<IEnumerable<Adicionales>> ConsultaExternaAdicionalesPorMedicoListarAsync(BuscarPaciente paciente);
        Task<int> ConsultaExternaAdicionalesPorMedicoRegistrarAsync(NuevoAdicional nuevoAdicional);
    }
}
