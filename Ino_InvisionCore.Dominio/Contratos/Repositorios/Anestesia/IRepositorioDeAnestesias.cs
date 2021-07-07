using System;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Anestesia.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Anestesia.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.Anestesia
{
    public interface IRepositorioDeAnestesias
    {
        Task<RespuestaBD> RegistrarEvaluacionPreAnestesica(RegistrarEvaluacionPreAnestesica solicitud);
        Task<RespuestaBD> ModificarEvaluacionPreAnestesica(ModificarEvaluacionPreAnestesica solicitud);
        //Task<EvaluacionPreAnestesicaDto> ListarEvaluacionPreAnestesica();
    }
}
