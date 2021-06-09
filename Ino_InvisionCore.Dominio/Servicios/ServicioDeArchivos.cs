using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Archivo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Archivo;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Archivo;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeArchivos : IServicioDeArchivos
    {
        public IRepositorioDeArchivos RepositorioDeArchivos { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeArchivos(IRepositorioDeArchivos repositorioDeArchivos, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeArchivos = repositorioDeArchivos;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD Agregar(NuevoArchivo nuevoArchivo)
        {
            RespuestaBD respuesta = RepositorioDeArchivos.Agregar(nuevoArchivo);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "Archivo",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(nuevoArchivo),
                IdUsuario = nuevoArchivo.IdUsuarioCreacion
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return respuesta;
        }

        public string Eliminar(EliminarArchivo archivoEliminado)
        {
            string rutaCompleta = RepositorioDeArchivos.Eliminar(archivoEliminado);

            Archivo archivo = RepositorioDeArchivos.EncontrarArchivo(archivoEliminado.IdArchivo);
            string valoresAntiguos = JsonConvert.SerializeObject(archivo);

            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Eliminar",
                NombreTabla = "Archivo",
                ValoresAntiguos = valoresAntiguos,
                ValoresNuevos = null,
                IdUsuario = archivoEliminado.IdUsuario
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);

            return rutaCompleta;
        }

        public IEnumerable<ArchivoGeneral> Listar(ArchivoGeneral archivoGeneral)
        {
            return RepositorioDeArchivos.Listar(archivoGeneral);
        }

        public IEnumerable<ArchivoPorFechaYUsuario> ListarArchivoPorFechaYUsuario(ConsultarArchivoPor archivoPor)
        {
            return RepositorioDeArchivos.ListarArchivoPorFechaYUsuario(archivoPor);
        }
    }
}
