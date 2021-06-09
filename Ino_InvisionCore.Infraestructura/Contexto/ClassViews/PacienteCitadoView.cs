using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class PacienteCitadoView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int IdPaciente { get; set; }
        public int NroHistoriaClinica { get; set; }
        public string NroDocumento { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string PrimerNombre { get; set; }
        public string Especialidad { get; set; }
        public string Servicio { get; set; }
        public int IdArchivo { get; set; }
    }
}
