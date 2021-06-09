using Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.AccidenteDeTrabajo;
using Ino_InvisionCore.Dominio.Contratos.Servicios.AccidenteTrabajo;
using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeAccidentesTrabajo : IServicioDeAccidentesTrabajo
    {
        public IRepositorioDeAccidentesTrabajo _repositorio { get; set; }

        public ServicioDeAccidentesTrabajo(IRepositorioDeAccidentesTrabajo repositorio)
        {
            _repositorio = repositorio;
        }

        public RespuestaBD Crear(RegistroAccidenteDeTrabajo solicitud)
        {
            return _repositorio.RegistrarAccidenteDeTrabajo(solicitud);
        }

        public IEnumerable<AccidenteDeTrabajoDto> Listar()
        {
            return _repositorio.ListarAccidenteDeTrabajo();
        }

        public RespuestaBD Actualizar(ActualizarAccidenteDeTrabajo solicitud)
        {
            return _repositorio.ActualizarAccidenteDeTrabajo(solicitud);
        }
    }
}
