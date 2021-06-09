using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Comunes
{
    public interface IServicioDeComunes
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

        Task<IEnumerable<ComboBox>> ListarEspecificaciones();
        Task<IEnumerable<ComboBox>> ListarBifocales();
        Task<IEnumerable<ComboBox>> ListarMateriales();
        Task<IEnumerable<ComboBox>> ListarMedicamentosFarmacia();
    }
}
