using System;
using System.ComponentModel.DataAnnotations;

namespace Ino_InvisionCore.Dominio.Entidades.Anestesia
{
    public class EvaluacionPreAnestesica
    {
        [Key]
        public int Id { get; set; }
        public int IdAtencion { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public string HistoriaClinica { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string Servicio { get; set; }
        public string Cama { get; set; }
        public string DiagnosticoPreoperatorio { get; set; }
        public string Procedimiento { get; set; }
        public string TipoAtencion { get; set; }
        public bool HipertensionArterial_SiNo { get; set; }
        public string HipertensionArterial_Descripcion { get; set; }
        public bool DiabetesMellitus_SiNo { get; set; }
        public string DiabetesMellitus_Descripcion { get; set; }
        public bool Dislipidemias_SiNo { get; set; }
        public string Dislipidemias_Descripcion { get; set; }
        public bool EnfermedadRespiratoria_SiNo { get; set; }
        public string EnfermedadRespiratoria_Descripcion { get; set; }
        public bool EnfermedadCardiaca_SiNo { get; set; }
        public string EnfermedadCardiaca_Descripcion { get; set; }
        public bool EnfermedadRenal_SiNo { get; set; }
        public string EnfermedadRenal_Descripcion { get; set; }
        public bool EnfermedadNeurológica_SiNo { get; set; }
        public string EnfermedadNeurológica_Descripcion { get; set; }
        public bool Hemorragicos_SiNo { get; set; }
        public string Hemorragicos_Descripcion { get; set; }
        public bool RAMs_SiNo { get; set; }
        public string RAMs_Descripcion { get; set; }
        public string OtrosAntecedentes { get; set; }
        public string OtrosAntecedentes_Descripcion { get; set; }
        public string AntecedentesQuirurgicosAnastesicos { get; set; }
        public string ExamenFisico_PA { get; set; }
        public string ExamenFisico_FC { get; set; }
        public string ExamenFisico_FR { get; set; }
        public string ExamenFisico_T { get; set; }
        public string ExamenFisico_Peso { get; set; }
        public string ExamenFisico_RuidosCard { get; set; }
        public string ExamenFisico_Soplos { get; set; }
        public string ExamenFisico_ToraxPulmones { get; set; }
        public string ExamenFisico_Neurologico { get; set; }
        public string ExamenFisico_ProtesisDental { get; set; }
        public string ExamenFisico_DientesFlojos { get; set; }
        public string ExamenFisico_DistanciaTM { get; set; }
        public string ExamenFisico_MovCervical { get; set; }
        public string ExamenFisico_Mallampati { get; set; }
        public string ExamenFisico_TestGanzouri { get; set; }
        public bool ExamenFisico_LaringoscopiaDificil { get; set; }
        public string ExamenFisico_OtrosHallazgos { get; set; }
        public string LaboratorioImagenImagen_HbHcto { get; set; }
        public string LaboratorioImagen_Glicemia { get; set; }
        public string LaboratorioImagen_TC { get; set; }
        public string LaboratorioImagen_TS { get; set; }
        public DateTime? LaboratorioImagen_FechaExamen1 { get; set; }
        public string LaboratorioImagen_Plaquetas { get; set; }
        public string LaboratorioImagen_Crea { get; set; }
        public string LaboratorioImagen_Urea { get; set; }
        public DateTime? LaboratorioImagen_FechaExamen2 { get; set; }
        public string LaboratorioImagen_RxTorax { get; set; }
        public DateTime? LaboratorioImagen_FechaExamen3 { get; set; }
        public string LaboratorioImagen_Otros { get; set; }
        public DateTime? LaboratorioImagen_FechaExamen4 { get; set; }
        public string ClasificacionASA { get; set; }
        public bool ClasificacionASA_Emergencia { get; set; }
        public string ClasificacionGOLDMAN { get; set; }
        public string PlanAnestesico{ get; set; }
        public string PlanAnestesico_Otros { get; set; }
        public string ConclusionesRecomendaciones { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int IdEstado { get; set; }
    }
}
