using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Dominio.Entidades.EvaluacionesExamenes
{
    public class EvaluacionExamen
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdAtencion { get; set; }
        [Required]
        public int IdPaciente { get; set; }
        [Required]
        public string Paciente { get; set; }
        [Required]
        public int IdMedico { get; set; }
        [Required]
        public string Medico { get; set; }
        [Required]
        public string TipoEvaluacion { get; set; }
        public string Programa { get; set; }
        public string Estrategia { get; set; }
        public string EstimuloNumero { get; set; }
        public string EstimuloColor { get; set; }
        public string ConfiabilidadOD { get; set; }
        public string ConfiabilidadOI { get; set; }
        public string DefectoCampoVisualOD { get; set; }
        public string DefectoCampoVisualOI { get; set; }
        public string ContraccionGenODSUP { get; set; }
        public string ContraccionGenODINF { get; set; }
        public string ContraccionGenOISUP { get; set; }
        public string ContraccionGenOIINF { get; set; }
        public string ContraccionPerLocODSUP { get; set; }
        public string ContraccionPerLocODINF { get; set; }
        public string ContraccionPerLocOISUP { get; set; }
        public string ContraccionPerLocOIINF { get; set; }
        public string EscotomaAreaArqODSUP { get; set; }
        public string EscotomaAreaArqODINF { get; set; }
        public string EscotomaAreaArqOISUP { get; set; }
        public string EscotomaAreaArqOIINF { get; set; }
        public string EscalonNasalODSUP { get; set; }
        public string EscalonNasalODINF { get; set; }
        public string EscalonNasalOISUP { get; set; }
        public string EscalonNasalOIINF { get; set; }
        public string EscotomaParacentralODSUP { get; set; }
        public string EscotomaParacentralODINF { get; set; }
        public string EscotomaParacentralOISUP { get; set; }
        public string EscotomaParacentralOIINF { get; set; }
        public string EscotomaCentralOD { get; set; }
        public string EscotomaCentralOI { get; set; }
        public string EscotomaCecocentralOD { get; set; }
        public string EscotomaCecocentralOI { get; set; }
        public string IntensidadGlobalOD { get; set; }
        public string IntensidadGlobalOI { get; set; }
        public string DepresionNoEspecOD { get; set; }
        public string DepresionNoEspecOI { get; set; }
        public string AgrandamientoManchaCiegaOD { get; set; }
        public string AgrandamientoManchaCiegaOI { get; set; }
        public string HemianopsiaHomonimaOD { get; set; }
        public string HemianopsiaHomonimaOI { get; set; }
        public string HemianopsiaBitemporalOD { get; set; }
        public string HemianopsiaBitemporalOI { get; set; }
        public string OtrosDefectosOD { get; set; }
        public string OtrosDefectosOI { get; set; }
        public string ComentariosOD { get; set; }
        public string ComentariosOI { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public int? IdEstado { get; set; }
    }
}
