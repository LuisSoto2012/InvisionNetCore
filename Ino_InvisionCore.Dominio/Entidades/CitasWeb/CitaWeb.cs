// CitaWeb.cs19:2719:27

using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Dominio.Entidades.CitasWeb
{
    public class CitaWeb
    {
        // [IdCita] [int] IDENTITY(1,1) NOT NULL,
        // [Fecha] [datetime] NOT NULL,
        // [HoraInicio] [char](5) NOT NULL,
        // [HoraFin] [char](5) NOT NULL,
        // [IdPaciente] [int] NOT NULL,
        // [IdEstadoCita] [int] NOT NULL,
        // [IdAtencion] [int] NOT NULL,
        // [IdMedico] [int] NOT NULL,
        // [IdEspecialidad] [int] NOT NULL,
        // [IdServicio] [int] NOT NULL,
        // [IdProgramacion] [int] NOT NULL,
        // [IdProducto] [int] NULL,
        // [FechaSolicitud] [datetime] NOT NULL,
        // [HoraSolicitud] [char](5) NOT NULL,
        // [EsCitaAdicional] [bit] NULL
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
    }
}