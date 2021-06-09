using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Compartido;
using Ino_InvisionCore.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Seguridad
{
    public interface IRepositorioDeRoles : IMantenimientoBasico<NuevoRol, ActualizarRol, RolGeneral>
    {
        Rol EncontrarRol(int Id);

        Task<Rol> EncontrarRolAsync(int Id);
    }
}
