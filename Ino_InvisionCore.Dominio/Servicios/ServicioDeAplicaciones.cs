using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Aplicacion;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Aplicacion;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeAplicaciones : IServicioDeAplicaciones
    {
        public IRepositorioDeAplicaciones RepositorioDeAplicaciones { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeAplicaciones(IRepositorioDeAplicaciones repositorioDeAplicaciones, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeAplicaciones = repositorioDeAplicaciones;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD Actualizar(ActualizarAplicacion peticionDeActualizacion)
        {
            RespuestaBD respuesta = RepositorioDeAplicaciones.Actualizar(peticionDeActualizacion);
            if (respuesta.Id != 0)
            {
                Aplicacion aplicacionEncontrada = RepositorioDeAplicaciones.ObtenerAplicacion(peticionDeActualizacion.IdAplicacion);
                string valoresAntiguos = JsonConvert.SerializeObject(aplicacionEncontrada);
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Actualizar",
                    NombreTabla = "Aplicacion",
                    ValoresAntiguos = valoresAntiguos,
                    ValoresNuevos = JsonConvert.SerializeObject(peticionDeActualizacion),
                    IdUsuario = peticionDeActualizacion.IdUsuarioModificacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }
            return respuesta;    
        }

        public RespuestaBD Crear(NuevaAplicacion peticionDeCreacion)
        {
            RespuestaBD respuesta = RepositorioDeAplicaciones.Crear(peticionDeCreacion);
            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "Aplicacion",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(peticionDeCreacion),
                    IdUsuario = peticionDeCreacion.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }
            
            return respuesta;
        }

        public IEnumerable<AplicacionGeneral> Listar(int? Id)
        {
            return RepositorioDeAplicaciones.Listar(Id);
        }
    }
}
