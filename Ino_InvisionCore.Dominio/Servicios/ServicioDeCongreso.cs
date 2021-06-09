using Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Congreso.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Congreso;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Congreso;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeCongreso : IServicioDeCongreso
    {
        public IRepositorioDeCongreso RepositorioDeCongreso { get; set; }

        public ServicioDeCongreso(IRepositorioDeCongreso repositorioDeCongreso)
        {
            RepositorioDeCongreso = repositorioDeCongreso;
        }

        public List<AsistenciaGeneral> EventoAsistenciaListar(int IdHorario, int IdEvento)
        {
            return RepositorioDeCongreso.EventoAsistenciaListar(IdHorario, IdEvento);
        }

        public RespuestaBD EventoAsistenciaRegistrar(NuevaAsistencia nuevaAsistencia)
        {
            return RepositorioDeCongreso.EventoAsistenciaRegistrar(nuevaAsistencia);
        }

        public List<EventoGeneral> EventoListar()
        {
            return RepositorioDeCongreso.EventoListar();
        }

        public ParticipanteGeneral EventoParticipanteXDNI(string NumeroDocumento)
        {
            return RepositorioDeCongreso.EventoParticipanteXDNI(NumeroDocumento);
        }
    }
}
