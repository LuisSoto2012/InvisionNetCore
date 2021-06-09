using Ino_InvisionCore.Dominio.Entidades.Compartido;
using Ino_InvisionCore.Dominio.Entidades.Comunes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Dominio.Entidades.AccidenteDeTrabajo
{
    public class AccidenteDeTrabajo : BaseGeneral
    {
        [Key]
        public int IdRegistroAccidenteDeTrabajo { get; set; }
        public int NroTrabajadores_SCTR { get; set; }
        public int NroTrabajadores_NoSCTR { get; set; }
        [StringLength(500)]
        public string Nombre_Aseguradora { get; set; }
        [StringLength(50)]
        public string TipoVinculacion_Accidentado { get; set; }
        [StringLength(200)]
        public string ApellidoPaterno_Accidentado { get; set; }
        [StringLength(200)]
        public string ApellidoMaterno_Accidentado { get; set; }
        [StringLength(200)]
        public string Nombres_Accidentado { get; set; }
        public DateTime FechaNacimiento_Accidentado { get; set; }
        public int Edad_Accidentado { get; set; }
        public char Sexo_Accidentado { get; set; }
        [StringLength(50)]
        public string TipoDocumento_Accidentado { get; set; }
        [StringLength(10)]
        public string NumeroDocumento_Accidentado { get; set; }
        [StringLength(500)]
        public string Domicilio_Accidentado { get; set; }
        [StringLength(50)]
        public string Distrito_Accidentado { get; set; }
        [StringLength(50)]
        public string Provincia_Accidentado { get; set; }
        [StringLength(50)]
        public string Departamento_Accidentado { get; set; }
        [StringLength(200)]
        public string Referencias_Accidentado { get; set; }
        [StringLength(50)]
        public string TipoOcupacion_Accidentado { get; set; }
        [StringLength(100)]
        public string Ocupacion_Accidentado { get; set; }
        [StringLength(30)]
        public string JornadaTrabajo_Accidentado { get; set; }
        [StringLength(50)]
        public string Area_Accidentado { get; set; }
        [StringLength(20)]
        public string AntiguedadEmpleo_Accidentado { get; set; }
        [StringLength(20)]
        public string TiempoExperiencia_Accidentado { get; set; }
        public int NroHorasTrabajadas_Accidentado { get; set; }

        public DateTime Fecha_Accidente { get; set; }
        [StringLength(10)]
        public string Hora_Accidente { get; set; }
        [StringLength(30)]
        public string Jornada_Accidente { get; set; }
        public bool EsLaborHabitual_Accidente { get; set; }
        [StringLength(100)]
        public string LaborHabitual_Accidente { get; set; }
        public DateTime FechaInvestigacion_Accidente { get; set; }
        [StringLength(100)]
        public string Lugar_Accidente { get; set; }
        [StringLength(100)]
        public string Area_Accidente { get; set; }
        [StringLength(50)]
        public string Gravedad_Accidente { get; set; }
        [StringLength(50)]
        public string Grado_Accidente { get; set; }
        public int NroDiasDescanso_Accidente { get; set; }
        public int NroTrabajadoresAfectados_Accidente { get; set; }

        [MaxLength]
        public string DeclaracionAfectado_DescripcionAccidente { get; set; }
        public bool HuboTestigos_DescripcionAccidente { get; set; }
        [StringLength(200)]
        public string NombreTestigo_DescripcionAccidente { get; set; }
        [StringLength(100)]
        public string CargoTestigo_DescripcionAccidente { get; set; }
        [StringLength(10)]
        public string DocumentoIdentidad_DescripcionAccidente { get; set; }
        [MaxLength]
        public string DeclaracionTestigo_DescripcionAccidente { get; set; }

        [MaxLength]
        public string AgenteAccidente_CausaAccidente { get; set; }
        [MaxLength]
        public string MecanismoFormaAccidente_CausaAccidente { get; set; }
        [MaxLength]
        public string TipoLesion_CausaAccidente { get; set; }
        [MaxLength]
        public string ParteCuerpo_CausaAccidente { get; set; }

        [MaxLength]
        public string Descripcion_MedidaCorrectiva { get; set; }
        [MaxLength]
        public string Responsable_MedidaCorrectiva { get; set; }
        [MaxLength]
        public string FechaEjecucion_MedidaCorrectiva { get; set; }
        [MaxLength]
        public string EstadoImplementacion_MedidaCorrectiva { get; set; }

        [MaxLength]
        public string NombreResponsable_RegistroInvestigacion { get; set; }
        [MaxLength]
        public string CargoResponsable_RegistroInvestigacion { get; set; }
        [MaxLength]
        public string Fecha_RegistroInvestigacion { get; set; }

        public AccidenteDeTrabajo()
        {

        }
    }
}
