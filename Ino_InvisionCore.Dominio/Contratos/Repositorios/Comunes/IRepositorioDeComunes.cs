using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Comunes
{
    public interface IRepositorioDeComunes
    {
        IEnumerable<ComboBox> ListarCondicionTrabajo();
        IEnumerable<ComboBox> ListarTipoEmpleado();
        IEnumerable<ComboBox> ListarTipoDocumentoIdentidad();
        IEnumerable<ComboBox> ListarAreaLaboratorio(int? Id);
        IEnumerable<ComboBox> ListarPruebaLabotario(string Codigo);
        IEnumerable<ComboBox> ListarServicioEspecialidad(int? Id);
        IEnumerable<ComboBox> ListarEspecialidades();
        IEnumerable<ComboBox> ListarUsuarioPorRol(int? Id);
        IEnumerable<ComboBox> ListarAlmacenes();
        IEnumerable<ComboBox> ListarEscalafonDeLegajos();
        ComboBox ListarRespuestaIndicadoresDesempeno(string codigo);
        IEnumerable<ComboBox> ListarCajeros();

        Task<IEnumerable<ComboBox>> ListarCondicionTrabajoAsync();
        Task<IEnumerable<ComboBox>> ListarTipoEmpleadoAsync();
        Task<IEnumerable<ComboBox>> ListarTipoDocumentoIdentidadAsync();
        Task<IEnumerable<ComboBox>> ListarAreaLaboratorioAsync(int? Id);
        Task<IEnumerable<ComboBox>> ListarPruebaLabotarioAsync(string Codigo);
        Task<IEnumerable<ComboBox>> ListarServicioEspecialidadAsync(int? Id);
        Task<IEnumerable<ComboBox>> ListarEspecialidadesAsync();
        Task<IEnumerable<ComboBox>> ListarUsuarioPorRolAsync(int? Id);
        Task<IEnumerable<ComboBox>> ListarAlmacenesAsync();
        Task<IEnumerable<ComboBox>> ListarEscalafonDeLegajosAsync();
        Task<ComboBox> ListarRespuestaIndicadoresDesempenoAsync(string codigo);
        Task<IEnumerable<ComboBox>> ListarCajerosAsync();

        Task<IEnumerable<ComboBox>> ListarEspecificaciones();
        Task<IEnumerable<ComboBox>> ListarBifocales();
        Task<IEnumerable<ComboBox>> ListarMateriales();

        Task<IEnumerable<ComboBox>> ListarMedicamentosFarmacia();

        Task<IEnumerable<ComboBox>> ListarCallCenterUsuariosAsync();
        Task<IEnumerable<ComboBox>> ListarMedicosReporte();    
    }
}
