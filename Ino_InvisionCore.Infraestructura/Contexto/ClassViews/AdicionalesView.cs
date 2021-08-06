using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.ClassViews
{
    public class AdicionalesView
    {
        [Key]
        public Int64 RowId { get; set; }
        public int IdAdicional { get; set; }
        public string Hc { get; set; }
        public string Paciente { get; set; }
        public string Especialidad { get; set; }
        public string Medico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaAdicional { get; set; }
        public string Rne { get; set; }
        public string Cmp { get; set; }
    }
}
