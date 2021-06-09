using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Modulo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Modulo
{
    public interface IServicioDeModulos : IServicioMantenimientoBasico<NuevoModulo, ActualizarModulo, ModuloGeneral>
    {
    }
}
