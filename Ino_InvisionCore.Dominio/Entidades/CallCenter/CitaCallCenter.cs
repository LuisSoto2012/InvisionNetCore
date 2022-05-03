using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.CallCenter
{
    public class CitaCallCenter
    {
        [Key]
        public int Id { get; set; }
        public string NroDocumento { get; set; }
        public string Paciente { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaLlamada { get; set; }
        public string InicioLlamada { get; set; }
        public string FinLlamada { get; set; }
        public bool EsCita { get; set; }
        public string Especialidad { get; set; }
        public DateTime? FechaCita { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Motivo { get; set; }
        public string TipoSeguro { get; set; }
        public string EstadoHojaReferencia { get; set; }
        public string Turno { get; set; }
        public bool LlamadaSinRegistro { get; set; }
        public string Usuario { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
