// IServicioDeConsultasWeb.cs22:2522:25

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Contratos.Servicios.ConsultasWeb
{
    public interface IServicioDeCitasWeb
    {
        Task<RespuestaBD> RegistrarPaciente(RegistrarPacienteDto solicitud);
        Task<PacienteCitaWebLogin> Login(string usuario, string contrasena);
        Task<RespuestaBD> RegistrarConsultaRapida(RegistrarConsultaRapida solicitud);
        Task<IEnumerable<CuposProgramacionDto>> ListarCuposProgramacion(DateTime fecha, int idEspecialidad);
    }
}