using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.AtencionCE
{
    public class AtencionCE
    {
        [Key]
        public int IdAtencionCE { get; set; }
        public int IdAtencionGalenos { get; set; }
        public string MotivoConsulta { get; set; }
        public string TiempoEnfermedad { get; set; }
        public string DesarrolloCronologico { get; set; }
        public string Pa { get; set; }
        public string Fc { get; set; }
        public string Fr { get; set; }
        public string T { get; set; }
        public string SatO2 { get; set; }
        public string AvConCorreccionOD { get; set; }
        public string AvConCorreccionOI { get; set; }
        public string AvSinCorreccionOD { get; set; }
        public string AvSinCorreccionOI { get; set; }
        public string AvConAEOD { get; set; }
        public string AvConAEOI { get; set; }
        public string PioOD { get; set; }
        public string PioOI { get; set; }

        public string ParpadoOD { get; set; }
        public string ParpadoOI { get; set; }
        public string ConjuntivaOD { get; set; }
        public string ConjuntivaOI { get; set; }
        public string CorneaOD { get; set; }
        public string CorneaOI { get; set; }
        public string PupilarOD { get; set; }
        public string PupilarOI { get; set; }
        public string CristalinoOD { get; set; }
        public string CristalinoOI { get; set; }
        public string VitreoOD { get; set; }
        public string VitreoOI { get; set; }
        public string NervioOpticoOD { get; set; }
        public string NervioOpticoOI { get; set; }
        public string MaculaOD { get; set; }
        public string MaculaOI { get; set; }
        public string RetinaOD { get; set; }
        public string RetinaOI { get; set; }

        public byte[] ImagenOjos { get; set; }

        public string Observaciones { get; set; }
        public string MedidasGenerales { get; set; }

        public string Antecedentes { get; set; }

        public DateTime? ProximaCita { get; set; }
        public string PlanDeTrabajo { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
