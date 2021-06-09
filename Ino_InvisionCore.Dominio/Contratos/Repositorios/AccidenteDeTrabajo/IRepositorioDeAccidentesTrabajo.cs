using Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.AccidenteDeTrabajo
{
    public interface IRepositorioDeAccidentesTrabajo
    {
        RespuestaBD RegistrarAccidenteDeTrabajo(RegistroAccidenteDeTrabajo request);
        RespuestaBD ActualizarAccidenteDeTrabajo(ActualizarAccidenteDeTrabajo request);
        Ino_InvisionCore.Dominio.Entidades.AccidenteDeTrabajo.AccidenteDeTrabajo ObtenerAccidenteDeTrabajo(int id);
        IEnumerable<AccidenteDeTrabajoDto> ListarAccidenteDeTrabajo();
    }
}
