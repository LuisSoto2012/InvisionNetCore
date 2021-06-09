using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class PruebasNoRealizadas : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdPruebasNoRealizadas { get; set; }
        [Required]
        [StringLength(10)]
        public string HistoriaClinica { get; set; }
        [StringLength(10)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(500)]
        public string Paciente { get; set; }
        public bool Anca { get; set; }
        public bool AntiCpp { get; set; }
        public bool AntiDna { get; set; }
        public bool AntifenosFebriles { get; set; }
        public bool BartonellaIgg { get; set; }
        public bool BartonellaIggIgm { get; set; }
        public bool BkEsputo { get; set; }
        public bool Cortisol { get; set; }
        public bool ElisaToxoplasma { get; set; }
        public bool HlaB27 { get; set; }
        public bool Htlv { get; set; }
        public bool Mercaptoetanol{ get; set; }
        public bool PerfilTiroideo{ get; set; }
        public bool Ppd { get; set; }
        public bool Parasitologico { get; set; }
        public string Comentario { get; set; }
        [Required]
        public DateTime FechaOcurrencia { get; set; }
    }
}
