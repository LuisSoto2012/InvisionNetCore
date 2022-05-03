using Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Covid19.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.COVID19;
using Ino_InvisionCore.Dominio.Contratos.Servicios.COVID19;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeVacunacionCOVID19 : IServicioDeVacunacionCOVID19
    {
        public IRepositorioDeVacunacionCOVID19 _repositorio {get;set;}

        public ServicioDeVacunacionCOVID19(IRepositorioDeVacunacionCOVID19 repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<RespuestaBD> GuardarConsentimientoInformado(GuardarCIDto solicitud)
        {
            return await _repositorio.GuardarConsentimientoInformado(solicitud);
        }

        public async Task<ConsultaDataDto> ObtenerDatosPorDocumento(string numeroDocumento)
        {
            return await _repositorio.ObtenerDatosPorDocumentoDosis4(numeroDocumento);
        }

        public async Task<IEnumerable<DataCIDto>> ListarConsentimientosInformados(DateTime fechaDesde, DateTime fechaHasta, bool vacunacion)
        {
            return await _repositorio.ListarConsentimientosInformadosDosis4(fechaDesde, fechaHasta, vacunacion);
        }

        public async Task<RespuestaBD> GuardarVacunacion(GuardarVacDto solicitud)
        {
            return await _repositorio.GuardarVacunacion(solicitud);
        }

        public async Task<RespuestaBD> GuardarRevocatoria(GuardarRevocatoriaDto solicitud)
        {
            return await _repositorio.GuardarRevocatoria(solicitud);
        }
    }
}
