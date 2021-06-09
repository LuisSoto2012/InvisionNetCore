using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.RecetaMedica
{
    public class TipoAtencion : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdTipoAtencion { get; set; }
        [StringLength(30)]
        [Required]
        public string Nombre { get; set; }
        [JsonIgnore]
        public virtual RecetaMedicaEstandar RecetaMedicaEstandar { get; set; }

        public TipoAtencion()
        {

        }

    }
}
