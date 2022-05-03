using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.AtencionCE
{
    public class RecetaRefraccionCE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdRecetaRefraccion { get; set; }
        [Required]
        public int IdCita { get; set; }

        [StringLength(2)]
        public string LSignoOD1 { get; set; }
        [StringLength(50)]
        public string LEsferaOD { get; set; }
        [StringLength(2)]
        public string LSignoOD2 { get; set; }
        [StringLength(50)]
        public string LCilindroOD { get; set; }
        [StringLength(50)]
        public string LEjeOD { get; set; }

        [StringLength(2)]
        public string LSignoOI1 { get; set; }
        [StringLength(50)]
        public string LEsferaOI { get; set; }
        [StringLength(2)]
        public string LSignoOI2 { get; set; }
        [StringLength(50)]
        public string LCilindroOI { get; set; }
        [StringLength(50)]
        public string LEjeOI { get; set; }

        [StringLength(100)]
        public string Ldip { get; set; }
        [StringLength(100)]
        public string Lprisma { get; set; }

        [StringLength(2)]
        public string CSignoOD1 { get; set; }
        [StringLength(50)]
        public string CEsferaOD { get; set; }
        [StringLength(2)]
        public string CSignoOD2 { get; set; }
        [StringLength(50)]
        public string CCilindroOD { get; set; }
        [StringLength(50)]
        public string CEjeOD { get; set; }

        [StringLength(2)]
        public string CSignoOI1 { get; set; }
        [StringLength(50)]
        public string CEsferaOI { get; set; }
        [StringLength(2)]
        public string CSignoOI2 { get; set; }
        [StringLength(50)]
        public string CCilindroOI { get; set; }
        [StringLength(50)]
        public string CEjeOI { get; set; }

        [StringLength(100)]
        public string Cdip { get; set; }
        [StringLength(100)]
        public string Cprisma { get; set; }

        //public int? IdMaterial { get; set; }
        //public int? IdBifocal { get; set; }

        //public bool AdicionalMas { get; set; }
        //public bool AdicionalMenos { get; set; }

        public string Material { get; set; }
        public string Diseno { get; set; }
        public string Tratamiento { get; set; }
        public string Servicio { get; set; }
        //public int? IdEspecificacion5 { get; set; }

        [StringLength(250)]
        public string Paciente { get; set; }
        [StringLength(20)]
        public string NroDocumento { get; set; }
        [StringLength(200)]
        public string DxOD { get; set; }
        [StringLength(200)]
        public string DxOI { get; set; }

        [StringLength(10)]
        public string LAVOD { get; set; }
        [StringLength(10)]
        public string LAVOI { get; set; }
        [StringLength(10)]
        public string CAVOD { get; set; }
        [StringLength(10)]
        public string CAVOI { get; set; }

        [StringLength(100)]
        public string ADD { get; set; }
        [StringLength(250)]
        public string Observaciones { get; set; }
        [StringLength(250)]
        public string ListaDeDx { get; set; }

        [StringLength(100)]
        public string LNSPD { get; set; }
        [StringLength(100)]
        public string LNSPI { get; set; }
        [StringLength(100)]
        public string CNSPD { get; set; }
        [StringLength(100)]
        public string CNSPI { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public bool EstaImpreso { get; set; }
    }
}
