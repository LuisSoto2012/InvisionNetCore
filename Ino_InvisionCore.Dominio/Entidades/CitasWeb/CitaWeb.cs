// CitaWeb.cs19:2719:27

using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Dominio.Entidades.CitasWeb
{
    public class CitaWeb
    {
        [Key]
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        public string HoraInicio { get; set; }
        [Required]
        public string HoraFin { get; set; }
        public int IdPaciente { get; set; }
        [Required]
        public string Paciente { get; set; }
        public int IdEstadoCita { get; set; }
        public int IdAtencionGalenos { get; set; }
        public int IdMedico { get; set; }
        [Required]
        public string Medico { get; set; }
        public int IdEspecialidad { get; set; }
        [Required]
        public string Especialidad { get; set; }
        public int IdServicio { get; set; }
        [Required]
        public string Servicio { get; set; }
        public int IdProgramacion { get; set; }
        public int? IdProducto { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string HoraSolicitud { get; set; }
        public bool? EsCitaAdicional { get; set; }
        public string Voucher { get; set; }
        public string ImagenVoucher { get; set; }
        public bool? VoucherValido { get; set; }
        public int? IdUsuarioValidaVoucher { get; set; }
        public DateTime? FechaValidacionVoucher { get; set; }
        public int IdEstado { get; set; }
        public int? IdUsuarioElimina { get; set; }
        public DateTime? FechaEliminacionCita { get; set; }
    }
}