using Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.OrdenMedica.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.OrdenMedica
{
    public interface IRepositorioDeOrdenesMedicas
    {
        RespuestaBD AgregarOrdenMedica(NuevaOrdenMedica nuevaOrdenMedica);
        Task<RespuestaBD> EliminarOrdenMedica(int idOrdenMedica);
        IEnumerable<OrdenMedicaGeneral> ListarOrdenesMedicas(int? IdUsuario, int? IdOrdenMedica, int? idAtencion);
        IEnumerable<TipoOrdenMedicaGeneral> ListarTipoOrdenMedica(int? Id);

        Task<RespuestaBD> AgregarOrdenMedicaAsync(NuevaOrdenMedica nuevaOrdenMedica);
        Task<IEnumerable<OrdenMedicaGeneral>> ListarOrdenesMedicasAsync(int? IdUsuario, int? IdOrdenMedica);
        Task<IEnumerable<OrdenMedicaGeneral>> ListarOrdenesMedicasPorDocumentoAsync(string numeroDocumento);
        Task<IEnumerable<TipoOrdenMedicaGeneral>> ListarTipoOrdenMedicaAsync(int? Id);
    }
}
