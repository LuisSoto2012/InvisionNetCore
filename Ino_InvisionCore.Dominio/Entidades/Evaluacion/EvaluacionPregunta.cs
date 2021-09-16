// EvaluacionPregunta.cs22:2322:23

using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Dominio.Entidades.Evaluacion
{
    public class EvaluacionPregunta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Modulo { get; set; }
        [Required]
        public string Pregunta { get; set; }
        [Required]
        public string Respuestas { get; set; }
        [Required] 
        public bool Activo { get; set; }
        [Required]
        public int IdUsuarioCreacion { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}