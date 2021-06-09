using Ino_InvisionCore.Dominio.Contratos.Helpers.Auditoria.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.OrdenMedica;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.OrdenMedica;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeOrdenesMedicas : IServicioDeOrdenesMedicas
    {
        public IRepositorioDeOrdenesMedicas RepositorioDeOrdenesMedicas { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeOrdenesMedicas(IRepositorioDeOrdenesMedicas repositorioDeOrdenesMedicas, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeOrdenesMedicas = repositorioDeOrdenesMedicas;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public RespuestaBD AgregarOrdenMedica(NuevaOrdenMedica nuevaOrdenMedica)
        {
            RespuestaBD respuesta = RepositorioDeOrdenesMedicas.AgregarOrdenMedica(nuevaOrdenMedica);

            if (respuesta.Id > 0)
            {
                // Auditoria
                AuditoriaGeneral auditoria = new AuditoriaGeneral
                {
                    Accion = "Agregar",
                    NombreTabla = string.Concat("OrdenesMedicas|", nuevaOrdenMedica.IdTipoOrdenMedica),
                    ValoresAntiguos = null,
                    ValoresNuevos = JsonConvert.SerializeObject(nuevaOrdenMedica),
                    IdUsuario = nuevaOrdenMedica.IdUsuarioCreacion
                };
                ServicioDeAuditoria.AgregarAuditoria(auditoria);
            }

            return respuesta;
        }

        public IEnumerable<OrdenMedicaGeneral> ListarOrdenesMedicas(int? IdUsuario, int? IdOrdenMedica, int? idAtencion)
        {
            return RepositorioDeOrdenesMedicas.ListarOrdenesMedicas(IdUsuario, IdOrdenMedica, idAtencion);
        }

        public async Task<IEnumerable<OrdenMedicaGeneral>> ListarOrdenesMedicasPorDocumento(string numeroDocumento)
        {
            return await RepositorioDeOrdenesMedicas.ListarOrdenesMedicasPorDocumentoAsync(numeroDocumento);
        }

        public IEnumerable<TipoOrdenMedicaGeneral> ListarTipoOrdenMedica(int? Id)
        {
            return RepositorioDeOrdenesMedicas.ListarTipoOrdenMedica(Id);
        }

        public async Task<RespuestaBD> EliminarOrdenMedica(int idOrdenMedica)
        {
            RespuestaBD respuesta = await RepositorioDeOrdenesMedicas.EliminarOrdenMedica(idOrdenMedica);

            return respuesta;
        }
    }
}
