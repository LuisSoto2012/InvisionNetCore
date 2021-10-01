using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Seguridad;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Seguridad;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeRoles : IServicioDeRoles
    {
        public IRepositorioDeRoles RepositorioDeRoles { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeRoles(IRepositorioDeRoles repositorioDeRoles, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeRoles = repositorioDeRoles;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD Actualizar(ActualizarRol peticionDeActualizacion)
        {
            RespuestaBD respuesta = RepositorioDeRoles.Actualizar(peticionDeActualizacion);

            if (respuesta.Id != 0)
            {
                Rol rolEncontrado = RepositorioDeRoles.EncontrarRol(peticionDeActualizacion.IdRol);
                string valoresAntiguos = JsonConvert.SerializeObject(rolEncontrado);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "Rol",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(peticionDeActualizacion),
                    IdUsuario = peticionDeActualizacion.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD Crear(NuevoRol peticionDeCreacion)
        {
            RespuestaBD respuesta = RepositorioDeRoles.Crear(peticionDeCreacion);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "Rol",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(peticionDeCreacion),
                    IdUsuario = peticionDeCreacion.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public IEnumerable<RolGeneral> Listar(int? Id)
        {
            return RepositorioDeRoles.Listar(Id);
        }
        
        
    }
}
