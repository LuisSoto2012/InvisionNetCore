using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Archivo
{
    public interface IServicioDeArchivos
    {
        RespuestaBD Agregar(NuevoArchivo nuevoArchivo);
        IEnumerable<ArchivoGeneral> Listar(ArchivoGeneral archivoGeneral);
        string Eliminar(EliminarArchivo archivoEliminado);
        IEnumerable<ArchivoPorFechaYUsuario> ListarArchivoPorFechaYUsuario(ConsultarArchivoPor archivoPor);
    }
}
