// RepositorioDeFacturacion.cs18:1418:14

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Facturacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Facturacion;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Facturacion;
using Ino_InvisionCore.Infraestructura.Contexto;
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
                                x.FechaEmision.Value.Date >= fechaDesde
                                && x.FechaEmision.Value.Date <= fechaHasta)
                    .ToListAsync();

                return listaDb;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<FactComprobantesPago>();
            }
        }
    }
}