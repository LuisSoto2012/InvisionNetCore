using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers.NervioOptico.Peticiones
{
    public class ModificarNervioOptico
    {
        public int Id { get; set; }
        public int IdAtencion { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public string HistoriaClinica { get; set; }
        public string Edad { get; set; }
        public string DiagnosticoPreoperatorio { get; set; }
        public string Procedimiento { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }

        public string Confiabilidad_OD { get; set; }
        public string PromedioTotal_OD { get; set; }
        public string AreaAnillo_OD { get; set; }
        public string FibrasNerviosas_OD { get; set; }
        public string RelacionCopia_OD { get; set; }
        public string Confiabilidad_OI { get; set; }
        public string PromedioTotal_OI { get; set; }
        public string AreaAnillo_OI { get; set; }
        public string FibrasNerviosas_OI { get; set; }
        public string RelacionCopia_OI { get; set; }

        public int IdUsuarioModificacion { get; set; }

        public string Comentarios { get; set; }
    }
}
