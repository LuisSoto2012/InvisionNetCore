using Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Medico
{
    public interface IRepositorioDeMedicos
    {
        IEnumerable<MedicoListar> ListarMedicos(MedicoListar medico);
        IEnumerable<MedicoListar> ListarMedicosTicket();
        IEnumerable<MedicoPorEspecialidad> ListarEspecialidadPorMedico(MedicoListar medico);

        Task<IEnumerable<MedicoListar>> ListarMedicosAsync(MedicoListar medico);
        Task<IEnumerable<MedicoListar>> ListarMedicosTicketAsync();
        Task<IEnumerable<MedicoPorEspecialidad>> ListarEspecialidadPorMedicoAsync(MedicoListar medico);
    }
}
