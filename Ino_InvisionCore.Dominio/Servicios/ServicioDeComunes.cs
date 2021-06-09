using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Comunes;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Auditoria;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Comunes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeComunes : IServicioDeComunes
    {
        public IRepositorioDeComunes RepositorioDeComunes { get; set; }
        public IServicioDeAuditoria ServicioDeAuditoria { get; set; }

        public ServicioDeComunes(IRepositorioDeComunes repositorioDeComunes, IServicioDeAuditoria servicioDeAuditoria)
        {
            RepositorioDeComunes = repositorioDeComunes;
            ServicioDeAuditoria = servicioDeAuditoria;
        }

        public IEnumerable<ComboBox> ListarAlmacenes()
        {
            return RepositorioDeComunes.ListarAlmacenes();
        }

        public IEnumerable<ComboBox> ListarAreaLaboratorio(int? Id)
        {
            return RepositorioDeComunes.ListarAreaLaboratorio(Id);
        }

        public IEnumerable<ComboBox> ListarCondicionTrabajo()
        {
            return RepositorioDeComunes.ListarCondicionTrabajo();
        }

        public IEnumerable<ComboBox> ListarEscalafonDeLegajos()
        {
            return RepositorioDeComunes.ListarEscalafonDeLegajos();
        }

        public IEnumerable<ComboBox> ListarEspecialidades()
        {
            return RepositorioDeComunes.ListarEspecialidades();
        }

        public IEnumerable<ComboBox> ListarPruebaLabotario(string Codigo)
        {
            return RepositorioDeComunes.ListarPruebaLabotario(Codigo);
        }

        public ComboBox ListarRespuestaIndicadoresDesempeno(string codigo)
        {
            return RepositorioDeComunes.ListarRespuestaIndicadoresDesempeno(codigo);
        }

        public IEnumerable<ComboBox> ListarServicioEspecialidad(int? Id)
        {
            return RepositorioDeComunes.ListarServicioEspecialidad(Id);
        }

        public IEnumerable<ComboBox> ListarTipoDocumentoIdentidad()
        {
            return RepositorioDeComunes.ListarTipoDocumentoIdentidad();
        }

        public IEnumerable<ComboBox> ListarTipoEmpleado()
        {
            return RepositorioDeComunes.ListarTipoEmpleado();
        }

        public IEnumerable<ComboBox> ListarUsuarioPorRol(int? Id)
        {
            return RepositorioDeComunes.ListarUsuarioPorRol(Id);
        }

        public IEnumerable<ComboBox> ListarCajeros()
        {
            return RepositorioDeComunes.ListarCajeros();
        }

        public async Task<IEnumerable<ComboBox>> ListarEspecificaciones()
        {
            return await RepositorioDeComunes.ListarEspecificaciones();
        }

        public async Task<IEnumerable<ComboBox>> ListarBifocales()
        {
            return await RepositorioDeComunes.ListarBifocales();
        }

        public async Task<IEnumerable<ComboBox>> ListarMateriales()
        {
            return await RepositorioDeComunes.ListarMateriales();
        }

        public async Task<IEnumerable<ComboBox>> ListarMedicamentosFarmacia()
        {
            return await RepositorioDeComunes.ListarMedicamentosFarmacia();
        }
    }
}
