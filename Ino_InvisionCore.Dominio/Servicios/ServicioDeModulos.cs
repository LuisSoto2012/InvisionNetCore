using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Modulo;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Modulo;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeModulos : IServicioDeModulos
    {
        public IRepositorioDeModulos RepositorioDeModulos { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeModulos(IRepositorioDeModulos repositorioDeModulos, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeModulos = repositorioDeModulos;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD Actualizar(ActualizarModulo peticionDeActualizacion)
        {
            RespuestaBD respuesta = RepositorioDeModulos.Actualizar(peticionDeActualizacion);

            if (respuesta.Id != 0)
            {
                Modulo moduloEncontrada = RepositorioDeModulos.EncontrarModulo(peticionDeActualizacion.IdModulo);
                string valoresAntiguos = JsonConvert.SerializeObject(moduloEncontrada);

                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "Modulo",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(peticionDeActualizacion),
                    IdUsuario = peticionDeActualizacion.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public RespuestaBD Crear(NuevoModulo peticionDeCreacion)
        {
            RespuestaBD respuesta = RepositorioDeModulos.Crear(peticionDeCreacion);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "Modulo",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(peticionDeCreacion),
                    IdUsuario = peticionDeCreacion.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public IEnumerable<ModuloGeneral> Listar(int? Id)
        {
            return RepositorioDeModulos.Listar(Id);
        }
    }
}
