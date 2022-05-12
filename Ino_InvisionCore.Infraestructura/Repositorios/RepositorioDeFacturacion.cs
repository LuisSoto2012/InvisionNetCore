// RepositorioDeFacturacion.cs18:1418:14

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Facturacion;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Facturacion;
using Ino_InvisionCore.Infraestructura.Contexto;
using Ino_InvisionCore.Infraestructura.Contexto.ClassViews;
using Microsoft.EntityFrameworkCore;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeFacturacion : IRepositorioDeFacturacion
    {
        private readonly Ino_FacturacionContext _context;
        private readonly IMapper _mapper;
        private IRepositorioDeFacturacion _repositorioDeFacturacionImplementation;

        public RepositorioDeFacturacion(Ino_FacturacionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        public async Task<RespuestaBD> RegistrarNotaCreditoDebito(RegistrarNotaCreditoDebitoDto solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                var nuevoCompPago = _mapper.Map<FactComprobantesPago>(solicitud);
                _context.FactComprobantesPago.Add(nuevoCompPago);
                await _context.SaveChangesAsync();
                respuesta.Id = 1;
                respuesta.Mensaje = "Se ha registrado el comprobante de manera exitosa!";
            }
            catch (Exception e)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor";
            }
            
            return respuesta;
        }

        public async Task<IEnumerable<FactComprobantesPago>> ListarComprobantesPago(DateTime fechaDesde, DateTime fechaHasta, int idTipoDocumento)
        {
            try
            {
                var listaDb = await _context.FactComprobantesPago.Include(x => x.IdTipoDocumentoNavigation)
                    .Include(x => x.IdTipoOperacionNavigation)
                    .Include(x => x.EstadoNavigation)
                    .Where(x => x.IdTipoDocumento == idTipoDocumento && x.FechaEmision.HasValue &&
                                x.FechaEmision.Value.Date >= fechaDesde.Date
                                && x.FechaEmision.Value.Date <= fechaHasta.Date)
                    .ToListAsync();

                return listaDb;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<FactComprobantesPago>();
            }
        }

        public async Task<IEnumerable<FactTipoOperacion>> ListarTipoOperacion()
        {
            return await _context.FactTipoOperacion.OrderBy(x => x.Codigo).ToListAsync();
        }
        
        public async Task<IEnumerable<ComboBox>> ListarDistritos()
        {
            return await _context.Query<ComboBoxView>().FromSql("dbo.ListarDistritosGalenos"
                ).Select(x => Mapper.Map<ComboBox>(x))
                .ToListAsync();
        }

        public async Task<IEnumerable<ComprobantePagoGalenosDto>> ListarComprobantesPagoGalenos(string filtroTexto, string filtro)
        {
            return await _context.Query<ComprobantePagoGalenosView>().FromSql("dbo.ListarComprobantesPagoGalenos @FiltroTexto,@Filtro",
                    new SqlParameter("FiltroTexto",filtroTexto),
                    new SqlParameter("Filtro", filtro)
                ).Select(x => Mapper.Map<ComprobantePagoGalenosDto>(x))
                .ToListAsync();
        }
    }
}