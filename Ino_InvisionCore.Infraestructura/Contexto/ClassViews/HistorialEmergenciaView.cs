using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class HistorialEmergenciaView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int IdEmergencia { get; set; }
        public int? NroHistoriaClinica { get; set; }
        public string Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public string Medico { get; set; }
        public string Residente { get; set; }
    }
}
