using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.SubModulo
{
    public interface IServicioDeSubModulos : IServicioMantenimientoBasico<NuevoSubModulo, ActualizarSubModulo, SubModuloGeneral>
    {
        RespuestaBD AsignarRolSubModulo(RolSubModuloDto rolSubModuloDto);
        IEnumerable<RolSubModuloDto> ObtenerRolSubModulo(RolSubModuloDto rolSubModuloDto);
    }
}
