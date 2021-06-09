using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Compartido
{
    public interface IMantenimientoBasico<TClaseDeCreacion, TClaseDeActualizacion, TClaseRespuestaGeneral>
    {
        RespuestaBD Crear(TClaseDeCreacion peticionDeCreacion);
        IEnumerable<TClaseRespuestaGeneral> Listar(int? Id);
        RespuestaBD Actualizar(TClaseDeActualizacion peticionDeActualizacion);

        Task<RespuestaBD> CrearAsync(TClaseDeCreacion peticionDeCreacion);
        Task<IEnumerable<TClaseRespuestaGeneral>> ListarAsync(int? Id);
        Task<RespuestaBD> ActualizarAsync(TClaseDeActualizacion peticionDeActualizacion);
    }
}
