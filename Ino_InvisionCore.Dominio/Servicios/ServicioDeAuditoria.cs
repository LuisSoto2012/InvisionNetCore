using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeAuditoria : IServicioDeAuditoria
    {
        public IRepositorioDeAuditoria RepositorioDeAuditoria { get; set; }

        public ServicioDeAuditoria(IRepositorioDeAuditoria repositorioDeAuditoria)
        {
            RepositorioDeAuditoria = repositorioDeAuditoria;
        }

        public void AgregarAuditoria(AuditoriaGeneral auditoria)
        {
            RepositorioDeAuditoria.AgregarAuditoria(auditoria);
        }
    }
}
