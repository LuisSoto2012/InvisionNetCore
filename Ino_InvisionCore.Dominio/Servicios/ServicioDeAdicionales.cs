using Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Adicional.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Paciente.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Adicional;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Adicional;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeAdicionales : IServicioDeAdicionales
    {
        public IRepositorioDeAdicionales RepositorioDeAdicionales { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeAdicionales(IRepositorioDeAdicionales repositorioDeAdicionales, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeAdicionales = repositorioDeAdicionales;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public IEnumerable<Adicionales> ConsultaExternaAdicionalesPorMedicoListar(BuscarPaciente paciente)
        {
            return RepositorioDeAdicionales.ConsultaExternaAdicionalesPorMedicoListar(paciente);
        }

        public int ConsultaExternaAdicionalesPorMedicoRegistrar(NuevoAdicional nuevaAdicional)
        {
            // Auditoria
            AuditoriaGeneral auditoria = new AuditoriaGeneral
            {
                Accion = "Agregar",
                NombreTabla = "CitaAdicional",
                ValoresAntiguos = null,
                ValoresNuevos = JsonConvert.SerializeObject(nuevaAdicional),
                IdUsuario = nuevaAdicional.IdUsuario
            };
            ServicioDeAuditoria.AgregarAuditoria(auditoria);
            return RepositorioDeAdicionales.ConsultaExternaAdicionalesPorMedicoRegistrar(nuevaAdicional);
        }
    }
}
