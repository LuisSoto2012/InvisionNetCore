using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.LaboratorioInmunologico;
using Ino_InvisionCore.Dominio.Entidades.MuchosAMuchos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.Comunes
{
    public class AreaLaboratorio : BaseGeneral
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAreaLaboratorio { get; set; }
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }
        [StringLength(5)]
        public string Codigo { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<SubModulo> SubModulos { get; set; }
        //[JsonIgnore]
        //public virtual int IdAreaLaboratorioPocoFrecuente { get; set; }
        [JsonIgnore]
        public virtual PocoFrecuente PocoFrecuente { get; set; }
        //[JsonIgnore]
        //public virtual int IdAreaLaboratorioEquipoUPS { get; set; }
        [JsonIgnore]
        public virtual EquipoUPS EquipoUPS { get; set; }
        //[JsonIgnore]
        //public virtual int IdAreaLaboratorioCalibracionDeficiente { get; set; }
        [JsonIgnore]
        public virtual CalibracionDeficiente CalibracionDeficiente { get; set; }
        //[JsonIgnore]
        //public virtual int IdAreaLaboratorioSueroMalReferenciado { get; set; }
        [JsonIgnore]
        public virtual SueroMalReferenciado SueroMalReferenciado { get; set; }
        //[JsonIgnore]
        //public virtual int IdAreaLaboratorioMaterialNoCalibrado { get; set; }
        [JsonIgnore]
        public virtual MaterialNoCalibrado MaterialNoCalibrado { get; set; }
        [JsonIgnore]
        public virtual EquipoMalCalibrado EquipoMalCalibrado { get; set; }
        //[JsonIgnore]
        //public virtual int IdAreaLaboratorioMuestraHemolizadaLipemica { get; set; }
        [JsonIgnore]
        public virtual MuestraHemolizadaLipemica MuestraHemolizadaLipemica { get; set; }
        //[JsonIgnore]
        //public virtual int IdAreaLaboratorioRendimientoHoraTrabajador { get; set; }
        [JsonIgnore]
        public virtual RendimientoHoraTrabajador RendimientoHoraTrabajador { get; set; }
        //[JsonIgnore]
        //public virtual int IdAreaLaboratorioEmpleoReactivo { get; set; }
        [JsonIgnore]
        public virtual EmpleoReactivo EmpleoReactivo { get; set; }
        //[JsonIgnore]
        //public virtual int IdAreaLaboratorioTranscripcionErroneaInoportuna { get; set; }
        [JsonIgnore]
        public virtual TranscripcionErroneaInoportuna TranscripcionErroneaInoportuna { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubModuloAreaLaboratorio> SubModuloAreaLaboratorios { get; set; }

        public AreaLaboratorio()
        {
            //this.SubModulos = new HashSet<SubModulo>();
        }
    }
}
