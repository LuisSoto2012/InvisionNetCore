using Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.AccidenteTrabajo
{
    public interface IServicioDeAccidentesTrabajo
    {
        RespuestaBD Crear(RegistroAccidenteDeTrabajo solicitud);
        RespuestaBD Actualizar(ActualizarAccidenteDeTrabajo solicitud);
        IEnumerable<AccidenteDeTrabajoDto> Listar();
    }
}
