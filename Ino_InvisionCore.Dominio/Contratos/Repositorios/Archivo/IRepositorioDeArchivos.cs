using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Archivo
{
    public interface IRepositorioDeArchivos
    {
        RespuestaBD Agregar(NuevoArchivo nuevoArchivo);
        IEnumerable<ArchivoGeneral> Listar(ArchivoGeneral archivoGeneral);
        string Eliminar(EliminarArchivo archivoEliminado);
        IEnumerable<ArchivoPorFechaYUsuario> ListarArchivoPorFechaYUsuario(ConsultarArchivoPor archivoPor);
        Dominio.Entidades.Archivo EncontrarArchivo(int Id);

        Task<RespuestaBD> AgregarAsync(NuevoArchivo nuevoArchivo);
        Task<IEnumerable<ArchivoGeneral>> ListarAsync(ArchivoGeneral archivoGeneral);
        Task<string> EliminarAsync(EliminarArchivo archivoEliminado);
        Task<IEnumerable<ArchivoPorFechaYUsuario>> ListarArchivoPorFechaYUsuarioAsync(ConsultarArchivoPor archivoPor);
        Task<Dominio.Entidades.Archivo> EncontrarArchivoAsync(int Id);
    }
}
