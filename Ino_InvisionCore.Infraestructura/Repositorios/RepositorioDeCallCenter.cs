using AutoMapper;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CallCenter.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CallCenter.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.CallCenter;
using Ino_InvisionCore.Dominio.Entidades.CallCenter;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Infraestructura.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Infraestructura.Repositorios
{
    public class RepositorioDeCallCenter : IRepositorioDeCallCenter
    {
        private readonly InoContext _inoContext;

        public RepositorioDeCallCenter(InoContext inoContext)
        {
            _inoContext = inoContext;
        }

        public async Task<IEnumerable<CitaCallCenterDto>> ListarCitaCallCenter(DateTime fechaDesde, DateTime fechaHasta)
        {
            var list = await _inoContext.CitasCallCenter.OrderByDescending(x => x.FechaRegistro).Where(x => x.FechaRegistro.Date >= fechaDesde.Date && x.FechaRegistro.Date <= fechaHasta).ToListAsync();
            return list.Select(x => Mapper.Map<CitaCallCenterDto>(x));
        }

        public async Task<RespuestaBD> RegistrarCitaCallCenter(RegistrarCitaCallCenter solicitud)
        {
            RespuestaBD respuesta = new RespuestaBD();

            try
            {
                var nuevaCita = Mapper.Map<CitaCallCenter>(solicitud);
                _inoContext.Add(nuevaCita);

                await _inoContext.SaveChangesAsync();

                respuesta.Id = 1;
                respuesta.Mensaje = "Registro exitoso!";
            }
            catch (Exception ex)
            {
                respuesta.Id = 0;
                respuesta.Mensaje = "Error en el servidor. Inténtelo más tarde.";
            }

            return respuesta;
        }
    }
}
