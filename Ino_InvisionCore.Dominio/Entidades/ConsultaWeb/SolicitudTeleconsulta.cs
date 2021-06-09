using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.ConsultaWeb
{
    public class SolicitudTeleconsulta
    {
        [Key]
        public int IdSolicitud { get; set; }
        public int IdCuentaAtencion { get; set; }
        public int IdCita { get; set; }
        public DateTime FechaCita { get; set; }
        [StringLength(8)]
        public string HoraCita { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        [StringLength(20)]
        public string NroDocumento { get; set; }
        [StringLength(20)]
        public string NroHistoriaClinica { get; set; }
        [StringLength(150)]
        public string Especialidad { get; set; }
        [StringLength(20)]
        public string Turno { get; set; }
        public int IdDepartamento { get; set; }
        public string FteFto { get; set; }
        [StringLength(20)]
        public string TelefonoMovil { get; set; }
        [StringLength(100)]
        public string CorreoElectronico { get; set; }
        public int IdEstado { get; set; }
        public int? IdUsuarioAcepta { get; set; }
        public DateTime? FechaAcepta { get; set; }
        public int? IdUsuarioAtiende { get; set; }
        public DateTime? FechaAtiende { get; set; }

        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public string Url { get; set; }
        public string NuevoHoraCita { get; set; }

        public DateTime? FechaReprogramacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public SolicitudTeleconsulta()
        {
            FechaCreacion = DateTime.Now;
            IdEstado = 0;
        }
    }
}
