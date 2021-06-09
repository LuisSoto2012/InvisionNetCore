using Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.BonoDesempeno;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.BonoDesempeno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeBonoDesempeno : IServicioDeBonoDesempeno
    {
        public IRepositorioDeBonoDesempeno RepositorioDeBonoDesempeno { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeBonoDesempeno(IRepositorioDeBonoDesempeno repositorioDeBonoDesempeno, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeBonoDesempeno = repositorioDeBonoDesempeno;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public IEnumerable<FormatoTrama> ListarDiferimientoCitas(DatosTramaBono datosTramaBono)
        {
            return RepositorioDeBonoDesempeno.ListarDiferimientoCitas(datosTramaBono);
        }

        public IEnumerable<FormatoTramaConDias> ListarDiferimientoCitasConDias(DatosTramaBono datosTramaBono)
        {
            return RepositorioDeBonoDesempeno.ListarDiferimientoCitasConDias(datosTramaBono);
        }

        public IEnumerable<TiempoEsperaAtencion> ListarTiempoEsperaAtencion(DatosTramaBono datosTramaBono)
        {
            return RepositorioDeBonoDesempeno.ListarTiempoEsperaAtencion(datosTramaBono);
        }
    }
}
