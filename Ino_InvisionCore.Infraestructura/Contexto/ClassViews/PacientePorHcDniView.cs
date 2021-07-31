using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class PacientePorHcDniView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int IdPaciente { get; set; }
        public int? NroHistoriaClinica { get; set; }
        public string NroDocumento { get; set; }
        public string Paciente { get; set; }
        public int IdEspecialidad { get; set; }
        [NotMapped]
        public bool Temporal { get; set; }
        public int? IdDepartamento { get; set; }
        public bool Anestesia { get; set; }
    }
}
