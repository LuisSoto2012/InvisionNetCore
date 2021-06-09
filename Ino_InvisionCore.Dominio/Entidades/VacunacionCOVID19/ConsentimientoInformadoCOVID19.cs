using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.VacunacionCOVID19
{
    public class ConsentimientoInformadoCOVID19
    {
        [Key]
        public int IdCI { get; set; }
        public int IdPersonalINO { get; set; }
        [Required]
        [StringLength(20)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(250)]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(250)]
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [StringLength(100)]
        public string Telefono { get; set; }

        public bool? ExpCI_P1 { get; set; }
        public bool? ExpCI_P2 { get; set; }
        public bool? ExpCI_P3 { get; set; }

        public bool? DetCV19_P1 { get; set; }
        public bool? DetCV19_P2 { get; set; }
        public bool? DetCV19_P3 { get; set; }

        public bool? DetPrevInm_P1 { get; set; }
        public bool? DetPrevInm_P2 { get; set; }
        public bool? DetPrevInm_P3 { get; set; }
        public bool? DetPrevInm_P4 { get; set; }
        public bool? DetPrevInm_P5 { get; set; }
        public bool? DetPrevInm_P6 { get; set; }
        public bool? DetPrevInm_P7 { get; set; }
        public bool? DetPrevInm_P8 { get; set; }
        public bool? DetPrevInm_P9 { get; set; }

        public string Pulso { get; set; }
        public string Saturacion { get; set; }
        public string PresionArterial { get; set; }

        public int? IdMedico { get; set; }

        public bool? RevCI_P1 { get; set; }
        public bool? RevCI_P2 { get; set; }
        public bool? RevCI_P3 { get; set; }

        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }

        public DateTime? FechaRegistroRevocatoria { get; set; }
        public int? IdUsuarioRegistroRevocatoria { get; set; }

        public bool esTicket { get; set; }

        public ConsentimientoInformadoCOVID19()
        {
            FechaRegistro = DateTime.Now;
        }
    }
}
