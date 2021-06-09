using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErronea.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErronea.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Laboratorio
{
    public interface IServicioDePedidosAnalisis
    {
        RespuestaBD AgregarTranscripcionErronea(NuevoTranscripcionErronea nuevoTranscripcionErronea);
        RespuestaBD AgregarSolicitudDatosIncompletos(NuevoSolicitudDatosIncompletos nuevoSolicitudDatosIncompletos);
        RespuestaBD EditarTranscripcionErronea(ActualizarTranscripcionErronea actualizarTranscripcionErronea);
        RespuestaBD EditarSolicitudDatosIncompletos(ActualizarSolicitudDatosIncompletos actualizarSolicitudDatosIncompletos);
        IEnumerable<TranscripcionErroneaGeneral> ListarTranscripcionErronea();
        IEnumerable<SolicitudDatosIncompletosGeneral> ListarSolicitudDatosIncompletos();
    }
}
