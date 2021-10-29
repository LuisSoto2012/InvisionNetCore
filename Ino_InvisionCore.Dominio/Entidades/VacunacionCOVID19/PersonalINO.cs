using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.VacunacionCOVID19
{
    public class PersonalINO
    {
        [Key]
        public int Id { get; set; }
        public int TipoDocumento { get; set; }
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
        [StringLength(20)]
        public string Sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [StringLength(100)]
        public string Actividad { get; set; }
        [StringLength(100)]
        public string Telefono { get; set; }
        [StringLength(250)]
        public string Direccion { get; set; }
        [StringLength(100)]
        public string Tipo { get; set; }
        [StringLength(100)]
        public string Categoria { get; set; }
        public bool Estado { get; set; }
    }
}
