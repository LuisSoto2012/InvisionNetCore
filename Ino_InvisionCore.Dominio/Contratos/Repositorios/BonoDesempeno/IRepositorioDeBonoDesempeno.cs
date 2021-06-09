using Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.BonoDesempeno.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.BonoDesempeno
{
    public interface IRepositorioDeBonoDesempeno
    {
        IEnumerable<FormatoTrama> ListarDiferimientoCitas(DatosTramaBono datosTramaBono);
        IEnumerable<FormatoTramaConDias> ListarDiferimientoCitasConDias(DatosTramaBono datosTramaBono);
        IEnumerable<TiempoEsperaAtencion> ListarTiempoEsperaAtencion(DatosTramaBono datosTramaBono);

        Task<IEnumerable<FormatoTrama>> ListarDiferimientoCitasAsync(DatosTramaBono datosTramaBono);
        Task<IEnumerable<FormatoTramaConDias>> ListarDiferimientoCitasConDiasAsync(DatosTramaBono datosTramaBono);
        Task<IEnumerable<TiempoEsperaAtencion>> ListarTiempoEsperaAtencionAsync(DatosTramaBono datosTramaBono);
    }
}
