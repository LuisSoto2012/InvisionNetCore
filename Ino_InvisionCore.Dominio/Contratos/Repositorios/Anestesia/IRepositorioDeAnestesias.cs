using System;
using System.Collections.Generic;
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
        Task<IEnumerable<EvaluacionPreAnestesicaDto>> ListarEvaluacionPreAnestesica(int idAtencion);
        Task<RespuestaBD> EliminarEvaluacionPreAnestesica(EliminarPreAnestesiaDto solicitud);
        //Task<EvaluacionPreAnestesicaDto> ListarEvaluacionPreAnestesica();
    }
}
