using Ino_InvisionCore.Dominio.Contratos.Helpers.NervioOptico.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.NervioOptico.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.NervioOptico
{
    public interface IServicioDeNervioOptico
    {
        Task<RespuestaBD> RegistrarNervioOptico(RegistrarNervioOptico solicitud);
        Task<RespuestaBD> ModificarNervioOptico(ModificarNervioOptico solicitud);
        Task<RespuestaBD> EliminarNervioOptico(EliminarNervioOptico solicitud);
        Task<IEnumerable<NervioOpticoDto>> ListarNervioOptico(int idAtencion);
    }
}
