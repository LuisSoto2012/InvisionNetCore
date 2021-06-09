using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.RecetaMedica
{
    public class Medicamento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int IdMedicamento { get; set; }
        [Required]
        public int IdRecetaMedica { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string ForFarm { get; set; }
        //[Required]
        //[StringLength(30)]
        //public string UnidadMedida { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [StringLength(50)]
        public string Ojo { get; set; }
        [Required]
        [MaxLength]
        public string Indicacion { get; set; }
        [StringLength(100)]
        public string ViaAdministracion { get; set; }
        [JsonIgnore]
        public virtual RecetaMedicaEstandar RecetaMedicaEstandar { get; set; }

        public Medicamento()
        {

        }

    }
}
