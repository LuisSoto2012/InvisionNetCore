using Ino_InvisionCore.Dominio.Contratos.Helpers.NervioOptico.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.NervioOptico.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.NervioOptico;
using Ino_InvisionCore.Dominio.Contratos.Servicios.NervioOptico;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeNervioOptico : IServicioDeNervioOptico
    {
        private readonly IRepositorioDeNervioOptico _repositorio;

        public ServicioDeNervioOptico(IRepositorioDeNervioOptico repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<RespuestaBD> EliminarNervioOptico(EliminarNervioOptico solicitud)
        {
            return await _repositorio.EliminarNervioOptico(solicitud);
        }

        public async Task<IEnumerable<NervioOpticoDto>> ListarNervioOptico(int idAtencion)
        {
            return await _repositorio.ListarNervioOptico(idAtencion);
        }

        public async Task<RespuestaBD> ModificarNervioOptico(ModificarNervioOptico solicitud)
        {
            return await _repositorio.ModificarNervioOptico(solicitud);
        }

        public async Task<RespuestaBD> RegistrarNervioOptico(RegistrarNervioOptico solicitud)
        {
            return await _repositorio.RegistrarNervioOptico(solicitud);
        }
    }
}
