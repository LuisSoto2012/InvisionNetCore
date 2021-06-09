using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.AccidenteDeTrabajo.Peticiones
{
    public class ActualizarAccidenteDeTrabajo
    {
        public int IdRegistroAccidenteDeTrabajo { get; set; }

        public int NroTrabajadores_SCTR { get; set; }
        public int NroTrabajadores_NoSCTR { get; set; }
        public string Nombre_Aseguradora { get; set; }
        public string TipoVinculacion_Accidentado { get; set; }
        public string ApellidoPaterno_Accidentado { get; set; }
        public string ApellidoMaterno_Accidentado { get; set; }
        public string Nombres_Accidentado { get; set; }
        public DateTime FechaNacimiento_Accidentado { get; set; }
        public int Edad_Accidentado { get; set; }
        public char Sexo_Accidentado { get; set; }
        public string TipoDocumento_Accidentado { get; set; }
        public string NumeroDocumento_Accidentado { get; set; }
        public string Domicilio_Accidentado { get; set; }
        public string Distrito_Accidentado { get; set; }
        public string Provincia_Accidentado { get; set; }
        public string Departamento_Accidentado { get; set; }
        public string Referencias_Accidentado { get; set; }
        public string TipoOcupacion_Accidentado { get; set; }
        public string Ocupacion_Accidentado { get; set; }
        public string JornadaTrabajo_Accidentado { get; set; }
        public string Area_Accidentado { get; set; }
        public string AntiguedadEmpleo_Accidentado { get; set; }
        public string TiempoExperiencia_Accidentado { get; set; }
        public int NroHorasTrabajadas_Accidentado { get; set; }

        public DateTime Fecha_Accidente { get; set; }
        public string Hora_Accidente { get; set; }
        public string Jornada_Accidente { get; set; }
        public string EsLaborHabitual_Accidente { get; set; }
        public string LaborHabitual_Accidente { get; set; }
        public DateTime FechaInvestigacion_Accidente { get; set; }
        public string Lugar_Accidente { get; set; }
        public string Area_Accidente { get; set; }
        public string Gravedad_Accidente { get; set; }
        public string Grado_Accidente { get; set; }
        public int NroDiasDescanso_Accidente { get; set; }
        public int NroTrabajadoresAfectados_Accidente { get; set; }

        public string DeclaracionAfectado_DescripcionAccidente { get; set; }
        public string HuboTestigos_DescripcionAccidente { get; set; }
        public string NombreTestigo_DescripcionAccidente { get; set; }
        public string CargoTestigo_DescripcionAccidente { get; set; }
        public string DocumentoIdentidad_DescripcionAccidente { get; set; }
        public string DeclaracionTestigo_DescripcionAccidente { get; set; }

        [NotMapped]
        public IList<string> AgenteAccidente_CausaAccidente { get; set; }
        [NotMapped]
        public IList<string> MecanismoFormaAccidente_CausaAccidente { get; set; }
        [NotMapped]
        public IList<string> TipoLesion_CausaAccidente { get; set; }
        [NotMapped]
        public IList<string> ParteCuerpo_CausaAccidente { get; set; }

        [NotMapped]
        public IList<MedidaCorrectivaDto> MedidasCorrectivas { get; set; }
        [NotMapped]
        public IList<RegistroInvestigacionDto> RegistrosInvestigacion { get; set; }

        public int IdUsuarioModificacion { get; set; }
    }
}
