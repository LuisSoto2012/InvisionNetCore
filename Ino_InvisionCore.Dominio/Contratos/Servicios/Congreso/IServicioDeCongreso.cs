using Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Congreso
{
    public interface IServicioDeCongreso
    {
        List<AsistenciaGeneral> EventoAsistenciaListar(int IdHorario, int IdEvento);
        RespuestaBD EventoAsistenciaRegistrar(NuevaAsistencia nuevaAsistencia);
        List<EventoGeneral> EventoListar();
        ParticipanteGeneral EventoParticipanteXDNI(string NumeroDocumento);
    }
}
