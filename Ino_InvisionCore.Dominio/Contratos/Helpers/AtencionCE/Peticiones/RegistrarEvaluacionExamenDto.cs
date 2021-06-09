using Ino_InvisionCore.Dominio.Contratos.Helpers.Comunes.Respuestas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.AtencionCE.Peticiones
{
    public class RegistrarEvaluacionExamenDto
    {
        public int IdAtencion { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public string TipoEvaluacion { get; set; }
        public string[] Programa { get; set; }
        public string[] Estrategia { get; set; }
        public string[] EstimuloNumero { get; set; }
        public string[] EstimuloColor { get; set; }
        public ComboBox ConfiabilidadOD { get; set; }
        public ComboBox ConfiabilidadOI { get; set; }
        public ComboBox DefectoCampoVisualOD { get; set; }
        public ComboBox DefectoCampoVisualOI { get; set; }
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
        public int IdUsuarioCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
    }
}
