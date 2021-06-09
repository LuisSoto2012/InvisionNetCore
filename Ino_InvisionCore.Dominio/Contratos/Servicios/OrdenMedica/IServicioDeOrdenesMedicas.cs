using Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.OrdenMedica
{
    public interface IServicioDeOrdenesMedicas
    {
        RespuestaBD AgregarOrdenMedica(NuevaOrdenMedica nuevaOrdenMedica);
        Task<RespuestaBD> EliminarOrdenMedica(int idOrdenMedica);
        IEnumerable<OrdenMedicaGeneral> ListarOrdenesMedicas(int? IdUsuario, int? IdOrdenMedica, int? idAtencion);
        Task<IEnumerable<OrdenMedicaGeneral>> ListarOrdenesMedicasPorDocumento(string numeroDocumento);
        IEnumerable<TipoOrdenMedicaGeneral> ListarTipoOrdenMedica(int? Id);
    }
}
