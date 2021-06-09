using Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.COVID19
{
    public interface IRepositorioDeVacunacionCOVID19
    {
        Task<ConsultaDataDto> ObtenerDatosPorDocumento(string numeroDocumento);
        Task<RespuestaBD> GuardarConsentimientoInformado(GuardarCIDto solicitud);
        Task<IEnumerable<DataCIDto>> ListarConsentimientosInformados(DateTime fechaDesde, DateTime fechaHasta, bool vacunacion);
        Task<RespuestaBD> GuardarVacunacion(GuardarVacDto solicitud);
        Task<RespuestaBD> GuardarRevocatoria(GuardarRevocatoriaDto solicitud);
    }
}
