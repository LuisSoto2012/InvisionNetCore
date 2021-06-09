using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.SubModulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Compartido;
using Ino_InvisionCore.Dominio.Entidades;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.SubModulo
{
    public interface IRepositorioDeSubModulos : IMantenimientoBasico<NuevoSubModulo, ActualizarSubModulo, SubModuloGeneral>
    {
        RespuestaBD AsignarRolSubModulo(RolSubModuloDto rolSubModuloDto);
        IEnumerable<RolSubModuloDto> ObtenerRolSubModulo(RolSubModuloDto rolSubModuloDto);
        Dominio.Entidades.SubModulo EncontrarSubModulo(int Id);
        RolSubModulo EncontrarRolSubModulo(int id);

        Task<RespuestaBD> AsignarRolSubModuloAsync(RolSubModuloDto rolSubModuloDto);
        Task<IEnumerable<RolSubModuloDto>> ObtenerRolSubModuloAsync(RolSubModuloDto rolSubModuloDto);
        Task<Dominio.Entidades.SubModulo> EncontrarSubModuloAsync(int Id);
        Task<RolSubModulo> EncontrarRolSubModuloAsync(int id);
    }
}
