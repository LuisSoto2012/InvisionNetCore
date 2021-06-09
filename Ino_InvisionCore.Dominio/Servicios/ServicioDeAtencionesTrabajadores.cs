using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionTrabajador.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.AtencionTrabajador;
using Ino_InvisionCore.Dominio.Contratos.Servicios.AtencionTrabajador;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeAtencionesTrabajadores : IServicioDeAtencionesTrabajadores
    {
        public IRepositorioDeAtencionesTrabajadores RepositorioDeAtencionesTrabajadores { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeAtencionesTrabajadores(IRepositorioDeAtencionesTrabajadores repositorioDeAtencionesTrabajadores, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeAtencionesTrabajadores = repositorioDeAtencionesTrabajadores;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public IEnumerable<AtencionTrabajadorGeneral> ListarAtencionTrabajador(int? Id)
        {
            return RepositorioDeAtencionesTrabajadores.ListarAtencionTrabajador(Id);
        }

        public RespuestaBD RegistrarAtencionTrabajador(NuevaAtencionTrabajador nuevaAtencionTrabajador)
        {
            RespuestaBD respuesta = RepositorioDeAtencionesTrabajadores.RegistrarAtencionTrabajador(nuevaAtencionTrabajador);

            if (respuesta.Id != 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = "AtencionTrabajador",
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(nuevaAtencionTrabajador),
                    IdUsuario = nuevaAtencionTrabajador.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }
    }
}
