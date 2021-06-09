using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionTrabajador.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionTrabajador.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.AtencionTrabajador
{
    public interface IRepositorioDeAtencionesTrabajadores
    {
        RespuestaBD RegistrarAtencionTrabajador(NuevaAtencionTrabajador nuevaAtencionTrabajador);
        IEnumerable<AtencionTrabajadorGeneral> ListarAtencionTrabajador(int? Id);

        Task<RespuestaBD> RegistrarAtencionTrabajadorAsync(NuevaAtencionTrabajador nuevaAtencionTrabajador);
        Task<IEnumerable<AtencionTrabajadorGeneral>> ListarAtencionTrabajadorAsync(int? Id);
    }
}
