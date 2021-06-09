using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Aplicacion.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.Aplicacion
{
    public interface IServicioDeAplicaciones : IServicioMantenimientoBasico<NuevaAplicacion, ActualizarAplicacion, AplicacionGeneral>
    {

    }
}
