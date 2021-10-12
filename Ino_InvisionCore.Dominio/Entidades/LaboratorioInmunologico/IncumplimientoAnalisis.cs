using Ino_InvisionCore.Dominio.Entidades.Compartido;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico
{
    public class IncumplimientoAnalisis : BaseGeneral
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdIncumplimientoAnalisis { get; set; }
        [Required]
        [StringLength(10)]
        public string HistoriaClinica { get; set; }
        [StringLength(10)]
        public string NumeroDocumento { get; set; }
        [Required]
        [StringLength(50)]
        public string Paciente { get; set; }
        public bool ElisaHIV { get; set; }
        public bool AnaIFI { get; set; }
        public bool FtaAbsorcion { get; set; }
        public bool ToxoplasmaIggIgm { get; set; }
        [Required]
        public DateTime FechaOcurrencia { get; set; }
        public bool BacterianoAntibiograma { get; set; }
        public bool Giemsa { get; set; }
        public bool Gram { get; set; }
        public bool Micotico { get; set; }
        public bool Pas { get; set; }
    }
}
