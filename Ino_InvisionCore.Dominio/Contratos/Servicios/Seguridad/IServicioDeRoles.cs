using Ino_InvisionCore.Dominio.Contratos.Helpers.Reporte.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Seguridad.Rol.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Seguridad
{
    public interface IServicioDeRoles : IServicioMantenimientoBasico<NuevoRol, ActualizarRol, RolGeneral>
    {
    }
}
