// IRepositorioDeCitasWeb.cs21:5121:51

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Respuestas;
using Ino_InvisionCore.Dominio.Entidades.CitasWeb;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Contratos.Repositorios.CitasWeb
{
    public interface IRepositorioDeCitasWeb
    {
        Task<RespuestaBD> RegistrarPaciente(RegistrarPacienteDto solicitud);
        Task<PacienteCitaWebLogin> Login(string usuario, string contrasena);
        Task<RespuestaBD> RegistrarConsultaRapida(RegistrarConsultaRapida solicitud);
        Task<IEnumerable<CuposProgramacionDto>> ListarCuposProgramacion(DateTime fecha, int idEspecialidad);
        Task<string[]> ListarFechasProgramacion(int idMedico, int idEspecialidad);
        Task<RespuestaBD> RegitrarCita(RegistrarCitaWeb solicitud);
        Task<IEnumerable<CitaWebDto>> ListarCitasdWebPorPaciente(int idPaciente);
        Task<RespuestaBD> SubirVouchersACita(SubirVoucherDto solicitud);
        Task<string> EliminarVoucher(int idCita);
        Task<IEnumerable<CitaWebDto>> ListarCitasWebPorFecha(DateTime FechaDesde, DateTime FechaHasta);
        Task<RespuestaBD> ValidarVoucher(ValidarVoucherDto solicitud);
    }
}