using Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.BonoDesempeno
{
    public interface IServicioDeBonoDesempeno
    {
        IEnumerable<FormatoTrama> ListarDiferimientoCitas(DatosTramaBono datosTramaBono);
        IEnumerable<FormatoTramaConDias> ListarDiferimientoCitasConDias(DatosTramaBono datosTramaBono);
        IEnumerable<TiempoEsperaAtencion> ListarTiempoEsperaAtencion(DatosTramaBono datosTramaBono);
    }
}
