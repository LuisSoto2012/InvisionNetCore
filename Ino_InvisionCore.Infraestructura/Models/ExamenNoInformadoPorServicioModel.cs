using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Models
{
    public class ExamenNoInformadoPorServicioModel : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdExamen { get; set; }
        [Required]
        public DateTime FechaOcurrencia { get; set; }
        [Required]
        public int IdEspecialidad { get; set; }
        [Required]
        [StringLength(50)]
        public string Especialidad { get; set; }
        [Required]
        public int TotalPacientes { get; set; }
    }
}
