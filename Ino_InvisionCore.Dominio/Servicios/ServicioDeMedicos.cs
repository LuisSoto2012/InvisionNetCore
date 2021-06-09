using Ino_InvisionCore.Dominio.Contratos.Helpers.Medico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Medico;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Medico;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeMedicos : IServicioDeMedicos
    {
        public IRepositorioDeMedicos RepositorioDeMedico { get; set; }

        public ServicioDeMedicos(IRepositorioDeMedicos repositorioDeMedico)
        {
            RepositorioDeMedico = repositorioDeMedico;
        }

        public IEnumerable<MedicoPorEspecialidad> ListarEspecialidadPorMedico(MedicoListar medico)
        {
            return RepositorioDeMedico.ListarEspecialidadPorMedico(medico);
        }

        public IEnumerable<MedicoListar> ListarMedicos(MedicoListar medico)
        {
            return RepositorioDeMedico.ListarMedicos(medico);
        }

        public IEnumerable<MedicoListar> ListarMedicosTicket()
        {
            return RepositorioDeMedico.ListarMedicosTicket();
        }
    }
}
