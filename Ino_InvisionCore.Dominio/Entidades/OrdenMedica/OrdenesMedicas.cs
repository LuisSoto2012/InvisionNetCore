using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.OrdenMedica
{
    public class OrdenesMedicas : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdOrdenMedica { get; set; }
        [Required]
        [StringLength(10)]
        public string HistoriaClinica { get; set; }
        [StringLength(10)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(500)]
        public string Paciente { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int IdTipoOrdenMedica { get; set; }
        [Required]
        public int IdAtencion { get; set; }
        public int IdTipoAnestesia { get; set; }
        public int IdTipoUsuario { get; set; }
        [Required]
        public int IdEspecialidad { get; set; }
        [Required]
        [StringLength(100)]
        public string NombreEspecialidad { get; set; }
        [StringLength(100)]
        public string Medico { get; set; }
        [JsonIgnore]
        public virtual TipoOrdenMedica TipoOrdenMedica { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrdenesMedicasCodigos> OrdenesMedicasCodigos { get; set; }


    }
}
