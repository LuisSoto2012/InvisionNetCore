using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Modulo
{
    public interface IRepositorioDeModulos : IMantenimientoBasico<NuevoModulo, ActualizarModulo, ModuloGeneral>
    {
        Dominio.Entidades.Modulo EncontrarModulo(int Id);

        Task<Dominio.Entidades.Modulo> EncontrarModuloAsync(int Id);
    }
}
