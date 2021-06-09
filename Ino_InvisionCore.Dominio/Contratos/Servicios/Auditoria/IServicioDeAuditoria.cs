using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria
{
    public interface IServicioDeAuditoria
    {
        void AgregarAuditoria(AuditoriaGeneral auditoria);
    }
}
