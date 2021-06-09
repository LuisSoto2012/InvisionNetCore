using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.SubModulo;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.SubModulo;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeSubModulos : IServicioDeSubModulos
    {
        public IRepositorioDeSubModulos RepositorioDeSubModulos { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeSubModulos(IRepositorioDeSubModulos repositorioDeSubModulos, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeSubModulos = repositorioDeSubModulos;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD Actualizar(ActualizarSubModulo peticionDeActualizacion)
        {
            RespuestaBD respuesta = RepositorioDeSubModulos.Actualizar(peticionDeActualizacion);
            
            if (respuesta.Id != 0)
            {
                SubModulo subModuloEncontrada = RepositorioDeSubModulos.EncontrarSubModulo(peticionDeActualizacion.IdSubModulo);
                string valoresAntiguos = JsonConvert.SerializeObject(subModuloEncontrada);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "SubModulo",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(peticionDeActualizacion),
                    IdUsuario = peticionDeActualizacion.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD AsignarRolSubModulo(RolSubModuloDto rolSubModuloDto)
        {
            RespuestaBD respuesta = RepositorioDeSubModulos.AsignarRolSubModulo(rolSubModuloDto);

            if (respuesta.Id != 0)
            {
                RolSubModulo rolSubModulo = RepositorioDeSubModulos.EncontrarRolSubModulo(rolSubModuloDto.IdRolSubModulo);
                string valoresAntiguos = JsonConvert.SerializeObject(rolSubModulo);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "AsignarRol",
                    NombreTabla = "SubModulo",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(rolSubModuloDto),
                    IdUsuario = rolSubModuloDto.IdUsuarioRegistra
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD Crear(NuevoSubModulo peticionDeCreacion)
        {
            RespuestaBD respuesta = RepositorioDeSubModulos.Crear(peticionDeCreacion);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "SubModulo",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(peticionDeCreacion),
                    IdUsuario = peticionDeCreacion.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public IEnumerable<SubModuloGeneral> Listar(int? Id)
        {
            return RepositorioDeSubModulos.Listar(Id);
        }

        public IEnumerable<RolSubModuloDto> ObtenerRolSubModulo(RolSubModuloDto rolSubModuloDto)
        {
            return RepositorioDeSubModulos.ObtenerRolSubModulo(rolSubModuloDto);
        }
    }
}
