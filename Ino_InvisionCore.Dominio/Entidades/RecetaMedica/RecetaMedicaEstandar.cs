using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.RecetaMedica
{
    public class RecetaMedicaEstandar : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdRecetaMedica { get; set; }
        [Required]
        public int IdAtencion { get; set; }
        [Required]
        public int IdTipoAtencion { get; set; }
        [Required]
        [StringLength(500)]
        public string Paciente { get; set; }
        [Required]
        [StringLength(10)]
        public string HistoriaClinica { get; set; }
        [Required]
        [StringLength(10)]
        public string NroDocumento { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        [StringLength(10)]
        public string CodigoCIE10 { get; set; }
        [Required]
        [StringLength(500)]
        public string Diagnostico { get; set; }
        [Required]
        public DateTime ValidoHasta { get; set; }
        [StringLength(500)]
        public string Observaciones { get; set; }
        [StringLength(500)]
        public string OtrosMedicamentos { get; set; }
        [StringLength(100)]
        public string Medico { get; set; }
        [JsonIgnore]
        public virtual TipoAtencion TipoAtencion { get; set; }
        [JsonIgnore]
        public virtual ICollection<Medicamento> Medicamentos { get; set; }

        public RecetaMedicaEstandar()
        {

        }
    }
}
