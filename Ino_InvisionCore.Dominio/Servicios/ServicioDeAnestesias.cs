using System;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Anestesia.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.Anestesia;
using Ino_InvisionCore.Dominio.Contratos.Servicios.Anestesia;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeAnestesias : IServicioDeAnestesias
    {
        private readonly IRepositorioDeAnestesias _repositorio;

        public ServicioDeAnestesias(IRepositorioDeAnestesias repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<RespuestaBD> ModificarEvaluacionPreAnestesica(ModificarEvaluacionPreAnestesica solicitud)
        {
            return await _repositorio.ModificarEvaluacionPreAnestesica(solicitud);
        }

        public async Task<RespuestaBD> RegistrarEvaluacionPreAnestesica(RegistrarEvaluacionPreAnestesica solicitud)
        {
            return await _repositorio.RegistrarEvaluacionPreAnestesica(solicitud);
        }
    }
}
