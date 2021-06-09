using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionTrabajador.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.AtencionTrabajador
{
    public interface IServicioDeAtencionesTrabajadores
    {
        RespuestaBD RegistrarAtencionTrabajador(NuevaAtencionTrabajador nuevaAtencionTrabajador);
        IEnumerable<AtencionTrabajadorGeneral> ListarAtencionTrabajador(int? Id);
    }
}
