using Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Medico
{
    public interface IServicioDeMedicos
    {
        IEnumerable<MedicoListar> ListarMedicos(MedicoListar medico);
        IEnumerable<MedicoListar> ListarMedicosTicket();
        IEnumerable<MedicoPorEspecialidad> ListarEspecialidadPorMedico(MedicoListar medico);
    }
}
