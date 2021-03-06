// ServicioDeConsultasWeb.cs22:2622:26

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Peticiones;
using Ino_InvisionCore.Dominio.Contratos.Helpers.CitasWeb.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using Ino_InvisionCore.Dominio.Contratos.Repositorios.CitasWeb;
using Ino_InvisionCore.Dominio.Contratos.Servicios.ConsultasWeb;
using Ino_InvisionCore.Dominio.Entidades.Compartido;

namespace Ino_InvisionCore.Dominio.Servicios
{
    public class ServicioDeCitasWeb : IServicioDeCitasWeb
    {
        private readonly IRepositorioDeCitasWeb _repositorio;

        public ServicioDeCitasWeb(IRepositorioDeCitasWeb repositorio)
        {
            _repositorio = repositorio;
        }
        
        public async Task<RespuestaBD> RegistrarPaciente(RegistrarPacienteDto solicitud)
        {
            return await _repositorio.RegistrarPaciente(solicitud);
        }

        public async Task<PacienteCitaWebLogin> Login(string usuario, string contrasena)
        {
            return await _repositorio.Login(usuario, contrasena);
        }

        public async Task<RespuestaBD> RegistrarConsultaRapida(RegistrarConsultaRapida solicitud)
        {
            return await _repositorio.RegistrarConsultaRapida(solicitud);
        }

        public async Task<IEnumerable<CuposProgramacionDto>> ListarCuposProgramacion(DateTime fecha, int idEspecialidad)
        {
            return await _repositorio.ListarCuposProgramacion(fecha, idEspecialidad);
        }

        public async Task<string[]> ListarFechasProgramacion(int idMedico, int idEspecialidad)
        {
            return await _repositorio.ListarFechasProgramacion(idMedico, idEspecialidad);
        }

        public async Task<RespuestaBD> RegistrarCita(RegistrarCitaWeb solicitud)
        {
            return await _repositorio.RegitrarCita(solicitud);
        }

        public async Task<IEnumerable<CitaWebDto>> ListarCitasWebPorPaciente(int idPaciente)
        {
            return await _repositorio.ListarCitasdWebPorPaciente(idPaciente);
        }

        public async Task<RespuestaBD> SubirVouchersACita(SubirVoucherDto solicitud)
        {
            return await _repositorio.SubirVouchersACita(solicitud);
        }

        public async Task<string> EliminarVoucher(int idCita)
        {
            return await _repositorio.EliminarVoucher(idCita);
        }

        public async Task<IEnumerable<CitaWebDto>> ListarCitasWebPorFecha(DateTime? fechaPagoDesde, DateTime? fechaPagoHasta, DateTime? fechaCitaDesde, DateTime? fechaCitaHasta)
        {
            return await _repositorio.ListarCitasWebPorFecha(fechaPagoDesde, fechaPagoHasta, fechaCitaDesde, fechaCitaHasta);
        }

        public async Task<RespuestaBD> ValidarVoucher(ValidarVoucherDto solicitud)
        {
            return await _repositorio.ValidarVoucher(solicitud);
        }

        public async Task<RespuestaBD> RechazarVoucher(RechazarVoucherDto solicitud)
        {
            return await _repositorio.RechazarVoucher(solicitud);
        }

        public Task<RespuestaBD> EliminarCita(EliminarCitaDto solicitud)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EsSIS(string nroDocumento)
        {
            return await _repositorio.EsSIS(nroDocumento);
        }

        public async Task<IEnumerable<ComboBox>> ListarCajerosAsync()
        {
            return await _repositorio.ListarCajerosAsync();
        }
    }
}