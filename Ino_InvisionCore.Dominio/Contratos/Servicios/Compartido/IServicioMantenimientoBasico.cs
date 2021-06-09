using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Compartido
{
    public interface IServicioMantenimientoBasico <TClaseDeCreacion, TClaseDeActualizacion, TClaseRespuestaGeneral>
    {
        RespuestaBD Crear(TClaseDeCreacion peticionDeCreacion);
        IEnumerable<TClaseRespuestaGeneral> Listar(int? Id);
        RespuestaBD Actualizar(TClaseDeActualizacion peticionDeActualizacion);
    }
}
