using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PacienteSinResulado.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.PacienteSinResulado.Repuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErroneaInoportuna.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Laboratorio.TranscripcionErroneaInoportuna.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Laboratorio
{
    public interface IRepositorioDeTranscripcionResultados
    {
        RespuestaBD AgregarTranscripcionErroneaInoportuna(NuevoTranscripcionErroneaInoportuna nuevoTranscripcionErroneaInoportuna);
        RespuestaBD EditarTranscripcionErroneaInoportuna(ActualizarTranscripcionErroneaInoportuna actualizarTranscripcionErroneaInoportuna);
        IEnumerable<TranscripcionErroneaInoportunaGeneral> ListarTranscripcionErroneaInoportuna();
        RespuestaBD AgregarPacienteSinResultado(NuevoPacienteSinResultado nuevoPacienteSinResultado);
        RespuestaBD EditarPacienteSinResultado(ActualizarPacienteSinResultado actualizarPacienteSinResultado);
        IEnumerable<PacienteSinResultadoGeneral> ListarPacienteSinResultado();
        PacienteSinResultado EncontrarPacienteSinResultado(int Id);
        TranscripcionErroneaInoportuna EncontrarTranscripcionErroneaInoportuna(int Id);

        Task<RespuestaBD> AgregarTranscripcionErroneaInoportunaAsync(NuevoTranscripcionErroneaInoportuna nuevoTranscripcionErroneaInoportuna);
        Task<RespuestaBD> EditarTranscripcionErroneaInoportunaAsync(ActualizarTranscripcionErroneaInoportuna actualizarTranscripcionErroneaInoportuna);
        Task<IEnumerable<TranscripcionErroneaInoportunaGeneral>> ListarTranscripcionErroneaInoportunaAsync(int? Id);
        Task<RespuestaBD> AgregarPacienteSinResultadoAsync(NuevoPacienteSinResultado nuevoPacienteSinResultado);
        Task<RespuestaBD> EditarPacienteSinResultadoAsync(ActualizarPacienteSinResultado actualizarPacienteSinResultado);
        Task<IEnumerable<PacienteSinResultadoGeneral>> ListarPacienteSinResultadoAsync(int? Id);
        Task<PacienteSinResultado> EncontrarPacienteSinResultadoAsync(int Id);
        Task<TranscripcionErroneaInoportuna> EncontrarTranscripcionErroneaInoportunaAsync(int Id);
    }
}
