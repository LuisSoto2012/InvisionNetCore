using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.SolicitudDatosIncompletos.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErronea.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErronea.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Laboratorio
{
    public interface IRepositorioDePedidosAnalisis
    {
        RespuestaBD AgregarTranscripcionErronea(NuevoTranscripcionErronea nuevoTranscripcionErronea);
        RespuestaBD AgregarSolicitudDatosIncompletos(NuevoSolicitudDatosIncompletos nuevoSolicitudDatosIncompletos);
        RespuestaBD EditarTranscripcionErronea(ActualizarTranscripcionErronea actualizarTranscripcionErronea);
        RespuestaBD EditarSolicitudDatosIncompletos(ActualizarSolicitudDatosIncompletos actualizarSolicitudDatosIncompletos);
        IEnumerable<TranscripcionErroneaGeneral> ListarTranscripcionErronea();
        IEnumerable<SolicitudDatosIncompletosGeneral> ListarSolicitudDatosIncompletos();
        SolicitudDatosIncompletos EncontrarSolicitudDatosIncompletos(int Id);
        TranscripcionErronea EncontrarTranscripcionErronea(int Id);

        Task<RespuestaBD> AgregarTranscripcionErroneaAsync(NuevoTranscripcionErronea nuevoTranscripcionErronea);
        Task<RespuestaBD> AgregarSolicitudDatosIncompletosAsync(NuevoSolicitudDatosIncompletos nuevoSolicitudDatosIncompletos);
        Task<RespuestaBD> EditarTranscripcionErroneaAsync(ActualizarTranscripcionErronea actualizarTranscripcionErronea);
        Task<RespuestaBD> EditarSolicitudDatosIncompletosAsync(ActualizarSolicitudDatosIncompletos actualizarSolicitudDatosIncompletos);
        Task<IEnumerable<TranscripcionErroneaGeneral>> ListarTranscripcionErroneaAsync(int? Id);
        Task<IEnumerable<SolicitudDatosIncompletosGeneral>> ListarSolicitudDatosIncompletosAsync(int? Id);
        Task<SolicitudDatosIncompletos> EncontrarSolicitudDatosIncompletosAsync(int Id);
        Task<TranscripcionErronea> EncontrarTranscripcionErroneaAsync(int Id);
    }
}
