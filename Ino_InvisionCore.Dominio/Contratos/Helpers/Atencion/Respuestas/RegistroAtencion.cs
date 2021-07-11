using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.Atencion.Respuestas
{
    public class RegistroAtencion
    {
        public int Id { get; set; }
        public int IdCita { get; set; }
        public int NroHistoriaClinica { get; set; }
        public string Paciente { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public int IdEspecialidad { get; set; }
        public string Especialidad { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public string Financiamiento { get; set; }
        public string Diacod1 { get; set; }
        public string Diades1 { get; set; }
        public int IdTipoDiagnostico1 { get; set; }
        public string Diacod2 { get; set; }
        public string Diades2 { get; set; }
        public int IdTipoDiagnostico2 { get; set; }
        public string Diacod3 { get; set; }
        public string Diades3 { get; set; }
        public int IdTipoDiagnostico3 { get; set; }
        public DateTime FechaAtencion { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string CodProc1 { get; set; }
        public string Coddes1 { get; set; }
        public string CodProc2 { get; set; }
        public string Coddes2 { get; set; }
        public string CodProc3 { get; set; }
        public string Coddes3 { get; set; }
        public int IdResidente { get; set; }
        public string Residente { get; set; }
        public int IdTipoCondicionEstablecimiento { get; set; }
        public int IdTipoCondicionServicio { get; set; }
        public string Diacod1_OI { get; set; }
        public string Diades1_OI { get; set; }
        public int IdTipoDiagnostico1_OI { get; set; }
        public string Diacod2_OI { get; set; }
        public string Diades2_OI { get; set; }
        public int IdTipoDiagnostico2_OI { get; set; }
        public string Diacod3_OI { get; set; }
        public string Diades3_OI { get; set; }
        public int IdTipoDiagnostico3_OI { get; set; }
        public string CodProc1_OI { get; set; }
        public string Coddes1_OI { get; set; }
        public string CodProc2_OI { get; set; }
        public string Coddes2_OI { get; set; }
        public string CodProc3_OI { get; set; }
        public string Coddes3_OI { get; set; }
        public string Avod { get; set; }
        public string Avoi { get; set; }
        public string Anamnesis { get; set; }

        public string MotivoConsulta { get; set; }
        public string TiempoEnfermedad { get; set; }
        public string DesarrolloCronologico { get; set; }
        public string Pa { get; set; }
        public string Fc { get; set; }
        public string Fr { get; set; }
        public string T { get; set; }
        public string SatO2 { get; set; }
        public DateTime? ProximaCita { get; set; }
        public string PlanDeTrabajo { get; set; }
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

        public string ImagenOjos { get; set; }

        public string Observaciones { get; set; }
        public string MedidasGenerales { get; set; }
        public string Antecedentes { get; set; }
    }
}
