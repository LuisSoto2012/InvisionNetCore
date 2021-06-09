using Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Congreso
{
    public interface IRepositorioDeCongreso
    {
        List<AsistenciaGeneral> EventoAsistenciaListar(int IdHorario, int IdEvento);
        RespuestaBD EventoAsistenciaRegistrar(NuevaAsistencia nuevaAsistencia);
        List<EventoGeneral> EventoListar();
        ParticipanteGeneral EventoParticipanteXDNI(string NumeroDocumento);

        Task<List<AsistenciaGeneral>> EventoAsistenciaListarAsync(int IdHorario, int IdEvento);
        Task<RespuestaBD> EventoAsistenciaRegistrarAsync(NuevaAsistencia nuevaAsistencia);
        Task<List<EventoGeneral>> EventoListarAsync();
        Task<ParticipanteGeneral> EventoParticipanteXDNIAsync(string NumeroDocumento);
    }
}
