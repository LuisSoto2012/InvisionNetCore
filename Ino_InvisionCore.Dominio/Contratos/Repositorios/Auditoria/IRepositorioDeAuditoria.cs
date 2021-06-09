using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Auditoria
{
    public interface IRepositorioDeAuditoria
    {
        void AgregarAuditoria(AuditoriaGeneral auditoriaGeneral);

        Task AgregarAuditoriaAsync(AuditoriaGeneral auditoriaGeneral);
    }
}
